using System;
using SQLite;

namespace SignIn.Core
{
	[Table("EventAttendees")]
	public class EventPerson
	{
		[PrimaryKey,AutoIncrement]
		public int AttendeeID {
			get;
			set;
		}
		[Indexed]
		public int EventID {
			get;
			set;
		}
		public int EventPersonID {
			get;
			set;
		}
		public int AttendeeTypeID {
			get;
			set;
		}
		public string AttendeeType {
			get;
			set;
		}
		public int PersonID {
			get;
			set;
		}
		public string PersonFirstName {
			get;
			set;
		}
		public string PersonLastName {
			get;
			set;
		}
		public string Degree {
			get;
			set;
		}
		public bool Attended {
			get;
			set;
		}
		public string FullName {
			get {
				return String.Format ("{0} {1} {2}", PersonFirstName, PersonLastName, String.IsNullOrWhiteSpace (Degree) ? "" : Degree);
			}
		}


	}
}

