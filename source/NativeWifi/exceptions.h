#pragma once

#include "utils.h"
#include "macros.h"

namespace NativeWifi {
	public ref class InvalidHandleException : public System::Exception {
	public:
		InvalidHandleException(System::String^ what) : System::Exception(what) {}
	};

	public ref class NativeWifiException : public System::Exception {
		TRIVIAL_PROPERTY(ErrorCode, ErrorCode_, int, public, private)
		
	public:
		NativeWifiException(int errorCode) : ErrorCode_{errorCode} {}
	};
}