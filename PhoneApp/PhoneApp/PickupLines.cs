
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
using System.Threading.Tasks;

namespace PhoneApp
{
	[Activity (Label = "PickupLines")]			
	public class PickupLines : Activity
	{
		string[] goodPickupLines = new string[] {"Are you a beaver cuz dam", 
			"Can I take a pic of you so I can show santa what I want for xmas?", 
			"Can I be the tangent line to your curve?"};
		string[] badPickupLines = {"lemme hit doe",
			"meooooww",
			"Wanna come over and code?"};
//		Random rnd = new Random();
//		int goodJokeNum = rnd.Next(1, 4);
//		int badJokeNum = rnd.Next(1, 4);

		protected override void OnCreate (Bundle bundle)
		{
			Button goodView;
			Button badView;
			TextView resultPickup;
			string goodPickup = "NICE ONE";
			string badPickup = "WTF MAN NAWW";
		
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.PickupLines);

			//set current level number
			TextView levelText = (TextView)FindViewById(Resource.Id.level);
			//THIS IS THE CURRENT LEVEL
			int currentlevel = GetPrefs ("currentlevel");
			levelText.Text = "Level " + Java.Lang.String.ValueOf (currentlevel);

		

			//initialize resultPickup text
			resultPickup = (TextView)FindViewById(Resource.Id.resultPickupLine);

			//set good pickup line
			goodView = (Button)FindViewById(Resource.Id.buttonGoodLines);
			goodView.Text = goodPickupLines[0];


			//set bad pickup line
			badView = (Button)FindViewById(Resource.Id.buttonBadLines); 
			badView.Text = badPickupLines[0];

			goodView.Click += (object sender, EventArgs e) => {
				resultPickup.Text = goodPickup;
				nextActivity(true);
			};

			badView.Click += (object sender, EventArgs e) => {
				resultPickup.Text = badPickup;
				nextActivity(false);
			};


		}

		public async void nextActivity(bool passed) {
			await Task.Delay(600);
			if (passed) {
				StartActivity (typeof(Intermediate));
			} else {
				StartActivity (typeof(MainActivity));
			}
		}
			
		public static int GetPrefs(string prefname)
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			return prefs.GetInt(prefname, 1);
		}
	}
}

