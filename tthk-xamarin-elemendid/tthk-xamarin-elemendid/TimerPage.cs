using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace tthk_xamarin_elemendid
{
	public class TimerPage : ContentPage
    {
        private TimeSpan timerTime;
        private Button timerButton;
        public TimerPage()
        {
            Title = "Timer";
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            timerButton = new Button()
            {
                Text = "Vajuta nuppu"
            };
            timerButton.Clicked += TimerButtonClicked;
            AbsoluteLayout.SetLayoutBounds(timerButton, new Rectangle(0.5, 0.5, 110, 100));    
            AbsoluteLayout.SetLayoutFlags(timerButton, AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(timerButton);
            Content = absoluteLayout;
        }

        private void TimerButtonClicked(object sender, EventArgs e)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                        timerTime += TimeSpan.FromSeconds(1);
                        timerButton.Text = timerTime.ToString(@"mm\:ss");
                        if (timerTime.TotalSeconds > 60)
                        {
                            return false;
                        }
                        return true;
            });
        }
    }
}