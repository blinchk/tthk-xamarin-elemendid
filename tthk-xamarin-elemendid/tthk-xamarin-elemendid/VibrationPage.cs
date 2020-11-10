using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace tthk_xamarin_elemendid
{
	public class VibrationPage : ContentPage
    {
        List<Button> toVibrateButtons; // List of buttons with vibration duration
        Label vibrationDurationLabel;
        const int ROWS_COLUMNS_NUMBER = 3;
        public VibrationPage()
        {
            toVibrateButtons = new List<Button>();
            Grid grid = new Grid() { 
                ColumnSpacing = 10,
                RowSpacing = 10
            };
            // Define the rows and columns
            for (int i = 0; i < ROWS_COLUMNS_NUMBER; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            // Define buttons for buttons' list
            for (int i = 400; i <= 1400; i += 200)
            {
                Button toVibrateButton = new Button()
                {
                    Text = i.ToString(),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                toVibrateButton.Clicked += ToVibrateButton_Clicked;
                toVibrateButtons.Add(toVibrateButton);
            }
            // Only first two rows and columns will be filled with vibration duration buttons
            for (int i = 0; i < toVibrateButtons.Count; i++)
            {
                if (i < 3)
                {
                    grid.Children.Add(toVibrateButtons[i], i, 0);
                }
                else
                {
                    grid.Children.Add(toVibrateButtons[i], i - 3, 1);
                }
            }
            vibrationDurationLabel = new Label()
            {
                Text = "Vibratsioon pole käivitatud",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            Label chooseDurationLabel = new Label()
            {
                Text = "Vali vibratsiooni kesktvus",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            Grid.SetRow(vibrationDurationLabel, 2);
            Grid.SetColumnSpan(vibrationDurationLabel, 3);
            grid.Children.Add(vibrationDurationLabel);
            StackLayout stackLayout = new StackLayout() { 
                Children = {chooseDurationLabel, grid}
            };
            Content = stackLayout;
        }

        private void ToVibrateButton_Clicked(object sender, EventArgs e)
        {
            Button toVibrateButton = sender as Button;
            int vibrationDurationNumber = Int32.Parse(toVibrateButton.Text);
            var vibrationDuration = TimeSpan.FromMilliseconds(vibrationDurationNumber); // Convert from button's string text
            vibrationDurationLabel.Text = $"Käivitatud vibratsioon kestvusega {vibrationDurationNumber} ms.";
            Vibration.Vibrate(vibrationDuration);
        }
    }
}