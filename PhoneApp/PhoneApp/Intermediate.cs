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
using Android.Preferences;


namespace PhoneApp
{
	[Activity (Label = "Intermediate")]	
	public class Intermediate : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Intermediate);

			int nextlevel = GetPrefs ("currentlevel")+1;
			int numoflevels = GetPrefs ("numberoflevels");
			SetPrefs("currentlevel", nextlevel);

			if (nextlevel > numoflevels) {
				Console.WriteLine (nextlevel);
				nextlevel = nextlevel % numoflevels;
				Console.WriteLine (nextlevel);
				if (nextlevel == 0) {
					nextlevel = 3;
				}
			}

			switch (nextlevel) {
			case 1:
				StartActivity (typeof(PressButton));
				break;
			case 2:
				StartActivity (typeof(PickupLines));
				break;
			case 3:
				StartActivity (typeof(Steady));
				break;
			}
				

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

