using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SampleAnimation.Views
{
    public partial class HBD : ContentPage
    {
        readonly Animation hori,ver,stay;

        public HBD()
        {
            InitializeComponent();
            hori = new Animation {
            { 0, 1, new Animation (v => cake.IsVisible = true,easing: Easing.Linear) },
            { 0, 0.2, new Animation (v => cake.TranslationX = v, -200,0, easing: Easing.Linear) },
            { 0.2, 0.5, new Animation (v => cake.HorizontalOptions = LayoutOptions.Center, easing: Easing.Linear) },
            { 0.5, 1, new Animation (v => candle.IsVisible = true,easing: Easing.Linear) },
            {0.5, 0.8, new Animation (v => candle.TranslationY = v,-200,0, easing: Easing.BounceOut) },
            {0.8, 1, new Animation (v => hbd.IsVisible =true,easing: Easing.Linear) },
            {0.8, 1, new Animation (v => hbd.Scale = v, 1,2, easing: Easing.Linear) },
            {0.8, 1, new Animation (v => candle.Scale = v, 1,2, easing: Easing.Linear) },
            {0.9, 1, new Animation (v => hbd.HorizontalOptions = LayoutOptions.Center, easing:Easing.BounceOut) },
            {0.8, 1, new Animation (v => candle.Scale = v, 2,1, easing: Easing.Linear) },
            };
        }

        protected override void OnAppearing()
        {
            hori.Commit(this, "revolute", length: 1000, repeat: () => true);
        }
    }
}
