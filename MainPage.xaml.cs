using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAnimation.Extensions;
using Xamarin.Forms;
using ViewExtensions = SampleAnimation.Extensions.ViewExtensions;

namespace SampleAnimation
{
    public partial class MainPage : ContentPage
    {
        private bool _isAnimating;
        MainPageViewModel vm;
        readonly Animation rotation,scaling,revolve;


        public MainPage()
        {
            InitializeComponent();
            vm =new MainPageViewModel();
            this.BindingContext = vm;

            rotation = new Animation(v => status.Rotation = v, 0, 360);
            scaling = new Animation(v => pancake.TranslationX = v, 0, 270);
            // revolve = new Animation(v => floating.ScaleY = v, 0, 5);
            revolve = new Animation {
            { 0, 0.25, new Animation (v => floating.TranslationY = v, 0, -40) },
            { 0.25, .5, new Animation (v => floating.TranslationY = v, -40, 0, easing: Easing.BounceOut) }};

            vm.PropertyChanged += OnPropertyChanged;
        }



        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(vm.IsBusy))
            {
                if (!vm.IsBusy)
                {
                    this.AbortAnimation("rotate");
                    this.AbortAnimation("scale");
                    this.AbortAnimation("revolute");
                }
                else
                {
                    rotation.Commit(this, "rotate", 16, 1000, Easing.Linear, (v, c) => status.Rotation = 0, () => true);
                    scaling.Commit(this, "scale", 16, 4000, Easing.Linear, (v, c) => pancake.TranslationX = 0, () => true);
                    //revolve.Commit(this, "revolute", 16, 1000, Easing.Linear, (v, c) => floating.ScaleY = 1, () => false);
                    revolve.Commit(this, "revolute", length: 1000, repeat: () => true);
                }
            }
        }

        //async void StartStopAnimation_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    if (!_isAnimating)
        //    {
        //        _isAnimating = true;
        //        status.Text = "RUNNING";
        //        SolidColorBrush solid1 = new SolidColorBrush(Color.FromHex("#8845b8"));
        //        SolidColorBrush solid2 = new SolidColorBrush(Color.FromHex("#c23569"));
        //        SolidColorBrush solid3 = new SolidColorBrush(Color.FromHex("#ff9e4f"));
        //        SolidColorBrush solid4 = new SolidColorBrush(Color.FromHex("#f52e33"));

        //        await pancake.ColorTo(Color.FromHex("#8845b8"), Color.FromHex("#c23569"), c => pancake.BackgroundColor = c, 5000, Easing.Linear);
        //        await pancake.ColorTo(Color.FromHex("#f52e33"), Color.FromHex("#ff9e4f"), c => pancake.BackgroundColor = c, 5000, Easing.Linear);
        //        await pancake.ColorTo(Color.FromHex("#c23569"), Color.FromHex("#8845b8"), c => pancake.BackgroundColor = c, 5000, Easing.Linear);
        //        await pancake.ColorTo(Color.FromHex("#ff9e4f"), Color.FromHex("#f52e33"), c => pancake.BackgroundColor = c, 5000, Easing.Linear);



        //        status.Text = "DONE";
        //        _isAnimating = false;
        //    }
        //    else
        //    {
        //        _isAnimating = false;
        //        status.Text = string.Empty;
        //        ViewExtensions.CancelAnimation(pancake);
        //    }
        //}
    }
}
