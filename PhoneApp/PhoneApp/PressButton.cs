
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PhoneApp
{
	[Activity (Label = "PressButton")]			
	public class PressButton : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			Button pressbutton;
			string click = "Great Job!";
			TextView resultbutton;

			base.OnCreate (bundle);


			SetContentView (Resource.Layout.PressButton);
			// Create your application here
			resultbutton = (TextView)FindViewById(Resource.Id.resultbuttonclick);

			pressbutton = (Button)FindViewById(Resource.Id.buttonpress);

			pressbutton.Click += (object sender, EventArgs e) => {
				resultbutton.Text = click;
				nextActivity(true);
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
	}
}

