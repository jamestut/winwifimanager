#define TRIVIAL_PROPERTY(name,varname,type,getteracc,setteracc) \
	private: type varname; \
	public: property type name { \
		getteracc: type get() { \
			return varname; \
		} \
		setteracc: void set(type val) { \
			varname = val; \
		} \
    }