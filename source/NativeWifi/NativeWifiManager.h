#pragma once

#include "NativeWifiProperties.h"
#include "utils.h"
#include <cstdint>
#include <string>
#include <wlanapi.h>

//using namespace System;

namespace NativeWifi {
	public enum class WifiAcmNotificationCode {
		AutoconfEnabled = wlan_notification_acm_autoconf_enabled,
		AutoconfDisabled = wlan_notification_acm_autoconf_disabled,
		BgScanEnabled = wlan_notification_acm_background_scan_enabled,
		BgScanDisabled = wlan_notification_acm_background_scan_disabled,
		BssTypeChange = wlan_notification_acm_bss_type_change,
		PowerSettingChange = wlan_notification_acm_power_setting_change,
		ScanComplete = wlan_notification_acm_scan_complete,
		ScanFail = wlan_notification_acm_scan_fail,
		ConnectionStart = wlan_notification_acm_connection_start,
		ConnectionComplete = wlan_notification_acm_connection_complete,
		ConnectionAttemptFail = wlan_notification_acm_connection_attempt_fail,
		FilterListChange = wlan_notification_acm_filter_list_change,
		InterfaceArrival = wlan_notification_acm_interface_arrival,
		InterfaceRemoval = wlan_notification_acm_interface_removal,
		ProfileChange = wlan_notification_acm_profile_change,
		ProfileNameChange = wlan_notification_acm_profile_name_change,
		ProfilesExhausted = wlan_notification_acm_profiles_exhausted,
		NetworkNotAvailable = wlan_notification_acm_network_not_available,
		NetworkAvailable = wlan_notification_acm_network_available,
		Disconnecting = wlan_notification_acm_disconnecting,
		Disconnected = wlan_notification_acm_disconnected,
		NetworkStateChange = wlan_notification_acm_adhoc_network_state_change,
		ProfileUnblocked = wlan_notification_acm_profile_unblocked,
		ScreenPowerChange = wlan_notification_acm_screen_power_change,
		ProfileBlocked = wlan_notification_acm_profile_blocked,
		ScanListRefresh = wlan_notification_acm_scan_list_refresh
	};

	public delegate void WifiAcmEventHandlerDelegate(WifiAcmNotificationCode code, System::Object^ data);

	public ref class WifiNetwork {
		TRIVIAL_PROPERTY(RSSI, RSSI_, LONG, public, private)
		TRIVIAL_PROPERTY(LinkQuality, LinkQuality_, ULONG, public, private)
		TRIVIAL_PROPERTY(CenterFrequency, Freq_, ULONG, public, private)
		TRIVIAL_PROPERTY(BSSID, BSSID_, array<uint8_t>^, public, private)
		TRIVIAL_PROPERTY(SSID, SSID_, System::String^, public, private)

	public:
		~WifiNetwork();

		!WifiNetwork();

		property System::String^ ProfileName {
			auto get()->System::String^;
		}

	internal:
		std::wstring* profile_;
		System::String^ profileMan_;

		WifiNetwork(LONG rssi, ULONG linkQual, ULONG freq, const uint8_t* bssid, 
			DOT11_SSID const& ssid, std::wstring const& profile);
	};
	
	public ref class NativeWifiManager
	{
	public:
		NativeWifiManager();

		~NativeWifiManager();

		!NativeWifiManager();

		event WifiAcmEventHandlerDelegate^ OnWifiAcm;

		auto EnumInterfaces() -> array<InterfaceInfo^>^;

		auto TriggerScan(InterfaceInfo^ iface) -> void;

		auto GetAvailableNetworks(InterfaceInfo^ iface)->array<WifiNetwork^>^;

		auto Connect(InterfaceInfo^ iface, WifiNetwork^ network) -> void;

	private:
		HANDLE handle_ = INVALID_HANDLE_VALUE;

		auto CheckHandleValid() -> void;

		auto AcmCallbackHandler(PWLAN_NOTIFICATION_DATA, PVOID)->VOID;
	};
}
