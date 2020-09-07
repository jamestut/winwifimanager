using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BssidSwitcher
{
    class Utils
    {
        public static string MacStringify(byte[] mac)
        {
            if(mac.Length != 6)
            {
                throw new ArgumentException("MAC address not valid");
            }
            return string.Join(":", from m in mac select m.ToString("X2"));
        }

        public static void RunInUIThread(Control ctrl, Action action)
        {
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
