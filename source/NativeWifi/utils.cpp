#include "pch.h"
#include "utils.h"

namespace utils {
	namespace {
		union GuidUn {
			GUID guid;
			struct {
				uint32_t a;
				uint16_t b[2];
				uint8_t c[8];
			} sep;
			uint8_t arr[16];
		};
	}

	auto NativeGuidToManagedGuid(GUID const& guid) -> System::Guid^ {
		GuidUn g;
		g.guid = guid;
		return gcnew System::Guid(g.sep.a, g.sep.b[0], g.sep.b[1],
			g.sep.c[0], g.sep.c[1], g.sep.c[2], g.sep.c[3],
			g.sep.c[4], g.sep.c[5], g.sep.c[6], g.sep.c[7]);
	}

	auto MacToManagedArray(DOT11_MAC_ADDRESS addr)->array<byte>^ {
		auto ret = gcnew array<byte>(6);
		for (int i = 0; i < 6; ++i) {
			ret[i] = addr[i];
		}
		return ret;
	}

	auto CheckWinError(DWORD res) -> void {
		if (res != ERROR_SUCCESS) {
			throw gcnew NativeWifi::NativeWifiException(res);
		}
	}
}