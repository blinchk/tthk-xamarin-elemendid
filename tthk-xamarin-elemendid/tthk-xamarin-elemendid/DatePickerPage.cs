using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

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
                Format = "d",
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
            View[] views = new View[] { _timePicker, _datePicker };
            foreach (var view in views) flexLayout.Children.Add(view); // Can be defined using Linq
            Content = flexLayout;
        }

        private async void ShowButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Kuupäev ja aeg", $"Kuupäev: {_datePicker.Date}\nAeg: {_timePicker.Time}", "OK");
        }
    }
}