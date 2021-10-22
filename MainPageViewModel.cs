using System;
using System.Threading;
using System.Windows.Input;
using SampleAnimation.ViewModel;
using Xamarin.Forms;

namespace SampleAnimation
{
    public class MainPageViewModel: ViewModelBase
    {

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public ICommand ClickBtnCommand { get; set; }

        public MainPageViewModel()
        {
            ClickBtnCommand = new Command(OnBtnClick);
            
        }

        void OnBtnClick()
        {
            if (!IsBusy)
            {
                IsBusy = true;
            }
            else
                IsBusy = false;
        }


    }
}
