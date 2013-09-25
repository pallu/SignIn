using System;
using SQLite;
using System.IO;
namespace SignIn.Core
{
	public class EventRepository
	{
	
		SQLiteConnection db;
		public EventRepository ()
		{
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				"signin.db3");
			db = new SQLiteConnection (dbPath);
			db.CreateTable<ProjectEvent> ();
			db.CreateTable<EventPerson> ();
		}
		public void CreateSampleData()
		{
			if (db.Table<ProjectEvent> ().Count () == 0) {
				db.DeleteAll<ProjectEvent> ();
				for (int i = 0; i < 10; i++) {
					char iChar = i.ToString ().ToCharArray (0, 1) [0];
					db.Insert (new ProjectEvent {
						EventID = i,
						LSC = new String(iChar,5),
						EventDate = DateTime.Now.AddDays(i+1),
						Rep = String.Format("Rep{0}First Rep{0}Last",i),
						Speaker = String.Format("Speaker{0}First Speaker{0}Last",i),
						Venue = String.Format("Venue{0}",i),
						Title = String.Format("Event Title {0}",i)
					});
					db.Insert (new EventPerson {
						AttendeeTypeID = 15,
						AttendeeType = "Rep",
						Degree = "",
						EventID = i,
						EventPersonID = -1,
						PersonFirstName = "RepFirstName",
						PersonLastName =  "RepLastName",
						Attended = true

					});
					db.Insert (new EventPerson {
						AttendeeTypeID = 1,
						AttendeeType = "Speaker",
						Degree = "MD",
						EventID = i,
						EventPersonID = -1,
						PersonFirstName = "SpeakerFirstName",
						PersonLastName =  "SpeakerLastName",
						Attended =  true

					});
					for (int j = 0; j < 15; j++) {
						db.Insert (new EventPerson {
							AttendeeTypeID = 8,
							AttendeeType = "Attendee",
							Degree = "MD",
							EventID = i,
							EventPersonID = -1,
							PersonFirstName = String.Format("Attendee{0}First",j),
							PersonLastName =  String.Format("Attendee{0}Last",j)
							
						});
					}


				}
			}
		}
		public ProjectEvent[] GetEvents()
		{
			System.Collections.Generic.List<ProjectEvent> lst = new System.Collections.Generic.List<ProjectEvent> ();
			foreach (var pEvent in db.Table<ProjectEvent>().OrderBy(e=>e.EventDate)) {
				lst.Add (pEvent);
			}
			return lst.ToArray();
		}
		public EventPerson[] GetAttendees(int EventID)
		{
			System.Collections.Generic.List<EventPerson> evt = new System.Collections.Generic.List<EventPerson> ();
			foreach (var pAttendee in db.Table<EventPerson>().Where(e=>e.EventID == EventID)) {
				evt.Add(pAttendee);
			} 
			return evt.ToArray ();
		}
		public ProjectEvent GetEvent(int EventID)
		{
			return db.Table<ProjectEvent> ().Where (e => e.EventID == EventID).FirstOrDefault ();
		}
		public bool SaveEventPerson(int AttendeeID,bool attended)
		{
			EventPerson ePerson = db.Table<EventPerson> ().Where (ep => ep.AttendeeID == AttendeeID).FirstOrDefault();
			if (ePerson != null) {
				ePerson.Attended = attended;
				db.InsertOrReplace (ePerson);
				return true;
			} else
				return false;
		}
	}
}

