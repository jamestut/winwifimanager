using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BssidSwitcher
{
    class FormMainUiState : INotifyPropertyChanged
    {
        private Control Owner_;

        public FormMainUiState(Control owner)
        {
            Owner_ = owner;
        }

        private bool IsScanning_ = false;
        public bool IsScanning
        {
            set
            {
                IsScanning_ = value;
                InvokePropertyChangeEvent("HasActivity");
                InvokePropertyChangeEvent("HasNoActivity");
                InvokePropertyChangeEvent("EnableUIElements");
            }
        }

        public bool HasActivity
        {
            get
            {
                return IsScanning_;
            }
        }

        public bool HasNoActivity
        {
            get { return !HasActivity; }
        }

        private object SelectedInterface_ = null;
        public object SelectedInterface
        {
            get { return SelectedInterface_; }
            set
            {
                SelectedInterface_ = value;
                InvokePropertyChangeEvent("SelectedInterfaceIndex");
                InvokePropertyChangeEvent("EnableUIElements");
            }
        }

        public bool EnableUIElements
        {
            get { return !HasActivity && (SelectedInterface_ != null); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChangeEvent(string propName)
        {
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
