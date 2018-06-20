using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoTrue.Models;
using AvaliacaoTrue.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AvaliacaoTrue.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvaliarProfessorPage : ContentPage
	{

        public AvaliarProfessorPage(Avaliacao avaliacao, IList<Professor> selecionados)
        {
            InitializeComponent();
            BindingContext = new AvaliarProfessorViewModel(avaliacao, selecionados);
        }
    }
}