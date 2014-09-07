
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

namespace PhoneApp
{
	[Activity (Label = "exDragGame")]			
	public class exDragGame : Activity, View.IOnTouchListener
	{
		ImageButton _myButton;
		float _viewX;
		float _viewY;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.exDragGame);

			_myButton = FindViewById<ImageButton>(Resource.Id.exPhone);
			_myButton.SetOnTouchListener(this);


		}

		public bool OnTouch(View v, MotionEvent e)
		{
			switch (e.Action)
			{
			case MotionEventActions.Down:
				_viewX = e.GetX ();
				_viewY = e.GetY ();
				break;
			case MotionEventActions.Move:
				var left = (int)(e.RawX - _viewX);
				var right = (int)(left + v.Width);
				var top = (int)(e.RawY - _viewY);
				var bottom = (int)(v.Height + top);
				Console.WriteLine (left);
				Console.WriteLine (v.Width);
				if (left == v.Width-40) {
				//					TextView tv=new TextView(GetApplicationContext());
				//					tv.SetText("Avoided call with ex!");
				//					Resource.Layout.exDragGame   AddView(tv);
					Console.WriteLine ("hit the edge");
				}
				v.Layout (left, top, right, bottom);
				//				Console.WriteLine (" L " + left + " R " + right + " T " + top + " B " + bottom);
				break;
			}
			return true;
		}

	}


}