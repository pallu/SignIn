using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SignIn.Core;

namespace SignIn.UI.Android
{
	[Activity (Label = "Sign In Sheet", MainLauncher = false)]
	public class EventActivity : Activity
	{
		EventActivityAdapter adapter;
		ListView eventListView = null;

		//int count = 1;
		EventRepository repo;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//var eventListView = FindViewById<ListView>(Resource.Id.listView1);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.listView1);
			
			//button.Click += delegate {
			//	button.Text = string.Format ("{0} clicks!", count++);
			//};
			eventListView = FindViewById<ListView> (Resource.Id.listView1);

			repo = new EventRepository ();
			repo.CreateSampleData ();

		}
		protected override void OnResume ()
		{
			base.OnResume ();
			//EventRepository repo = new EventRepository ();
		    
			adapter = new EventActivityAdapter (this, repo.GetEvents ());
			eventListView.Adapter = adapter;
		}
	}

}


