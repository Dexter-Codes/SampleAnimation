using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SampleAnimation
{
    public partial class PageAppearingAnimation : ContentPage
    {
        readonly Animation floating;

        public PageAppearingAnimation()
        {
            InitializeComponent();
            floating = new Animation {
            { 0, 0.25, new Animation (v => page.TranslationX = v, 0, 200) },
            { 0.25, 0.5, new Animation (v => page.Scale = v, 1,2) },
            { 0.25, .5, new Animation (v => page.TranslationX = v, 200, 0) },
            { 0.5, 1, new Animation (v => page.Scale = v, 2,1, easing: Easing.BounceIn) }};
        }

        protected override  void OnAppearing()
        {
            floating.Commit(this, "revolute", length: 1000, repeat: () => true);
        }
    }   
}
