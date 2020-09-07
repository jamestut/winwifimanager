#pragma once

#include <string>
#include <unordered_map>
#include <Windows.h>
#include <wlanapi.h>
#include <memory>

namespace utils {
	namespace NativeWifi {
		namespace priv {
			class SsidHash {
			public:
				auto operator()(DOT11_SSID const& v) const->size_t;
			};

			class SsidEqual {
			public:
				auto operator()(DOT11_SSID const& lhs, DOT11_SSID const& rhs) const->bool;
			};
		}

		struct MacAddress {
			DOT11_MAC_ADDRESS data;

			MacAddress(const DOT11_MAC_ADDRESS p);
		};

		struct BssEntry {
			DOT11_SSID const& ssid;
			MacAddress bssid;
			LONG rssi;
			ULONG link_quality;
			ULONG center_freq;

			BssEntry(DOT11_SSID const& ssid_, MacAddress bssid_, LONG rssi_, ULONG link_quality_, ULONG center_freq_);
		};

		struct WifiNetworkList {
			std::unordered_map<DOT11_SSID, std::wstring, priv::SsidHash, priv::SsidEqual> ssid_profile_name_map;
			std::vector<BssEntry> bssids;
		};

		auto WifiNetworkListCombo(HANDLE const handle, GUID const& iface)->std::pair<DWORD,std::unique_ptr<WifiNetworkList>>;
	}
}