#include "pch.h"

#include "NativeWifiManager.h"
#include "NativeWifiResMgmt.h"
#include "NativeWifiHelper.h"
#include "utils.h"
#include "exceptions.h"

namespace NativeWifi {

	namespace {
		delegate void WlanCallbackDelegate(PWLAN_NOTIFICATION_DATA, PVOID);
	}

	auto WifiNetwork::ProfileName::get()->System::String^ {
		if (profile_) {
			if (!profileMan_) {
				profileMan_ = gcnew System::String(profile_->c_str());
			}
			return profileMan_;
		}
		return nullptr;
	}

	WifiNetwork::WifiNetwork(LONG rssi, ULONG linkQual, ULONG freq, const uint8_t* bssid,
		DOT11_SSID const& ssid, std::wstring const& profile) :
		RSSI_{ rssi }, LinkQuality_{ linkQual }, Freq_{ freq }
	{
		SSID_ = gcnew System::String(reinterpret_cast<const char*>(ssid.ucSSID), 0, ssid.uSSIDLength);
		
		if (profile.size()) {
			profile_ = new std::wstring(profile);
		}
		else {
			profile_ = nullptr;
		}

		BSSID_ = gcnew array<uint8_t>(6);
		for (int i = 0; i < 6; ++i) {
			BSSID_[i] = bssid[i];
		}
	}

	WifiNetwork::~WifiNetwork() {
		this->!WifiNetwork();
	}

	WifiNetwork::!WifiNetwork() {
		if (profile_) {
			delete profile_;
			profile_ = nullptr;
		}
	}

	NativeWifiManager::NativeWifiManager() {
		DWORD wlanVer;
		HANDLE outHandle;
		auto const ret = WlanOpenHandle(2, NULL, &wlanVer, &outHandle);
		if (ret != ERROR_SUCCESS) {
			throw gcnew InvalidHandleException("Error intializing native Wi-Fi API.");
		}
		handle_ = outHandle;

		// callback
		using namespace System::Runtime::InteropServices;
		auto fp = gcnew WlanCallbackDelegate(this, &NativeWifiManager::AcmCallbackHandler);
		auto gchandle = GCHandle::Alloc(fp);
		auto ip = Marshal::GetFunctionPointerForDelegate(fp);
		WlanRegisterNotification(handle_, WLAN_NOTIFICATION_SOURCE_ACM, TRUE, static_cast<WLAN_NOTIFICATION_CALLBACK>(ip.ToPointer()),
			nullptr, nullptr, nullptr);
	}

	NativeWifiManager::~NativeWifiManager() {
		this->!NativeWifiManager();
	}

	NativeWifiManager::!NativeWifiManager() {
		if (handle_ == INVALID_HANDLE_VALUE) {
			WlanCloseHandle(handle_, nullptr);
			handle_ = INVALID_HANDLE_VALUE;
		}
	}

	auto NativeWifiManager::EnumInterfaces() ->array<InterfaceInfo^>^ {
		CheckHandleValid();
		PWLAN_INTERFACE_INFO_LIST nfo;
		utils::CheckWinError(WlanEnumInterfaces(handle_, NULL, &nfo));
		auto const nform = saylor::WifiMemoryDeleter<WLAN_INTERFACE_INFO_LIST>::make_unique(nfo);

		auto ifaces = nfo->InterfaceInfo;		
		auto ret = gcnew array<InterfaceInfo^>(nfo->dwNumberOfItems);
		for (DWORD i = 0; i < nfo->dwNumberOfItems; ++i) {
			ret[i] = gcnew InterfaceInfo(
				ifaces[i].InterfaceGuid,
				gcnew System::String(ifaces[i].strInterfaceDescription),
				handle_);
		}

		return ret;
	}

	auto NativeWifiManager::TriggerScan(InterfaceInfo^ iface) -> void {
		CheckHandleValid();
		utils::CheckWinError(WlanScan(handle_, iface->nativeGuid_, nullptr, nullptr, nullptr));
	}

	auto NativeWifiManager::GetAvailableNetworks(InterfaceInfo^ iface)->array<WifiNetwork^>^ {
		auto res = utils::NativeWifi::WifiNetworkListCombo(handle_, *iface->nativeGuid_);
		utils::CheckWinError(res.first);

		auto ret = gcnew array<WifiNetwork^>(res.second->bssids.size());
		for (size_t i = 0; i < res.second->bssids.size(); ++i) {
			auto const& bssid = res.second->bssids[i];
			ret[i] = gcnew WifiNetwork(bssid.rssi, bssid.link_quality, bssid.center_freq,
				bssid.bssid.data, bssid.ssid, res.second->ssid_profile_name_map[bssid.ssid]);
		}
		return ret;
	}

	auto NativeWifiManager::Connect(InterfaceInfo^ iface, WifiNetwork^ net) -> void {
		if (!net->profile_) {
			throw gcnew System::InvalidOperationException("No profile defined for this wireless network.");
		}

		DOT11_BSSID_LIST bssids;
		memset(&bssids, 0, sizeof(bssids));
		bssids.Header.Revision = DOT11_BSSID_LIST_REVISION_1;
		bssids.Header.Type = NDIS_OBJECT_TYPE_DEFAULT;
		bssids.Header.Size = sizeof(DOT11_BSSID_LIST);
		bssids.uNumOfEntries = bssids.uTotalNumOfEntries = 1;
		for (int i = 0; i < 6; ++i) {
			bssids.BSSIDs[0][i] = net->BSSID[i];
		}

		DOT11_SSID ssid;
		memcpy(ssid.ucSSID, "OPTUS_5F4FFE_5GHz", 18);
		ssid.uSSIDLength = 17;
		
		WLAN_CONNECTION_PARAMETERS param;
		memset(&param, 0, sizeof(param));
		param.wlanConnectionMode = wlan_connection_mode_profile;
		param.strProfile = net->profile_->c_str();
		param.dot11BssType = dot11_BSS_type_any;
		param.pDesiredBssidList = &bssids;
		
		utils::CheckWinError(WlanConnect(handle_, iface->nativeGuid_, &param, nullptr));
	}

	auto NativeWifiManager::CheckHandleValid() -> void {
		if (handle_ == INVALID_HANDLE_VALUE) {
			throw gcnew System::InvalidOperationException(
				"Object does not contain a valid handle to native Wi-Fi API.");
		}
	}

	auto NativeWifiManager::AcmCallbackHandler(PWLAN_NOTIFICATION_DATA data, PVOID)->VOID {
		if (data->NotificationSource == WLAN_NOTIFICATION_SOURCE_ACM) {
			OnWifiAcm(static_cast<WifiAcmNotificationCode>(data->NotificationCode), nullptr);
		}
	}
}