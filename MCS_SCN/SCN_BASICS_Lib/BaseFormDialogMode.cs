﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BarReader = HTN.BITS.MCS.SCN.LIB.Scanner.clsBarcodeReader;
using Intermec.DataCollection;

namespace HTN.BITS.MCS.SCN.LIB
{
    public partial class BaseFormDialogMode : LocalizedForm
    {
        public BaseFormDialogMode()
        {
            InitializeComponent();
        }

        public void UpdateResourcesInForm(string lanuage)
        {
            try
            {
                if (lanuage == "fr-CA")
                    lanuage = "ja-JP";//"en-GB";
                ResourceManager.Instance.Culture = new System.Globalization.CultureInfo(lanuage);

                base.UpdateResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}