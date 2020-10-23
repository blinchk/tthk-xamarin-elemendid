using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace tthk_xamarin_elemendid
{
	public class ListViewPage : ContentPage
    {
        string[] tasks = new string[] { "Tõusen püsti", "Söön putru", "Jalutan", "Lähen lõunale", "Tegelen spordiga", "Söön", "Magan" };
        public ListViewPage()
        {
            ListView list = new ListView();
            list.ItemsSource = tasks;
            Content = new StackLayout { Children = { list } };
        }
    }
}