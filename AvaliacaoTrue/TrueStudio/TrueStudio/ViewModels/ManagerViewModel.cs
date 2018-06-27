using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TrueStudio.DAO;
using TrueStudio.Interfaces;
using TrueStudio.Models;
using Xamarin.Forms;

namespace TrueStudio.ViewModels
{
    public class ManagerViewModel : BaseViewModel
    {
        public ObservableCollection<Professor> Professores { get; set; }

        public ManagerViewModel()
        {
            Professores = new ObservableCollection<Professor>();
            AtualizaProfessores();
        }

        private void AtualizaProfessores()
        {
            using (var dao = new ProfessorDAO())
            {
                var profs = dao.GetAll();
                Professores = new ObservableCollection<Professor>(profs);
            }
            OnPropertyChanged(nameof(Professores));
        }

        public void AtualizaProfessor(Professor professor)
        {
            professor.Ativo = !professor.Ativo;
            using (var dao = new ProfessorDAO())
            {
                dao.Update(professor);
            }

            AtualizaProfessores();
        }

        public bool GeraRelatorioProfessor()
        {
            StringBuilder sb = new StringBuilder();

            using (var dao= new AvaliacaoDAO())
            {
                var avaliacoes = dao.GetAll();
                List<AvaliacaoProfessor> avaliacaoProfessor= new List<AvaliacaoProfessor>();

                foreach(var av in avaliacoes)
                {
                    avaliacaoProfessor.AddRange(av.AvaliacaoProfessores);
                }

                sb.Append("PROFESSOR;INSTRUCAO;RESULTADO COM O EXERCICIO;SIMPATIA;ATENCAO;COMENTARIO\n");

                foreach (var item in avaliacaoProfessor.OrderBy(x=>x.Id))
                {
                    sb.Append(item);
                }

                var nome = $"Relatorio Avaliacao professores.csv";

                return DependencyService.Get<IFile>().SaveFile(sb.ToString(), nome);
            }
        }

        public bool GeraRelatorioStudio()
        {
            var sb = new StringBuilder();
            using (var dao = new AvaliacaoDAO())
            {
                var avaliacoes = dao.GetAll();

                sb.Append("RECOMENDACAO DO SERVICO;LIMPEZA;RECEPCAO;OBSERVACOES;\n");

                foreach (var item in avaliacoes)
                {
                    sb.Append(item);
                }

                var nome = $"Relatorio avaliacao Studio.csv";

                return DependencyService.Get<IFile>().SaveFile(sb.ToString(), nome);

            }
        }
    }
}
