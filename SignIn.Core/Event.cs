using System;
using SQLite;
namespace SignIn.Core
{
	[Table("ProjectEvents")]
	public class ProjectEvent
	{
		[PrimaryKey,AutoIncrement]
		public int EventID {
			get;
			set;
		}
		public string LSC {
			get;
			set;
		}
		public DateTime EventDate {
			get;
			set;
		}
		public string Speaker {
			get;
			set;
		}
		public string Rep {
			get;
			set;
		}
		public string Venue {
			get;
			set;
		}
		public string Title {
			get;
			set;
		}
	}
}

