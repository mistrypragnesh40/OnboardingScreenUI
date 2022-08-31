using OnboardingScreenUI.Models;
using OnboardingScreenUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnboardingScreenUI.ViewModels
{
    public class IntroScreenViewModel : BaseViewModel
    {
        #region Properties

        private string _buttonText ="Next";
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        private int _position;
        public int Position
        {
            get => _position;
            set => SetProperty(ref _position, value, onChanged: (() =>
            {
                if (value == IntroScreens.Count - 1)
                {
                    ButtonText = "Start";
                }
                else
                {
                    ButtonText = "Next";
                }
            }));
        }

        public ObservableCollection<IntroScreenModel> IntroScreens { get; set; } = new ObservableCollection<IntroScreenModel>();
        #endregion


        public IntroScreenViewModel()
        {
            IntroScreens.Add(new IntroScreenModel
            {
                IntroTitle = "Order Your Food",
                IntroDescription = "Now you can order food anytime right from mobile",
                IntroImage = "order"
            });

            IntroScreens.Add(new IntroScreenModel
            {
                IntroTitle = "Cooking Safe Food",
                IntroDescription = "We are maintain safty and we keep clean while making food",
                IntroImage = "cooking"
            });

            IntroScreens.Add(new IntroScreenModel
            {
                IntroTitle = "Quick Delivery",
                IntroDescription = "Orders your favorite meals will be immediately deliver.",
                IntroImage = "delivery"
            });
        }



        public ICommand NextCommand => new Command(async () =>
        {
            if (Position >= IntroScreens.Count - 1)
            {
                await AppShell.Current.GoToAsync($"//{nameof(DashboardView)}");
            }
            else
            {
                Position += 1;
            }
        });
    }
}
