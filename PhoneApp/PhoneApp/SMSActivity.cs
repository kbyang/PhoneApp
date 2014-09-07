
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
using Android.Telephony;

namespace PhoneApp
{
	[Activity (Label = "SMSActivity")]			
	public class SMSActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SMSLayout);

//			this.Window.SetSoftInputMode(
//				WindowManager.Handle.);

			Button submitButton = FindViewById<Button>(Resource.Id.submitButton);
			submitButton.Click += delegate {
				EditText e = FindViewById<EditText>(Resource.Id.phoneNumberForm);
				string phoneNumber = e.Text;
				if( phoneNumber == null || phoneNumber.Length != 10)
				{
//					Toast.MakeText(this, "phone number must be 10 digits!", ToastLength.Short);
					Console.WriteLine("phone number not long");
					e.Text = "";
				}
				else
				{
					SmsManager.Default.SendTextMessage("2488918624", null, "Hey, I inputted your number into Stagger the app because I love you! Will you have dirty sex with me?", null, null);
				}
			};
		}
	}
}