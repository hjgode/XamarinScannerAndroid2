using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Honeywell.AIDC.CrossPlatform;
using System;
using System.Threading.Tasks;

/// <summary>
/// Design Note: The Xamarin Projet and Project properties can only have alphanumeric characters in their names. 
/// If special characters, spaces, or underscores are in the names the Honeywell.AIDC.CrossPlatform SDK will not
/// return the scanner devices when passed the activity context.
/// </summary>
namespace XamarinScanner_Android
{
    [Activity(Label = "Xamarin Scanner for Android", MainLauncher = false)]
    public class MainActivity : Activity
    {
        
        Android.Content.Context context = Android.App.Application.Context;
        AlertDialog.Builder genericAlert = null;
        ArrayAdapter adapter = null;
        System.Collections.Generic.IList<string> scanList = null;
        
        
        Spinner selectScanner = null;
        Android.Widget.Switch openScanner = null;
        public TextView scanData = null;
        Button scanButton = null;
        Button symConfig = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ScannerCode.Log("OnCreate...");
            ScannerCode.ScanCount = 0;
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            


            selectScanner = FindViewById<Spinner>(Resource.Id.openReaderSpinner);
            openScanner = FindViewById<Android.Widget.Switch>(Resource.Id.openScannerSwitch);
            scanData = FindViewById<TextView>(Resource.Id.scanDataView);
            scanButton = FindViewById<Button>(Resource.Id.scanButton);
            symConfig = FindViewById<Button>(Resource.Id.config_symbologies);
            symConfig.Click += SymConfig_Click;
            scanButton.Click += ScanButton_Click;
            selectScanner.ItemSelected += SelectScanner_ItemSelected;
            openScanner.CheckedChange += OpenScanner_CheckedChange;
            //pass the context of this activity to the ScannCode class
            ScannerCode.AppContext = this.context;

            // Register ScanCode events from static instance
            ScannerCode.Log("Attach Scan_Result_Event...");


            getReaderList();

            
        }

        private void SymConfig_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Symbologies));
            StartActivity(intent);
        }

        /// <summary>
        /// When the ScanPage is about to go to the background, release the
        /// scanner.
        /// </summary>
        protected override void OnPause()
        {
            ScannerCode.Log("OnPause()...");
            base.OnPause();
            ScannerCode.CloseBarcodeScanner();
            ScannerCode.Update_Event -= On_Update_Event;
            ScannerCode.Scan_Result_Event -= On_Result_Event;
        }

        /// <summary>
        /// When the ScanPage is about to go to the foreground, claim the
        /// scanner.
        /// </summary>
        protected override void OnResume()
        {
            ScannerCode.Log("OnResume()...");
            base.OnResume();
            ScannerCode.OpenBarcodeReader();
            ScannerCode.Scan_Result_Event += new ScannerCode.ScanResult(On_Result_Event);
            ScannerCode.Update_Event += new ScannerCode.UpdateControls(On_Update_Event);

            //lock the orientationt to Portrait
            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
        }

       

        /// <summary>
        /// Toggles the reader object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenScanner_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            ScannerCode.mOpenReader = e.IsChecked;
            if(ScannerCode.mOpenReader)
            {
                ScannerCode.OpenBarcodeReader();
            }
            else
            {
                ScannerCode.CloseBarcodeScanner();
            }
        }

        /// <summary>
        /// Allows Updates to the UI controls from the ScanCode class
        /// </summary>
        /// <param name="bscanButton"></param>
        /// <param name="bscanSpinner"></param>
        /// <param name="strViewText"></param>
        public void On_Update_Event(bool bscanButton, bool bscanSpinner, bool syConfig, bool bOpenbtn, string strViewText)
        {
            ScannerCode.Log("On_Update_Event...");
            this.RunOnUiThread(() =>
            {
                scanButton.Enabled = bscanButton;
                selectScanner.Enabled = bscanSpinner;
                symConfig.Enabled = syConfig;
                openScanner.Checked = bOpenbtn;

            });
        }

        /// <summary>
        /// Allows you to pass the scanned data form the ScannerCode.cs to the TextView on this Activity
        /// </summary>
        /// <param name="Result"></param>
        public void On_Result_Event(string Result)//Changed Scan Result event from static instance
        {
            ScannerCode.Log("Called On_Result_Event..., ScanCount=" + ScannerCode.ScanCount.ToString());
            this.RunOnUiThread(() => {//Changed Invoke UI Thread
                scanData.SetText(Result, TextView.BufferType.Normal);
            });
            
        }

        /// <summary>
        /// Allows you to select the desired reader from a list of reader devices. If no external scanners are connected 
        /// you will only have one scanner in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectScanner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            ScannerCode.selectedScanneName = selectScanner.SelectedItem.ToString();
        }            

        /// <summary>
        /// initiates a software trigger scan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanButton_Click(object sender, EventArgs e)
        {
            
            ScannerCode.onScanButtonCLicked(scanData);
        }

        /// <summary>
        /// gets all the scanner devices in the device list and populates the picker
        /// </summary>
        private async void getReaderList()
        {
            //PopulateReaderPicker with the available scanners            
            scanList = await ScannerCode.PopulateReaderPicker();
            if (scanList.Count > 0)
            {
                adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, (List<string>)scanList);
                adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                selectScanner.Adapter = adapter;
                selectScanner.SetSelection(0);
                ScannerCode.selectedScanneName = selectScanner.SelectedItem.ToString();
            }            
        }
        
        /// <summary>
        /// Displays alert messages
        /// </summary>
        /// <param name="Titie"></param>
        /// <param name="Msg"></param>
        private void DisplayAlert(string Titie, string Msg)
        {
            genericAlert = new AlertDialog.Builder(this);
            genericAlert.SetTitle(Title);
            genericAlert.SetMessage(Msg);
            genericAlert.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = genericAlert.Create();
            dialog.Show();
        }

       
    }   
     
}

