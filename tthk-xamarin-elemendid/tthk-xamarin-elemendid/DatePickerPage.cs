using System;
using Xamarin.Forms;

namespace tthk_xamarin_elemendid
{
	public class DatePickerPage : ContentPage
    {
        private readonly DatePicker _datePicker;
        private readonly TimePicker _timePicker; // Object doesn't change outside constructor
        public DatePickerPage()
        {
            Title = "DatePicker";
            FlexLayout flexLayout = new FlexLayout()
            {
                Direction = FlexDirection.Column
            };
            _datePicker = new DatePicker()
            {
                MinimumDate = new DateTime(2000, 1, 1),
                MaximumDate = DateTime.Today + TimeSpan.FromDays(365),
                Format = @"dd.MM.yyyy",
                Date = DateTime.Today
            };
            _timePicker = new TimePicker()
            {
                Time = DateTime.Now.TimeOfDay,
                Format = "t"
            };
            Button button = new Button()
            {
                Text = "Näita teade"
            };
            button.Clicked += ShowButtonClicked;
            View[] views = new View[] { _datePicker, _timePicker, button};
            foreach (var view in views) flexLayout.Children.Add(view); // Can be defined using Linq
            Content = flexLayout;
        }

        private async void ShowButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Kuupäev ja aeg", 
                $"Kuupäev: {_datePicker.Date.ToString(@"dd.MM.yyyy")}\n" +
                $"Aeg: {_timePicker.Time.ToString(@"hh\:mm")}", "OK");
        }
    }
}