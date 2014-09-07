using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Preferences;

namespace PhoneApp
{
	[Activity (Label = "PhoneApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//set current level and number of levels
			int currentlevel = 1;
			int numberoflevels = 3;
			SetPrefs("currentlevel", currentlevel);
			SetPrefs ("numberoflevels", numberoflevels);


			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
//				button.Text = string.Format ("{0} clicks!", count++);
				StartActivity(typeof(PickupLines));
			};
		}

		public static void SetPrefs(string prefname, int prefvalue)
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
			ISharedPreferencesEditor pref_edit = prefs.Edit ();
			pref_edit.PutInt(prefname, prefvalue);
			pref_edit.Commit();
		}

		public static int GetPrefs(string prefname)
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			return prefs.GetInt(prefname, 1);
		}
	}
}


