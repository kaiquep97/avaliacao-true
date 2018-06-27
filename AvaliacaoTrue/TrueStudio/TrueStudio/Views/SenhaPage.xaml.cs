using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrueStudio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SenhaPage
	{
		public SenhaPage ()
		{
			InitializeComponent ();
		}
        private void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            var texto = txtSenha.Text?.ToLower().Trim();

            if (!string.IsNullOrWhiteSpace(texto) && texto.Equals("skolbeats"))
            {
                Navigation.PushAsync(new ManagerPage());
                Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAllAsync();
            }
            else
            {
                txtSenha.Text = "";
                DisplayAlert("Ops!", "Senha incorreta. Tente novamente", "OK");
            }
        }
	}
}