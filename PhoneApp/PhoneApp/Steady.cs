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
using Android.Preferences;
using Android.Hardware;



namespace PhoneApp
{
	[Activity (Label = "Steady")]	
	public class Steady : Activity, ISensorEventListener
	{
		private SensorManager _sensorManager;
		private TextView _sensorTextView;
		private static readonly object _syncLock = new object();
		private LinearLayout mainLayout;
		private bool green;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Steady);

			//set level
			int currentlevel = GetPrefs ("currentlevel");

			//display level
			TextView levelText = (TextView)FindViewById(Resource.Id.level);
			levelText.Text = "Level " + Java.Lang.String.ValueOf (currentlevel);

			//set up accelerometer
			_sensorManager = (SensorManager) GetSystemService(Context.SensorService);
			_sensorTextView = FindViewById<TextView>(Resource.Id.data);

			mainLayout = (LinearLayout)FindViewById(Resource.Id.linearLayout1);
			mainLayout.SetBackgroundColor(Android.Graphics.Color.Red);

			green = false;

			checkPass ();
		}

		public async void checkPass() {
			_sensorTextView.Text = "Ready?";
			await Task.Delay(1000);
			_sensorTextView.Text = "Go!";
			await Task.Delay(300);

			int yaypoints = 0;

			for (int i = 5; i > 0; i--) {
				_sensorTextView.Text = Java.Lang.String.ValueOf(i);
				await Task.Delay(1000);
				if (green)
					yaypoints++;
			}

			if (yaypoints >= 3) {
				_sensorTextView.Text = "Passed!";
				await Task.Delay(200);
				nextActivity (true);
			} else {
				_sensorTextView.Text = "Failed :(";
				await Task.Delay(200);
				nextActivity (false);
			}

		}

		public async void nextActivity(bool passed) {
			await Task.Delay(600);
			if (passed) {
				StartActivity (typeof(Intermediate));
			} else {
				StartActivity (typeof(MainActivity));
			}
		}

		public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
		{
			// We don't want to do anything here.
		}

		public void OnSensorChanged(SensorEvent e)
		{
			lock (_syncLock)
			{
				/*var text = new StringBuilder("x = ")
					.Append(e.Values[0])
					.Append(", y=")
					.Append(e.Values[1])
					.Append(", z=")
					.Append(e.Values[2]);
				_sensorTextView.Text = text.ToString();*/
				double x = e.Values [0];
				double y = e.Values [1];

				if (Math.Abs (x) < 1 && Math.Abs (y) < 1) {
					mainLayout.SetBackgroundColor (Android.Graphics.Color.Green);
					green = true;
				} else {
					mainLayout.SetBackgroundColor (Android.Graphics.Color.Red);
					green = false;
				}
			}
		}

		protected override void OnResume()
		{
			base.OnResume();
			_sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.Accelerometer), SensorDelay.Ui);
		}

		protected override void OnPause()
		{
			base.OnPause();
			_sensorManager.UnregisterListener(this);
		}

		public static int GetPrefs(string prefname)
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			return prefs.GetInt(prefname, 1);
		}
	}
}

