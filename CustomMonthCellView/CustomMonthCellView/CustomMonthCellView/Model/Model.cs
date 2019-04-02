using System;
using Xamarin.Forms;

namespace CustomMonthCellView
{
    public class Meeting
    {
        public string Event { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public Color Color { get; set; }

        public bool AllDay { get; set; }
    }
}
