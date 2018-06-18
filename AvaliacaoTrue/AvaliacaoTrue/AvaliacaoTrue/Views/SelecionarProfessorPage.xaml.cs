using AvaliacaoTrue.ViewModels;
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
    public partial class SelecionarProfessorPage : ContentPage
    {
        private SelecionarProfessorViewModel vm;

        public SelecionarProfessorPage()
        {
            InitializeComponent();
            vm = new SelecionarProfessorViewModel();
            BindingContext = vm;
        }

        private void Proximo_Clicked(object sender, EventArgs e)
        {
            var selecionados = vm.GetSelecionados();

            Navigation.PushAsync(new AvaliarProfessorPage());
        }
    }
}