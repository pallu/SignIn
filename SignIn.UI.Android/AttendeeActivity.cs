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
using SignIn.Core;

namespace SignIn.UI.Android
{
	[Activity (Label = "Attendees")]			
	public class AttendeeActivity : Activity
	{
		ListView attendeeListView;
		TableLayout eventDetail;
		AttendeeActivityAdapter adapter;
		EventRepository repo;
		int EventID;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			EventID = Intent.GetIntExtra ("EventID", -1);
			SetContentView (Resource.Layout.EventPerson);

			attendeeListView = FindViewById<ListView> (Resource.Id.listViewAttendees);
			eventDetail = FindViewById<TableLayout> (Resource.Id.tableEventDetail);
			repo = new EventRepository ();
			this.ActionBar.SetDisplayHomeAsUpEnabled (true);
		
		}
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			//new AlertDialog.Builder(this.BaseContext).SetMessage(item.ItemId.ToString()).Show();
			//Toast.MakeText (this, item.ItemId.ToString (), ToastLength.Long);
			this.Finish ();
			return base.OnOptionsItemSelected (item);

		}
		protected override void OnResume ()
		{
			base.OnResume ();
			adapter = new AttendeeActivityAdapter (this, EventID);// (this, repo.GetAttendees(EventID));
			attendeeListView.Adapter = adapter;

			ProjectEvent pEvent = repo.GetEvent (EventID);

			if (pEvent != null) {
				eventDetail.FindViewById<TextView> (Resource.Id.textLSC).Text = pEvent.LSC;
				eventDetail.FindViewById<TextView> (Resource.Id.textEventTitle).Text = pEvent.Title;
				eventDetail.FindViewById<TextView> (Resource.Id.textRep).Text = pEvent.Rep;
				eventDetail.FindViewById<TextView> (Resource.Id.textSpeaker).Text = pEvent.Speaker;
				eventDetail.FindViewById<TextView> (Resource.Id.textDate).Text = pEvent.EventDate.ToString ();
				eventDetail.FindViewById<TextView> (Resource.Id.textVenue).Text = pEvent.Venue;

			}
		}
	}
}

