#include "pch.h"
#include "NativeWifiHelper.h"
#include "NativeWifiResMgmt.h"
#include <algorithm>

namespace utils {
	namespace NativeWifi {
		auto WifiNetworkListCombo(HANDLE const handle, GUID const& iface)->std::pair<DWORD, std::unique_ptr<WifiNetworkList>> {
			DWORD err;
			std::unique_ptr<WifiNetworkList> ret;
			
			// query native data first
			PWLAN_AVAILABLE_NETWORK_LIST_V2 netList;
			err = WlanGetAvailableNetworkList2(handle, &iface, 0, NULL, &netList);
			if (err != ERROR_SUCCESS) {
				return { err,std::move(ret) };
			}
			auto netListRaii = saylor::WifiMemoryDeleter<WLAN_AVAILABLE_NETWORK_LIST_V2>::make_unique(netList);

			PWLAN_BSS_LIST bssList;
			err = WlanGetNetworkBssList(handle, &iface, nullptr, dot11_BSS_type_infrastructure, 0, nullptr, &bssList);
			if (err != ERROR_SUCCESS) {
				return { err,std::move(ret) };
			}
			auto bssListRaii = saylor::WifiMemoryDeleter<WLAN_BSS_LIST>::make_unique(bssList);

			// return value
			ret = std::make_unique<WifiNetworkList>();

			// scan for SSIDs
			std::for_each(netList->Network, netList->Network + netList->dwNumberOfItems, [&ret](auto const& net) {
				if (!ret->ssid_profile_name_map.count(net.dot11Ssid)) {
					ret->ssid_profile_name_map[net.dot11Ssid] = net.strProfileName;
				}
				else if (*net.strProfileName) {
					// if the current SSID does not have an associated profile yet, override
					if (!ret->ssid_profile_name_map[net.dot11Ssid][0]) {
						ret->ssid_profile_name_map[net.dot11Ssid] = net.strProfileName;
					}
				}
			});

			// arrange the BSSIDs
			ret->bssids.reserve(bssList->dwNumberOfItems);
			std::for_each(bssList->wlanBssEntries, bssList->wlanBssEntries + bssList->dwNumberOfItems, [&ret](auto const& bss) {
				ret->ssid_profile_name_map[bss.dot11Ssid];
				auto const& ssidLocal = ret->ssid_profile_name_map.find(bss.dot11Ssid)->first;
				ret->bssids.emplace_back(ssidLocal, bss.dot11Bssid, bss.lRssi, bss.uLinkQuality, bss.ulChCenterFrequency);
			});

			return { ERROR_SUCCESS, std::move(ret) };
		}

		auto priv::SsidHash::operator()(DOT11_SSID const& v) const->size_t {
			size_t ret = 5381;
			for (int i = 0; i < v.uSSIDLength; ++i) {
				ret = ((ret << 5ULL) + ret) + static_cast<size_t>(v.ucSSID[i]);
			}
			return ret;
		}

		auto priv::SsidEqual::operator()(DOT11_SSID const& lhs, DOT11_SSID const& rhs) const -> bool {
			return (lhs.uSSIDLength == rhs.uSSIDLength) && (memcmp(lhs.ucSSID, rhs.ucSSID, lhs.uSSIDLength) == 0);
		}

		MacAddress::MacAddress(const DOT11_MAC_ADDRESS p) { memcpy(data, p, 6); }

		BssEntry::BssEntry(DOT11_SSID const& ssid_, MacAddress bssid_, LONG rssi_, ULONG link_quality_, ULONG center_freq_) :
			ssid{ ssid_ }, bssid{ bssid_ }, rssi{ rssi_ }, link_quality{ link_quality_ }, center_freq{ center_freq_ } {}
	}
}