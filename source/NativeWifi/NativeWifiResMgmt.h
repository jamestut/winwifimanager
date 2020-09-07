#pragma once

#include <wlanapi.h>

namespace saylor {
	template<typename T>
	class WifiMemoryDeleter {
	public:
		auto operator()(T* obj) const noexcept {
			WlanFreeMemory(obj);
		}

		static auto make_shared(T* ptr) {
			return std::shared_ptr<T>(ptr, WifiMemoryDeleter());
		}

		static auto make_unique(T* ptr) {
			return std::unique_ptr<T, WifiMemoryDeleter>(ptr);
		}
	};
}
