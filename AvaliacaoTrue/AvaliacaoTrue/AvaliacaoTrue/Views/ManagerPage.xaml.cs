using AvaliacaoTrue.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AvaliacaoTrue.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManagerPage : ContentPage
	{
		public ManagerPage ()
		{
			InitializeComponent ();
            BindingContext = new ManagerViewModel();
		}

        private async void Novo_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new CadastroProfessorPage());
        }
	}
}