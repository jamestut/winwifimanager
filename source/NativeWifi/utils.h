#pragma once

#include <Windows.h>
#include <wlanapi.h>
#include <cstdint>
#include <memory>
#include "exceptions.h"

namespace utils {
	auto NativeGuidToManagedGuid(GUID const& guid) -> System::Guid^;

	auto MacToManagedArray(DOT11_MAC_ADDRESS)->array<byte>^;
	
	auto CheckWinError(DWORD res) -> void;
} // namespace