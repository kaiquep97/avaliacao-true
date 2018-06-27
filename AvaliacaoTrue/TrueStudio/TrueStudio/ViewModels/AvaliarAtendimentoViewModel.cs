using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TrueStudio.Models;
using Xamarin.Forms;

namespace TrueStudio.ViewModels
{
    public class AvaliarAtendimentoViewModel:BaseViewModel
    {
        private Avaliacao avaliacao { get; set; }
        public int NotaServico
        {
            get { return avaliacao.NotaServico; }
            set
            {
                avaliacao.NotaServico = value;
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

        public string Observacoes
        {
            get { return avaliacao.Observacoes; }
            set
            {
                avaliacao.Observacoes = value;
            }
        }

        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value;
                OnPropertyChanged();
            }
        }


        public ICommand ProfessoresCommand { get; set; }

        public AvaliarAtendimentoViewModel()
        {
            IsVisible = true;
            this.avaliacao = new Avaliacao();
            ProfessoresCommand = new Command(() => {
                IsVisible = false;
                App.Current.MainPage?.Navigation.PushAsync(new Views.ListaProfessorPage(avaliacao));
                IsVisible = true;
            }, () =>
            {
                return NotaServico > 0
                && NotaLimpeza > 0
                && NotaRecepcao > 0;
            });
        }

    }
}
