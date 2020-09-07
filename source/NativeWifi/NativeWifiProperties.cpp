#include "pch.h"
#include "NativeWifiProperties.h"
#include "NativeWifiResMgmt.h"
#include "utils.h"

namespace NativeWifi {

	namespace {
		template<typename T>
		auto WlanQuerySimpleInterface(HANDLE handle, GUID* guid, WLAN_INTF_OPCODE opcode)->T {
			PVOID retPtr;
			DWORD retSz;
			utils::CheckWinError(WlanQueryInterface(handle, guid, opcode, nullptr,
				&retSz, &retPtr, nullptr));
			auto const retResMgmt = saylor::WifiMemoryDeleter<T>::make_unique(static_cast<T*>(retPtr));
			return *retResMgmt;
		}
	}

	InterfaceInfo::InterfaceInfo(GUID const& guid, System::String^ name, HANDLE handle) :
		Name_{ name },
		handle_{ handle } 
	{
		Guid_ = utils::NativeGuidToManagedGuid(guid);
		nativeGuid_ = new GUID(guid);
	}

	InterfaceInfo::~InterfaceInfo() {
		this->!InterfaceInfo();
	}

	InterfaceInfo::!InterfaceInfo() {
		delete nativeGuid_;
		nativeGuid_ = nullptr;
	}

	auto InterfaceInfo::ToString() -> System::String^ {
		return Name_;
	}

	auto InterfaceInfo::AutoconfEnabled::get() -> bool {
		CheckState();
		return WlanQuerySimpleInterface<BOOL>(handle_, nativeGuid_, wlan_intf_opcode_autoconf_enabled);
	}

	auto InterfaceInfo::BgScanEnabled::get() -> bool {
		CheckState();
		return WlanQuerySimpleInterface<BOOL>(handle_, nativeGuid_, wlan_intf_opcode_background_scan_enabled);
	}

	auto InterfaceInfo::BssType::get() -> BssKind {
		CheckState();
		return static_cast<BssKind>(WlanQuerySimpleInterface<DOT11_BSS_TYPE>(handle_, nativeGuid_, wlan_intf_opcode_bss_type));
	}

	auto InterfaceInfo::State::get() -> InterfaceState {
		CheckState();
		return static_cast<InterfaceState>(WlanQuerySimpleInterface<WLAN_INTERFACE_STATE>(handle_, nativeGuid_, wlan_intf_opcode_interface_state));
	}

	auto InterfaceInfo::ChannelNumber::get() -> unsigned int {
		CheckState();
		return WlanQuerySimpleInterface<unsigned int>(handle_, nativeGuid_, wlan_intf_opcode_channel_number);
	}

	auto InterfaceInfo::RSSI::get() -> int {
		CheckState();
		return WlanQuerySimpleInterface<int>(handle_, nativeGuid_, wlan_intf_opcode_rssi);
	}

	auto InterfaceInfo::CurrentConnection::get() -> ConnectionInfo^ {
		CheckState();
		PWLAN_CONNECTION_ATTRIBUTES retPtr;
		DWORD retSz;
		utils::CheckWinError(WlanQueryInterface(handle_, nativeGuid_, wlan_intf_opcode_current_connection,
			nullptr, &retSz, reinterpret_cast<PVOID*>(&retPtr), nullptr));
		auto const retResMgmt = saylor::WifiMemoryDeleter<WLAN_CONNECTION_ATTRIBUTES>::make_unique(static_cast<WLAN_CONNECTION_ATTRIBUTES*>(retPtr));
		
		return gcnew ConnectionInfo(
			static_cast<ConnectionMode>(retPtr->wlanConnectionMode),
			gcnew System::String(retPtr->strProfileName),
			gcnew System::String(reinterpret_cast<char*>(retPtr->wlanAssociationAttributes.dot11Ssid.ucSSID), 0, retPtr->wlanAssociationAttributes.dot11Ssid.uSSIDLength),
			utils::MacToManagedArray(retPtr->wlanAssociationAttributes.dot11Bssid),
			retPtr->wlanAssociationAttributes.wlanSignalQuality,
			retPtr->wlanAssociationAttributes.ulRxRate,
			retPtr->wlanAssociationAttributes.ulTxRate);
	}

	auto InterfaceInfo::CheckState() -> void {
		if (!nativeGuid_) {
			throw gcnew System::InvalidOperationException();
		}
	}
}