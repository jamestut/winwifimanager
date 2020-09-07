using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BssidSwitcher
{
    class Filter
    {
        public static Filter Instance { get; private set; } = new Filter();

        public enum BandKind{Any, BandA, BandB};
        public enum NameFilterKind { Any, CurrentlyConnected, NameContains };

        public BandKind Band { get; set; }
        public NameFilterKind NameFilter { get; set; }
        public string NameFilterString { get; set; }
        public string ConnectedProfileName { get; set; }
        public bool ProfileOnly { get; set; }

        private Filter() { Reset(); }

        public void Reset()
        {
            Band = BandKind.Any;
            NameFilter = NameFilterKind.Any;
            NameFilterString = "";
            ProfileOnly = false;
        }

        public bool Match(NativeWifi.WifiNetwork network)
        {
            return MatchBand(network) && MatchName(network) && MatchProfileOnly(network);
        }

        private bool MatchBand(NativeWifi.WifiNetwork network)
        {
            switch(Band)
            {
                case BandKind.BandA:
                    return network.CenterFrequency > 2600000;
                case BandKind.BandB:
                    return network.CenterFrequency < 2600000;
                default:
                    return true;
            }
        }

        private bool MatchName(NativeWifi.WifiNetwork network)
        {
            switch(NameFilter)
            {
                case NameFilterKind.CurrentlyConnected:
                    return network.ProfileName != null 
                        && ConnectedProfileName != null 
                        && network.ProfileName == ConnectedProfileName;
                case NameFilterKind.NameContains:
                    return network.SSID.ToLower().Contains(NameFilterString.ToLower());
                default:
                    return true;
            }
        }

        private bool MatchProfileOnly(NativeWifi.WifiNetwork network)
        {
            if(ProfileOnly)
                return network.ProfileName != null;
            return true;
        }
    }
}
