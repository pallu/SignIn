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
	public class AttendeeActivityAdapter : BaseAdapter<SignIn.Core.EventPerson>
	{
		EventPerson[] persons;
		Activity context;
		int EventID;

		//public AttendeeActivityAdapter(Activity context, EventPerson[] persons) : base() {
		public AttendeeActivityAdapter(Activity context,int EventID) : base(){
			this.EventID = EventID;
			this.context = context;
			this.persons = new EventRepository ().GetAttendees (EventID);
			//this.persons = persons;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override EventPerson this[int position] {  
			get { return persons[position]; }
		}
		public override int Count {
			get { return persons.Length; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var pAttendee = persons[position];

			var view = (convertView ?? 
			            context.LayoutInflater.Inflate(
				Resource.Layout.EventPersonItem, 
				parent, 
				false)) as LinearLayout;

			//view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);



			view.FindViewById<TextView> (Android.Resource.Id.textFullName).Text = persons[position].FullName;
			view.FindViewById<TextView> (Android.Resource.Id.textAttendeeType).Text = persons [position].AttendeeType;
			CheckBox chkBox = view.FindViewById<CheckBox> (Android.Resource.Id.checkBoxAttended);
			chkBox.SetTag(Android.Resource.String.CHK_ATTENDEEID, persons [position].AttendeeID);
			chkBox.Checked = persons [position].Attended;
			chkBox.Click += (object sender, EventArgs e) => {
				CheckBox cb = sender as CheckBox;
				if(cb!=null)
				{
			
					new EventRepository().SaveEventPerson(Convert.ToInt32(cb.GetTag(Android.Resource.String.CHK_ATTENDEEID)),cb.Checked);
				}
			};

			return view;
		}


	}
}

