using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace tthk_xamarin_elemendid
{
    public partial class MainPage : ContentPage
    {
        List<Button> buttons = new List<Button>();
        string[] buttonNames = new string[] { "Entry/Editor", "ListView", "DatePicker", "TableView", "WebView", "Timer" };
        Page[] pages = new Page[] { new EntryPage(), new ListViewPage(), new DatePickerPage(), new TableViewPage(), new WebViewPage(), new TimerPage() };
        StackLayout stackLayout = new StackLayout();
        public MainPage()
        {
            Title = "Elemendid";
            for (int i = 0; i < buttonNames.Length; i++)
            {
                Button xbutton = new Button { Text = buttonNames[i]};
                xbutton.Clicked += AnyButtonClicked;
                buttons.Add(xbutton);
                stackLayout.Children.Add(xbutton);
            }
            Content = stackLayout;
        }

        private void AnyButtonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Page selectedPage = pages[buttonNames.IndexOf(btn.Text)];
            selectedPage.Title = btn.Text;
            Navigation.PushAsync(selectedPage);
        }
    }
}
