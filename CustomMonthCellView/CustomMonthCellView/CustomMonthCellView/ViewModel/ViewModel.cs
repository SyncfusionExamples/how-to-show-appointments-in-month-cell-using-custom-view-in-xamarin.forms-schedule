using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace CustomMonthCellView
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meeting> scheduleAppointments;
        ObservableCollection<string> subjectCollection;
        ObservableCollection<Color> colorCollection;
        public ViewModel()
        {
            scheduleAppointments = new ObservableCollection<Meeting>();
            this.AddAppointmentDetails();
            this.AddAppointments();
        }

        public ObservableCollection<Meeting> ScheduleAppointments
        {
            get
            {
                return scheduleAppointments;
            }
            set
            {
                scheduleAppointments = value;
            }
        }

        private void AddAppointmentDetails()
        {
            subjectCollection = new ObservableCollection<string>();
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Performance Check");
            subjectCollection.Add("Yoga Therapy");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Performance Check");

            colorCollection = new ObservableCollection<Color>();
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
        }

        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            for (int month = -1; month <= 1; month++)
            {
                for (int i = -5; i <= 5; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        var appointment = new Meeting();
                        appointment.Event = subjectCollection[random.Next(8)];
                        appointment.From = today.AddMonths(month).AddDays(random.Next(1, 28)).AddHours(random.Next(9, 18));
                        appointment.To = appointment.From.AddHours(2);
                        appointment.Color = colorCollection[random.Next(11)];
                        appointment.AllDay = false;
                        this.ScheduleAppointments.Add(appointment);
                    }
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
