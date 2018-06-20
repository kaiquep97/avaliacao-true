﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrueStudio.Models
{
    public class Avaliacao
    {
        [PrimaryKey, AutoIncrement]
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
}
