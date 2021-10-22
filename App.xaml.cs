using System;
using SampleAnimation.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleAnimation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HBD();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
