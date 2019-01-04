using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinScanner_Android
{
    [Activity(Label = "Symbologies")]
    
    public class Symbologies : Activity
    {
        Dictionary<string, object> symbologyButtons = new Dictionary<string, object>();
        Button switch_1 = null;
        Button switch_2 = null;
        Button switch_3 = null;
        Button switch_4 = null;
        Button switch_5 = null;
        Button switch_6 = null;
        Button switch_7 = null;
        Button switch_8 = null;
        Button switch_9 = null;
        Button switch_10 = null;
        Button switch_11 = null;
        Button switch_12 = null;
        Button switch_13 = null;
        Button switch_14 = null;
        Button switch_15 = null;
        Button switch_16 = null;
        Button switch_17 = null;
        Button switch_18 = null;
        Button switch_19 = null;
        Button switch_20 = null;
        Button switch_37 = null;
        Button switch_21 = null;
        Button switch_22 = null;
        Button switch_23 = null;
        Button switch_24 = null;
        Button switch_25 = null;
        Button switch_26 = null;
        Button switch_27 = null;
        Button switch_28 = null;
        Button switch_29 = null;
        Button switch_31 = null;
        Button switch_32 = null;
        EditText editText_33 = null;
        EditText editText_34 = null;
        EditText editText_35 = null;
        EditText editText_36 = null;

        Button saveConfig = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SymbologiesActivity);

            switch_1 = FindViewById<Button>(Resource.Id.switch1);
            switch_2 = FindViewById<Button>(Resource.Id.switch2);
            switch_3 = FindViewById<Button>(Resource.Id.switch3);
            switch_4 = FindViewById<Button>(Resource.Id.switch4);
            switch_5 = FindViewById<Button>(Resource.Id.switch5);
            switch_6 = FindViewById<Button>(Resource.Id.switch6);
            switch_7 = FindViewById<Button>(Resource.Id.switch7);
            switch_8 = FindViewById<Button>(Resource.Id.switch8);
            switch_9 = FindViewById<Button>(Resource.Id.switch9);
            switch_10 = FindViewById<Button>(Resource.Id.switch10);
            switch_11 = FindViewById<Button>(Resource.Id.switch11);
            switch_12 = FindViewById<Button>(Resource.Id.switch12);
            switch_13 = FindViewById<Button>(Resource.Id.switch13);
            switch_14 = FindViewById<Button>(Resource.Id.switch14);
            switch_15 = FindViewById<Button>(Resource.Id.switch15);
            switch_16 = FindViewById<Button>(Resource.Id.switch16);
            switch_17 = FindViewById<Button>(Resource.Id.switch17);
            switch_18 = FindViewById<Button>(Resource.Id.switch18);
            switch_19 = FindViewById<Button>(Resource.Id.switch19);
            switch_20 = FindViewById<Button>(Resource.Id.switch20);
            switch_37 = FindViewById<Button>(Resource.Id.switch37);
            switch_21 = FindViewById<Button>(Resource.Id.switch21);
            switch_22 = FindViewById<Button>(Resource.Id.switch22);
            switch_23 = FindViewById<Button>(Resource.Id.switch23);
            switch_24 = FindViewById<Button>(Resource.Id.switch24);
            switch_25 = FindViewById<Button>(Resource.Id.switch25);
            switch_26 = FindViewById<Button>(Resource.Id.switch26);
            switch_27 = FindViewById<Button>(Resource.Id.switch27);
            switch_28 = FindViewById<Button>(Resource.Id.switch28);
            switch_29 = FindViewById<Button>(Resource.Id.switch29);
            switch_31 = FindViewById<Button>(Resource.Id.switch31);
            switch_32 = FindViewById<Button>(Resource.Id.switch32);
            editText_33 = FindViewById<EditText>(Resource.Id.editText33);
            editText_34 = FindViewById<EditText>(Resource.Id.editText34);
            editText_35 = FindViewById<EditText>(Resource.Id.editText35);
            editText_36 = FindViewById<EditText>(Resource.Id.editText36);

            saveConfig = FindViewById<Button>(Resource.Id.Save_Config_button);
            saveConfig.Click += SaveConfig_Click;

            // If the dictionary for the symbology switchs has not be created, create the dictionary
            if(symbologyButtons.Count == 0)
            {
                CreateButtonDictionary();
            }
            // place the symbology switches in the position that shows their current status.
            ShowCurrentSettings();

            
        }

        /// <summary>
        /// Updates the symbology settings dictionary with any settings changes made in this activity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveConfig_Click(object sender, EventArgs e)
        {
            UpdateSymbologyDictionary();
        }

        /// <summary>
        /// Creates the symbology switch dictionary
        /// Arguments - settingKey of selected scanner, switch widgit
        /// </summary>
        private void CreateButtonDictionary()
        {
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.AztecEnabled, switch_1);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.CodabarEnabled, switch_2);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.CodablockFEnabled, switch_3);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Code11Enabled, switch_4);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Code128Enabled, switch_5);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Code39Enabled, switch_6);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Code93Enabled, switch_7);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.DatamatrixEnabled, switch_8);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Ean8Enabled, switch_9);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Ean13Enabled, switch_10);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Gs1128Enabled, switch_11);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.HanXinEnabled, switch_12);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Iata25Enabled, switch_13);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Interleaved25Enabled, switch_14);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Isbt128Enabled, switch_15);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Matrix25Enabled, switch_16);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.MaxicodeEnabled, switch_17);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.MicroPdf417Enabled, switch_18);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.MsiEnabled, switch_19);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.QrCodeEnabled, switch_20);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Pdf417Enabled, switch_37);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.RssEnabled, switch_21);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.RssExpandedEnabled, switch_22);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.RssLimitedEnabled, switch_23);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Standard25Enabled, switch_24);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.TelepenEnabled, switch_25);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.Tlc39Enabled, switch_26);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.TriopticEnabled, switch_27);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.UpcEEnabled, switch_28);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.UpcAEnable, switch_29);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.VideoReverseEnabled, switch_31);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.CenterDecodeEnabled, switch_32);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.DecodeWindowBottom, editText_33);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.DecodeWindowLeft, editText_34);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.DecodeWindowRight, editText_35);
            symbologyButtons.Add(ScannerCode.mSelectedReader.SettingKeys.DecodeWindowTop, editText_36);
        }

        /// <summary>
        /// Sets the switch and EditText fields to their current values.
        /// </summary>
        private void ShowCurrentSettings()
        {
            foreach(KeyValuePair<string,object> keys in ScannerCode.settings)
            {
                foreach(KeyValuePair<string,object> sym in symbologyButtons)
                {
                    if(keys.Key == sym.Key)
                    {
                        if(sym.Value.ToString().Contains("Switch"))
                        {
                            Switch sw = (Switch)sym.Value;
                            sw.Checked = (bool)keys.Value;
                        }
                        else
                        {
                            EditText tv = (EditText)sym.Value;
                            int num = (Int32)keys.Value;
                            tv.Text = Convert.ToString(num);
                        }
                            
                    }
                }
            }
        }

        /// <summary>
        /// Updates the settings dictionary with the changes made to switch positions and EditText field content,
        /// then enabels the new settings.
        /// </summary>
        private void UpdateSymbologyDictionary()
        {
           foreach(KeyValuePair<string,object> sym in symbologyButtons)
           {
               if(sym.Value.ToString().Contains("Switch"))
               {
                    Switch sw = (Switch)sym.Value;
                    ScannerCode.settings[sym.Key] = sw.Checked;
               }
                else
                {
                    EditText et = (EditText)sym.Value;
                    ScannerCode.settings[sym.Key] = et.Text;
                }
            }

            // Update the settings for the selected scanner
            ScannerCode.EnableSymbologies(); 
        }
    }
}