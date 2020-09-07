#pragma once

#include <Windows.h>
#include <exception>

class WinErrorExcept : public std::exception {
public:
	WinErrorExcept(DWORD const dwError) noexcept : error_code{ dwError } {};

	static auto check_error(DWORD const err) {
		if (err != ERROR_SUCCESS) {
			throw WinErrorExcept(err);
		}
	}

	const DWORD error_code;
};