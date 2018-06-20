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
        private ManagerViewModel vm;

        public ManagerPage ()
		{
			InitializeComponent ();
            vm = new ManagerViewModel();
            BindingContext = vm;
		}

        private async void Novo_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new CadastroProfessorPage());
        }

        public async void Professor_Selected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem is Models.Professor teacher)
            {
                var mensagem = $"Você gostaria de {(teacher.Ativo ? "desativar" : "ativar")} o(a) professor(a) {teacher.Nome}";

                var result = await DisplayAlert("Ativar/Desativar", mensagem, "Sim", "Não");
                if(result)
                {
                    vm.AtualizaProfessor(teacher);
                }
            }
        }
	}
};