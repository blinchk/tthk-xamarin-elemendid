﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace tthk_xamarin_elemendid
{
    public partial class MainPage : ContentPage
    {
        List<Button> buttons = new List<Button>();
        string[] buttonNames = new string[] { "Entry/Editor", "ListView", "DatePicker", "TableView", "WebView", "Timer", "ProgressBarPage", "VibrationPage"};
        Page[] pages = new Page[] { new EntryPage(), new ListViewPage(), new DatePickerPage(), new TableViewPage(), new WebViewPage(), new TimerPage(), new ProgressBarPage(), new VibrationPage() };
        StackLayout stackLayout = new StackLayout() { Margin = new Thickness(0, 20) };
        public MainPage()
        {
            Title = "Elemendid";
            for (int i = 0; i < buttonNames.Length; i++)
            {
                Button xbutton = new Button { Text = buttonNames[i], Margin = new Thickness(20, 0) };
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
