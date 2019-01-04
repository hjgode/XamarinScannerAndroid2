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
    [Activity(Label = "Activity1", MainLauncher = true)]
    public class Activity1 : Activity
    {
        Button btnScanner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity1);
            btnScanner = FindViewById<Button>(Resource.Id.button1);
            btnScanner.Click += BtnScanner_Click;
        }

        private void BtnScanner_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}