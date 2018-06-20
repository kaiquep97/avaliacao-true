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

        public int Instrucao { get; set; }
        public int ResultadoExercicio { get; set; }
        public int Simpatia { get; set; }
        public int Atencao { get; set; }

        public AvaliacaoProfessor()
        {

        }
        public AvaliacaoProfessor(Professor professor)
        {
            this.Professor = professor;
        }
    }
}
