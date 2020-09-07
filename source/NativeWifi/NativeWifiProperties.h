#pragma once

#include <Windows.h>
#include <wlanapi.h>
#include <cstdint>
#include <memory>
#include "utils.h"
#include "macros.h"

namespace NativeWifi {
	public enum class InterfaceState {
		NotReady = wlan_interface_state_not_ready,
		Connected = wlan_interface_state_connected,
		AdHocNetworkFormed = wlan_interface_state_ad_hoc_network_formed,
		Disconnecting = wlan_interface_state_disconnecting,
		Disconnected = wlan_interface_state_disconnected,
		Associating = wlan_interface_state_associating,
		Discovering = wlan_interface_state_discovering,
		Authenticating = wlan_interface_state_authenticating
	};

	public enum class ConnectionMode {
		Profile = wlan_connection_mode_profile,
		TempProfile = wlan_connection_mode_temporary_profile,
		DiscoverySecure = wlan_connection_mode_discovery_secure,
		DisconveryUnsecure = wlan_connection_mode_discovery_unsecure,
		ModeAuto = wlan_connection_mode_auto,
		Invalid = wlan_connection_mode_invalid
	};

	public enum class BssKind {
		Infrastructure = dot11_BSS_type_infrastructure,
		Independent = dot11_BSS_type_independent,
		Any = dot11_BSS_type_any
	};

	public ref struct ConnectionInfo {
		TRIVIAL_PROPERTY(Mode, Mode_, ConnectionMode, public, private)
		TRIVIAL_PROPERTY(ProfileName, ProfileName_, System::String^, public, private)
		TRIVIAL_PROPERTY(SSID, SSID_, System::String^, public, private)
		TRIVIAL_PROPERTY(BSSID, BSSID_, array<byte>^, public, private)
		TRIVIAL_PROPERTY(SignalQuality, SignalQuality_, unsigned int, public, private)
		TRIVIAL_PROPERTY(RxRate, RxRate_, unsigned int, public, private)
		TRIVIAL_PROPERTY(TxRate, TxRate_, unsigned int, public, private)

	public:
		ConnectionInfo(ConnectionMode mode, System::String^ profile, System::String^ ssid,
			array<byte>^ bssid, unsigned int css, unsigned int rxRate, unsigned int txRate) :
			Mode_{ mode }, ProfileName_{ profile }, SSID_{ ssid },
			SignalQuality_{ css }, RxRate_{ rxRate }, TxRate_{ txRate } 
		{
			BSSID_ = bssid;
		}
	};

	public ref class InterfaceInfo {
		TRIVIAL_PROPERTY(Guid, Guid_, System::Guid^, public, private)
		TRIVIAL_PROPERTY(Name, Name_, System::String^, public, private)

	public:
		property bool AutoconfEnabled {public: auto get() -> bool; }
		property bool BgScanEnabled {public: auto get() -> bool; }
		property BssKind BssType {public: auto get()->BssKind; }
		property InterfaceState State {public: auto get()->InterfaceState; }
		property unsigned int ChannelNumber {public: auto get()->unsigned int; }
		property int RSSI {public: auto get()->int; }
		property ConnectionInfo^ CurrentConnection {public: auto get()->ConnectionInfo^; }

		virtual System::String^ ToString() override;

	internal:
		InterfaceInfo(GUID const& guid, System::String^ name, HANDLE handle);

		~InterfaceInfo();

		!InterfaceInfo();

		GUID* nativeGuid_;

	private:
		// for retreiving dynamic properties
		HANDLE handle_;

		auto CheckState() -> void;
	};
} // namespace