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
    public partial class Logo : ContentPage

    {
        public Logo()
        {
            InitializeComponent();
            var timer = new Timer(TimeSpan.FromSeconds(3).TotalMilliseconds);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            
            var timer = (Timer)sender;
            timer.Stop();
            timer.Elapsed -= OnTimerElapsed;
        
            var slideUpAnimation = new Animation(v => this.TranslationY = v, 0, -Height, Easing.Linear);

            slideUpAnimation.Commit(this, "SlideUp", 30, (uint)TimeSpan.FromSeconds(10).TotalMilliseconds, null, (double arg1, bool arg2) =>
            {
               Navigation.RemovePage(this);
            });
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PushAsync(new Log_in());
               
            });
        }
    }
}