using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace tthk_xamarin_elemendid
{
	public class TableViewPage : ContentPage
    {
        public TableViewPage()
        {
            TableView tableView = new TableView()
            {
                Root = new TableRoot()
                {
                    new TableSection("Esimene")
                    {
                        new SwitchCell() { Text = "Esimene" },
                        new SwitchCell() { Text = "Teine" }
                    },
                    new TableSection("Teine")
                    {
                        new EntryCell() { Label = "Esimene" },
                        new EntryCell()
                        {
                            Label = "Teine",
                            LabelColor = Color.Chocolate
                        }
                    },
                    new TableSection("Kolmas")
                    {
                        new ViewCell()
                        {
                            View = new StackLayout()
                            {
                                Children = { new Slider(0, 100, 10)
                                    {
                                        MinimumTrackColor = Color.Red,
                                        MaximumTrackColor = Color.Green,
                                        VerticalOptions = LayoutOptions.CenterAndExpand
                                    }
                                }
                            }
                        }
                    }
                }
            };
            foreach (var i in tableView.Root[0])
            {
                if (i is SwitchCell switchCell) switchCell.OnChanged += AnySwitchCellChanged;
            }

            Content = tableView;
        }

        private async void AnySwitchCellChanged (object sender, ToggledEventArgs e)
        {
            if (sender is SwitchCell switchCell)
            {
                string switchCellState = switchCell.On ? "sisse" : "välja";
                await DisplayAlert("SwitchCell muudetud", $"{switchCell.Text} switchCell " +
                                                          $"muudetud {switchCellState}", "OK");
            }
        }
    }
}