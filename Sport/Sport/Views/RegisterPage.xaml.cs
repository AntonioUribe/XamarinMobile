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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
            BindingContext = new RegisterViewModel();

        }

        private async void btnOpenLogin_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new LoginPage());
            Application.Current.MainPage = new LoginPage();
        }
    }
}