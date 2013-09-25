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
	public class EventActivityAdapter : BaseAdapter<SignIn.Core.ProjectEvent>
	{
		ProjectEvent[] events;
		Activity context;

		public EventActivityAdapter(Activity context, ProjectEvent[] events) : base() {
			this.context = context;
			this.events = events;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override ProjectEvent this[int position] {  
			get { return events[position]; }
		}
		public override int Count {
			get { return events.Length; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var pEvent = events[position];

			var view = (convertView ?? 
			            context.LayoutInflater.Inflate(
				Resource.Layout.EventItem, 
				parent, 
				false)) as LinearLayout;

				//view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
			view.Click += (object sender, EventArgs e) => {
				var activityDetail = new Intent(context,typeof(AttendeeActivity));
				activityDetail.PutExtra("EventID",events[position].EventID);
				context.StartActivity(activityDetail);
				
			};


			view.FindViewById<TextView> (Android.Resource.Id.txtLSC).Text = String.Format ("LSC: {0} - {1}", events [position].LSC, events[position].Title);
			view.FindViewById<TextView> (Android.Resource.Id.txtDescription).Text = String.Format ("Venue: {0} {1}", events [position].Venue, events [position].EventDate.ToString ());// ;// items[position];
			return view;
		}

		
	}
}

