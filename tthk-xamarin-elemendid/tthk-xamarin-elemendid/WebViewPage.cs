using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;

namespace tthk_xamarin_elemendid
{
	public class WebViewPage : ContentPage
    {
        private readonly WebView _webView;
        private const string TimetablePage = "https://thk.edupage.org/timetable/";
        private const string HomePage = "https://www.tthk.ee/";
        private const string ChangesPage = "https://tthk.ee/tunniplaani-muudatused";
        private const string ConsultationsPage = "https://www.tthk.ee/oppetoo/opetajate-konsultatsioonid/";
        private ImageButton _previousButton;
        private ImageButton _homeButton;
        private ImageButton _nextButton;

        public WebViewPage()
        {
            ImageButton[] buttons = {_previousButton, _homeButton, _nextButton};
            string[] buttonsIcons = {"previous.png", "home.png", "next.png"}; // C# updates is a miracle
            StackLayout buttonsLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            for (int i = 0; i < 3; i++)
            {
                buttons[i] = new ImageButton()
                {
                    Source = buttonsIcons[i],
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 50,
                    Padding = 15
                };
                buttonsLayout.Children.Add(buttons[i]);
            }
            buttons[0].Clicked += OpenPreviousPage;
            buttons[1].Clicked += OpenNextPage;
            buttons[2].Clicked += OpenHomePage;
            ToolbarItem linksButton = new ToolbarItem() {Text = "Lehed"};
            ToolbarItems.Add(linksButton);
            linksButton.Clicked += LinksButtonOnClicked;
            _webView = new WebView()
            {
                Source = HomePage,
                WidthRequest = 300,
                HeightRequest = 1000
            };
            _webView.Cookies = new CookieContainer();
            StackLayout stackLayout = new StackLayout()
            {
                Children = { buttonsLayout, _webView }
            };
            Content = stackLayout;
        }

        private void OpenHomePage(object sender, EventArgs e)
        {
            ChangePageOnWebView(HomePage);
        }

        private void OpenNextPage(object sender, EventArgs e)
        {
            _webView.GoForward();
        }

        private void OpenPreviousPage(object sender, EventArgs e)
        {
            _webView.GoBack();
        }

        private void ChangePageOnWebView(string url)
        {
            _webView.Source = url;
        }

        private async void LinksButtonOnClicked(object sender, EventArgs e)
        {
            string selectedPage = await DisplayActionSheet("Lehed", "Avaleht", "Katkesta", "Tunniplaan", "Muudatused", "Konsultatsioonid");
            switch (selectedPage)
            {
                case "Katkesta":
                    await Navigation.PopAsync();
                    break;
                case "Tunniplaan":
                    ChangePageOnWebView(TimetablePage);
                    break;
                case "Muudatused":
                    ChangePageOnWebView(ChangesPage);
                    break;
                case "Konsultatsioonid":
                    ChangePageOnWebView(ConsultationsPage);
                    break;
                default:
                    ChangePageOnWebView(HomePage);
                    break;
            }
        }
    }
}