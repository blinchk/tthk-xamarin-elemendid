using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace tthk_xamarin_elemendid
{
	public class ProgressBarPage : ContentPage
    {
        private readonly ProgressBar _progressBar;
        private readonly Label sliderPositionLabel;
        private readonly Slider slider;
        public ProgressBarPage()
        {
           
            _progressBar = new ProgressBar()
            {
                ProgressColor = Color.DeepPink,
                Progress = 0.0
            };
            Button startButton = new Button()
            {
                Text = "Alusta",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            startButton.Clicked += StartButtonClicked;
            Button renewButton = new Button()
            {
                Text = "Uuendada",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            renewButton.Clicked += RenewButtonClicked;
            StackLayout buttonsLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = {startButton, renewButton}
            };
            slider = new Slider()
            {
                Maximum = 1000,
                Minimum = 200,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.DeepSkyBlue,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            slider.ValueChanged += SliderValueChanged;
            sliderPositionLabel = new Label()
            {
                Text = slider.Value.ToString()
            };
            StackLayout sliderLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = {sliderPositionLabel, slider},
                Margin = 10
            };
            StackLayout stackLayout = new StackLayout()
            {
                Children = { buttonsLayout, sliderLayout, _progressBar }
            };
            Content = stackLayout;
        }

        private void SliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            sliderPositionLabel.Text = Math.Round(slider.Value).ToString();
        }

        private void RenewButtonClicked(object sender, EventArgs e)
        {
            _progressBar.Progress = 0.0;
        }

        private async void StartButtonClicked(object sender, EventArgs e)
        {
            await _progressBar.ProgressTo(1.0, (uint)slider.Value, Easing.BounceOut);
        }
    }
}