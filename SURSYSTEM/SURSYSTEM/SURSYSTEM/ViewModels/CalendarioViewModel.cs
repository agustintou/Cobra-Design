using GalaSoft.MvvmLight.Command;
using SURSYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SURSYSTEM.ViewModels
{
	public class CalendarioViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;


		public ObservableCollection<MeetingModel> Meetings { get; set; }
		public bool IsVisibleGrid
		{
			get
			{
				return isVisibleGrid;
			}
			set
			{
				if (isVisibleGrid != value)
				{
					isVisibleGrid = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsVisibleGrid)));
				}
			}
		}
		public bool IsVisibleCalendar
		{
			get
			{
				return isVisibleCalendar;
			}
			set
			{
				if (isVisibleCalendar != value)
				{
					isVisibleCalendar = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsVisibleCalendar)));
				}
			}
		}

		List<string> eventNameCollection;
		List<Color> colorCollection;
		bool isVisibleGrid;
		bool isVisibleCalendar;


		public CalendarioViewModel()
		{
			Meetings = new ObservableCollection<MeetingModel>();
			CreateEventNameCollection();
			CreateColorCollection();
			CreateAppointments();

			IsVisibleCalendar = false;
			IsVisibleGrid = true;

		}

		private void CreateAppointments()
		{
			Random randomTime = new Random();
			List<Point> randomTimeCollection = GettingTimeRanges();
			DateTime date;
			DateTime DateFrom = DateTime.Now.AddDays(-10);
			DateTime DateTo = DateTime.Now.AddDays(10);
			DateTime dataRangeStart = DateTime.Now.AddDays(-3);
			DateTime dataRangeEnd = DateTime.Now.AddDays(3);

			for (date = DateFrom; date < DateTo; date = date.AddDays(1))
			{
				if ((DateTime.Compare(date, dataRangeStart) > 0) && (DateTime.Compare(date, dataRangeEnd) < 0))
				{
					for (int AdditionalAppointmentIndex = 0; AdditionalAppointmentIndex < 3; AdditionalAppointmentIndex++)
					{
						MeetingModel meeting = new MeetingModel();
						int hour = (randomTime.Next((int)randomTimeCollection[AdditionalAppointmentIndex].X, (int)randomTimeCollection[AdditionalAppointmentIndex].Y));
						meeting.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
						meeting.To = (meeting.From.AddHours(1));
						meeting.EventName = eventNameCollection[randomTime.Next(9)];
						meeting.color = colorCollection[randomTime.Next(6)];
						if (AdditionalAppointmentIndex % 3 == 0)
							meeting.AllDay = true;
						Meetings.Add(meeting);
					}
				}
				else
				{
					MeetingModel meeting = new MeetingModel();
					meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);

					meeting.To = (meeting.From.AddHours(1));
					meeting.EventName = eventNameCollection[randomTime.Next(9)];
					meeting.color = colorCollection[randomTime.Next(6)];
					Meetings.Add(meeting);
				}
			}
		}

		private void CreateEventNameCollection()
		{
			eventNameCollection = new List<string>();
			eventNameCollection.Add("General Meeting");
			eventNameCollection.Add("Plan Execution");
			eventNameCollection.Add("Project Plan");
			eventNameCollection.Add("Consulting");
			eventNameCollection.Add("Performance Check");
			eventNameCollection.Add("Yoga Therapy");
			eventNameCollection.Add("Plan Execution");
			eventNameCollection.Add("Project Plan");
			eventNameCollection.Add("Consulting");
			eventNameCollection.Add("Performance Check");
		}

		private void CreateColorCollection()
		{
			colorCollection = new List<Color>();
			colorCollection.Add(Color.FromHex("#C5E5F2"));
			colorCollection.Add(Color.FromHex("#CAD0DC"));
			colorCollection.Add(Color.FromHex("#DBDFE1"));
			colorCollection.Add(Color.FromHex("#D5ECD2"));
			colorCollection.Add(Color.FromHex("#FFDFC0"));
			colorCollection.Add(Color.FromHex("#FBD3D8"));
		}

		private List<Point> GettingTimeRanges()
		{
			List<Point> randomTimeCollection = new List<Point>();
			randomTimeCollection.Add(new Point(9, 11));
			randomTimeCollection.Add(new Point(12, 14));
			randomTimeCollection.Add(new Point(15, 17));
			return randomTimeCollection;
		}

		public ICommand CalendarCommnad
		{
			get
			{
				return new RelayCommand(Calendar);
			}
		}

		private void Calendar()
		{
			if (IsVisibleCalendar == false)
			{
				IsVisibleCalendar = true;
				isVisibleGrid = false;
			}
			else
			{
				IsVisibleGrid = true;
				IsVisibleCalendar = false;
			}

		}
	}
}
