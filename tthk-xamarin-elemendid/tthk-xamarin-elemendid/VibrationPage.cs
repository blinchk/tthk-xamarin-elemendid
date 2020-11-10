using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace tthk_xamarin_elemendid
{
	public class VibrationPage : ContentPage
    {
        Button toVibrate;
        const int ROWS_COLUMNS_NUMBER = 3;
        public VibrationPage()
        {
            Grid grid = new Grid();
            for (int i = 0; i < ROWS_COLUMNS_NUMBER; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 200; i <= 1400; i=+200)
            {

            }
        }
    }
}