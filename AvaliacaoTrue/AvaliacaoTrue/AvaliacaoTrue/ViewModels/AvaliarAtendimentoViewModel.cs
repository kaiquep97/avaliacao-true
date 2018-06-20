using AvaliacaoTrue.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AvaliacaoTrue.ViewModels
{
    public class AvaliarAtendimentoViewModel
    {
        private Avaliacao avaliacao { get; set; }
        public int NotaServico
        {
            get { return avaliacao.NotaServico; }
            set { avaliacao.NotaServico = value;
                ((Command)ProfessoresCommand).ChangeCanExecute();
            }
        }
        public int NotaLimpeza
        {
            get { return avaliacao.NotaLimpeza; }
            set
            {
                avaliacao.NotaLimpeza = value;
                ((Command)ProfessoresCommand).ChangeCanExecute();
            }
        }
        public int NotaRecepcao
        {
            get { return avaliacao.NotaRecepcao; }
            set
            {
                avaliacao.NotaRecepcao = value;
                ((Command)ProfessoresCommand).ChangeCanExecute();
            }
        }

        public ICommand ProfessoresCommand { get; set; }

        public AvaliarAtendimentoViewModel()
        {
            this.avaliacao = new Avaliacao();
            ProfessoresCommand = new Command(()=> {
                //App.Current.MainPage?.Navigation.PushAsync(new Views.SelecionarProfessorPage(avaliacao));
            }, () =>
            {
                return NotaServico > 0
                && NotaLimpeza > 0
                && NotaRecepcao > 0;
            });
        }

    }
}
