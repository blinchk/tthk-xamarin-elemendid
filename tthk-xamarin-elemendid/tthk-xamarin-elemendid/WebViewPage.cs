using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace tthk_xamarin_elemendid
{
	public class WebViewPage : ContentPage
{
    public WebViewPage()
    {
        Content = new StackLayout
        {
            Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
        };
    }
}
}