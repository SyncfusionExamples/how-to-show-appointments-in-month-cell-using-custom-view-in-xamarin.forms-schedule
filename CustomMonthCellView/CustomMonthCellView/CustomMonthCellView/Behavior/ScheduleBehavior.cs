using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace CustomMonthCellView
{
    public class ScheduleBehavior:Behavior<SfSchedule>
    {
        private SfSchedule sfSchedule;
        public ScheduleBehavior()
        {
        }
        protected override void OnAttachedTo(SfSchedule bindable)
        {
            sfSchedule = bindable;
            MonthViewSettings monthViewSettings = new MonthViewSettings();
            monthViewSettings.TodayBackground = Color.Transparent;
            sfSchedule.MonthViewSettings = monthViewSettings;
            sfSchedule.OnMonthCellLoadedEvent += SfSchedule_OnMonthCellLoadedEvent; 
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(SfSchedule bindable)
        {
            sfSchedule.OnMonthCellLoadedEvent -= SfSchedule_OnMonthCellLoadedEvent; 

            base.OnDetachingFrom(bindable);
        }

        void SfSchedule_OnMonthCellLoadedEvent(object sender, MonthCellLoadedEventArgs e)
        {
            Grid mainLayout = new Grid();
            mainLayout.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            Label dateLabel = new Label();
            dateLabel.Text = e.date.ToString("dd");
            dateLabel.HorizontalTextAlignment = TextAlignment.Center;
            dateLabel.VerticalOptions = LayoutOptions.FillAndExpand;
            dateLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
            dateLabel.BackgroundColor = Color.Transparent;
            mainLayout.Children.Add(dateLabel);

            ListView listView = new ListView();
            listView.HasUnevenRows = false;
            listView.BackgroundColor = Color.Transparent;
            listView.RowHeight = 20;

            var appointmentTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                var appointmentName = new Label { Margin = new Thickness(0, 3, 3, 0), FontSize = 14};
                var collection = (e.appointments as ObservableCollection<object>);
                appointmentName.SetBinding(Label.TextProperty, "Event");
                appointmentName.SetBinding(Label.BackgroundColorProperty, "Color");
                grid.Children.Add(appointmentName);
                return new ViewCell { View = grid };
            });

            listView.ItemTemplate = appointmentTemplate;
            listView.ItemsSource = e.appointments;
            if((e.appointments as ObservableCollection<object>).Count !=0)
            mainLayout.Children.Add(listView,0,1);
            // Setting custom view for month cell
            e.view = mainLayout;
        }

    }
}
