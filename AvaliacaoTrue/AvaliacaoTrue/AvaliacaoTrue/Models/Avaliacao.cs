using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoTrue.Models
{
    public class Avaliacao
    {
        [PrimaryKey,AutoIncrement ]
        public int ID { get; set; }
        public int NotaLimpeza { get; set; }
        public int NotaServico { get; set; }
        public int NotaRecepcao { get; set; }

        [OneToMany]
        public List<AvaliacaoProfessor> AvaliacaoProfessores { get; set; }


        public Avaliacao()
        {
            AvaliacaoProfessores = new List<AvaliacaoProfessor>();
        }
    }


    public class AvaliacaoProfessor
    {
        [PrimaryKey,AutoIncrement]
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


    public class Professor
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        [Ignore]
        public bool Selected { get; set; }
        [Ignore]
        public string AtivoTexto
        {
            get { return Ativo ? "ATIVO" : "DESATIVADO"; }
        }
        public Professor()
        {
            Ativo = true;
        }
    }
}
