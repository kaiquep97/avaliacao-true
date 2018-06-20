using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrueStudio.Models
{
    public class Professor
    {
        [PrimaryKey, AutoIncrement]
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
