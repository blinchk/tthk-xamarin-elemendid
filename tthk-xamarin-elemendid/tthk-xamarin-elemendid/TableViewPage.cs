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
        Content = new StackLayout
        {
            Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
        };
    }
}
}