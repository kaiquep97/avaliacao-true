using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AvaliacaoTrue.DAO;
using AvaliacaoTrue.Models;
using Xamarin.Forms;

namespace AvaliacaoTrue.ViewModels
{
    public class AvaliarProfessorViewModel:BaseViewModel
    {
        private Avaliacao avaliacao;
        private IList<Professor> selecionados;
        private AvaliacaoProfessor avaliacaoProfessor;

        public string Nome
        {
            get { return avaliacaoProfessor.Professor.Nome; }
        }


        public int InstrucaoTecnica {
            get { return avaliacaoProfessor.Instrucao; }
            set { avaliacaoProfessor.Instrucao = value;
                ((Command)ProximoCommand).ChangeCanExecute();
            }
        }

        public int ResultadoExercicio
        {
            get { return avaliacaoProfessor.ResultadoExercicio; }
            set
            {
                avaliacaoProfessor.ResultadoExercicio = value;
                ((Command)ProximoCommand).ChangeCanExecute();
            }
        }

        public int Simpatia
        {
            get { return avaliacaoProfessor.Simpatia; }
            set { avaliacaoProfessor.Simpatia = value;
                ((Command)ProximoCommand).ChangeCanExecute();
            }
        }

        public int Atencao
        {
            get { return avaliacaoProfessor.Atencao; }
            set { avaliacaoProfessor.Atencao = value;
                ((Command)ProximoCommand).ChangeCanExecute();
            }
        }

        public ICommand ProximoCommand { get; set; }


        public AvaliarProfessorViewModel(Avaliacao avaliacao, IList<Professor> selecionados)
        {
            this.avaliacao = avaliacao;
            this.selecionados = selecionados;

            avaliacaoProfessor = new AvaliacaoProfessor(selecionados[0]);

            ProximoCommand = new Command(()=> {
                avaliacao.AvaliacaoProfessores.Add(avaliacaoProfessor);
                selecionados?.RemoveAt(0);
                if (selecionados.Count > 0)
                {
                    avaliacaoProfessor = new AvaliacaoProfessor(selecionados[0]);

                    OnPropertyChanged(nameof(Nome));
                    OnPropertyChanged(nameof(Simpatia));
                    OnPropertyChanged(nameof(InstrucaoTecnica));
                    OnPropertyChanged(nameof(Atencao));
                    OnPropertyChanged(nameof(ResultadoExercicio));
                }
                else
                {
                    using (var dao = new AvaliacaoDAO())
                    {
                        dao.Insert(avaliacao);
                        App.Current.MainPage.DisplayAlert("Avaliação", "Avaliação registrada com sucesso!","OK");
                        App.Current.MainPage.Navigation.PopToRootAsync();
                    }
                }
            },()=> {
                return Simpatia > 0
                && InstrucaoTecnica > 0
                && Atencao > 0
                && ResultadoExercicio > 0;
            });

        }
    }
}
