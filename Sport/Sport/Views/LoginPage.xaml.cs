using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sport.ViewModels;

namespace Sport.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            BindingContext = new LoginViewModel();

        }


        private async void btnOpenRegister_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RegisterPage());
            Application.Current.MainPage = new RegisterPage();
        }
    }
}