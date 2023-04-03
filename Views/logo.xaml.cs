using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class logo : ContentPage

    {
        public logo()
        {
            InitializeComponent();
            var timer = new Timer(TimeSpan.FromSeconds(3).TotalMilliseconds);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Stop the timer
            var timer = (Timer)sender;
            timer.Stop();
            timer.Elapsed -= OnTimerElapsed;
            // Create a new animation to slide the LogoPage up
            var slideUpAnimation = new Animation(v => this.TranslationY = v, 0, -Height, Easing.Linear);

            slideUpAnimation.Commit(this, "SlideUp", 16, (uint)TimeSpan.FromSeconds(1).TotalMilliseconds, null, (double arg1, bool arg2) =>
            {
                Navigation.RemovePage(this);
            });
            // Navigate to the homepage
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PushAsync(new Log_in());
               
            });
        }
    }
}