using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueStudio.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrueStudio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManagerPage : ContentPage
	{
        private ManagerViewModel vm;

        public ManagerPage()
        {
            InitializeComponent();
            vm = new ManagerViewModel();
            BindingContext = vm;
        }

        private async void Novo_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new CadastroProfessorPage());
        }

        private async void Gerar_Clicked(object sender, EventArgs e)
        {
            var resposta = await DisplayActionSheet("Gerar Relatorio", "Cancelar", "Fechar", "Avaliações professores", "Avaliações Studio");

            switch (resposta)
            {
                case "Avaliações professores":
                    if (vm.GeraRelatorioProfessor())
                        DisplayAlert("Relatório", "Relatorio gerado com sucesso!Verifique na pasta Download", "Ok");
                    break;
                case "Avaliações Studio":
                    if(vm.GeraRelatorioStudio())
                        DisplayAlert("Relatório", "Relatorio gerado com sucesso!Verifique na pasta Download", "Ok");
                    break;
            }
        }

        public async void Professor_Selected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem is Models.Professor teacher)
            {
                var mensagem = $"Você gostaria de {(teacher.Ativo ? "desativar" : "ativar")} o(a) professor(a) {teacher.Nome}";

                var result = await DisplayAlert("Ativar/Desativar", mensagem, "Sim", "Não");
                if (result)
                {
                    vm.AtualizaProfessor(teacher);
                }
            }
        }
    }
}