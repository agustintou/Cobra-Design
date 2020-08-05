using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SURSYSTEM.Models
{
    public class MeetingModel
    {
		public string EventName { get; set; }
		public string Organizer { get; set; }
		public string ContactID { get; set; }
		public int Capacity { get; set; }
		public DateTime From { get; set; }
		public string FromDay => From.ToString("dd");
		public string FromTime => From.ToString("hh:mm");
		public string FromAmPm => From.ToString("tt");
		public string FromDayName => From.ToString("dddd").Substring(0, 3);
		public DateTime To { get; set; }
		public Color color { get; set; }
		public Color colorPar => ObtenerPar(color);

		private Color ObtenerPar(Color color)
		{
			var colorHex = color.ToHex();

			if (colorHex == "#FF" + "C5E5F2")
			{
				return Color.FromHex("#1B99CC");
			}
			else if (colorHex == "#FF" + "CAD0DC")
			{
				return Color.FromHex("#2F4676");
			}
			else if (colorHex == "#FF" + "DBDFE1")
			{
				return Color.FromHex("#6F7F89");
			}
			else if (colorHex == "#FF" + "D5ECD2")
			{
				return Color.FromHex("#59B44B");
			}
			else if (colorHex == "#FF" + "FFDFC0")
			{
				return Color.FromHex("#FD8004");
			}
			else if (colorHex == "#FF" + "FBD3D8")
			{
				return Color.FromHex("#EE5166");
			}
			else
			{
				return Color.White;
			}
		}

		public bool AllDay { get; set; }
	}
}
