﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Lab1
{
    [Activity(Label = "Lab1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button button;
        TextView textviewDev;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button>(Resource.Id.MyButton);
            textviewDev = FindViewById<TextView>(Resource.Id.textViewDev);

            button.Click += Button_Click;


            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            textviewDev.Text = "Insertar tu nombre";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            XamarinDiplomado.ServiceHelper helper = new XamarinDiplomado.ServiceHelper();
            await helper.InsertarEntidad("grod2145@gmail.com", "Lab1", myDevice);
            button.Text = "Gracias por completar el Lab1";
        }
    }
}

