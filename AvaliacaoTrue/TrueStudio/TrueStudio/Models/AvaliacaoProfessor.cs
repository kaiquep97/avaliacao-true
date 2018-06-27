using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrueStudio.Models
{
    public class AvaliacaoProfessor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Professor))]
        public int ProfessorId { get; set; }

        [ManyToOne]
        public Professor Professor { get; set; }

        [ForeignKey(typeof(Avaliacao))]
        public int AvaliacaoId { get; set; }

        public int Instrucao { get; set; }
        public int ResultadoExercicio { get; set; }
        public int Simpatia { get; set; }
        public int Atencao { get; set; }
        public string Comentario { get; set; }

        public AvaliacaoProfessor()
        {

        }
        public AvaliacaoProfessor(Professor professor)
        {
            this.Professor = professor;
            this.ProfessorId = professor.Id;
        }

        public override string ToString()
        {
            if (Professor is null)
            {
                using (var dao = new DAO.ProfessorDAO())
                {
                   this.Professor =  dao.Get(this.ProfessorId);
                }
            }



            var texto = $"{Professor?.Nome};{Instrucao};{ResultadoExercicio};{Simpatia};{Atencao};{Comentario};\n";
            return texto;
        }
    }
}
