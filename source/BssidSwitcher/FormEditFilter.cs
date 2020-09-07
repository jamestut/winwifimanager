using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BssidSwitcher
{
    public partial class FormEditFilter : Form
    {
        public FormEditFilter()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormEditFilter_Load(object sender, EventArgs e)
        {
            ssidNameFilter.DataBindings.Add(new Binding("Enabled", optSsidContains, "Checked"));
            ssidNameFilter.DataBindings.Add(new Binding("Text", Filter.Instance, "NameFilterString"));
            optProfileOnly.DataBindings.Add(new Binding("Checked", Filter.Instance, "ProfileOnly"));

            switch(Filter.Instance.Band)
            {
                case Filter.BandKind.Any:
                    optBandAny.Checked = true;
                    break;
                case Filter.BandKind.BandA:
                    optBandA.Checked = true;
                    break;
                case Filter.BandKind.BandB:
                    optBandB.Checked = true;
                    break;
            }

            switch(Filter.Instance.NameFilter)
            {
                case Filter.NameFilterKind.Any:
                    optSsidAny.Checked = true;
                    break;
                case Filter.NameFilterKind.CurrentlyConnected:
                    optSsidCurrentConnected.Checked = true;
                    break;
                case Filter.NameFilterKind.NameContains:
                    optSsidContains.Checked = true;
                    break;
            }
        }

        private void optBandAny_CheckedChanged(object sender, EventArgs e)
        {
            Filter.Instance.Band = Filter.BandKind.Any;
        }

        private void optBandB_CheckedChanged(object sender, EventArgs e)
        {
            Filter.Instance.Band = Filter.BandKind.BandB;
        }

        private void optBandA_CheckedChanged(object sender, EventArgs e)
        {
            Filter.Instance.Band = Filter.BandKind.BandA;
        }

        private void optSsidAny_CheckedChanged(object sender, EventArgs e)
        {
            Filter.Instance.NameFilter = Filter.NameFilterKind.Any;
        }

        private void optSsidCurrentConnected_CheckedChanged(object sender, EventArgs e)
        {
            Filter.Instance.NameFilter = Filter.NameFilterKind.CurrentlyConnected;
        }

        private void optSsidContains_CheckedChanged(object sender, EventArgs e)
        {
            Filter.Instance.NameFilter = Filter.NameFilterKind.NameContains;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Filter.Instance.Reset();
            Close();
        }
    }
}
