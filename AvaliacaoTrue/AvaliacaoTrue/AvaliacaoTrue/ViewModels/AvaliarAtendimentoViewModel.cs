using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AvaliacaoTrue.ViewModels
{
    public class AvaliarAtendimentoViewModel
    {
        public int NotaServico { get; set; }
        public int NotaLimpeza { get; set; }
        public int NotaRecepcao { get; set; }

        public ICommand ProfessoresCommand { get; set; }

        public AvaliarAtendimentoViewModel()
        {
            ProfessoresCommand = new Command(()=> {
                App.Current.MainPage?.Navigation.PushAsync(new Views.SelecionarProfessorPage());
            }, () =>
            {
                return NotaServico > 0
                && NotaLimpeza > 0
                && NotaRecepcao > 0;
            }
            );
        }

    }
}
