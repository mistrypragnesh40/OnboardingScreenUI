using OnboardingScreenUI.ViewModels;

namespace OnboardingScreenUI.Views;

public partial class IntroScreenView : ContentPage
{
	public IntroScreenView()
	{
		InitializeComponent();
		this.BindingContext = new IntroScreenViewModel();
	}
}