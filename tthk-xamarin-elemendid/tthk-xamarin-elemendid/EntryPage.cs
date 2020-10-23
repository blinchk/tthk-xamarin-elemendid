using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Xamarin.Forms;

namespace tthk_xamarin_elemendid
{
	public class EntryPage : ContentPage
    {
        Entry entry;
        Editor editor;
        public EntryPage()
        {
            entry = new Entry();
            editor = new Editor() { AutoSize = EditorAutoSizeOption.TextChanges };
            Button clearButton = new Button() { Text = "Kustuta kõik" };
            clearButton.Clicked += ClearButtonClicked;
            Button showButton = new Button() { Text = "Näita teade" };
            showButton.Clicked += ShowButtonClicked;
            Content = new StackLayout
            {
                Children = { entry, editor, clearButton, showButton }
            };
        }

        private async void ShowButtonClicked(object sender, EventArgs e)
        {
            if (entry.Text != null && editor.Text != null)
            {
                await DisplayAlert(entry.Text, editor.Text, "OK");
            }
        }

        private void ClearButtonClicked(object sender, EventArgs e)
        {
            entry.Text = null;
            editor.Text = null;
        }
    }
}