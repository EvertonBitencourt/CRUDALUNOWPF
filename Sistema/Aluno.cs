﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    public class Aluno
    {
        private string nomeCompleto;
        private int codAluno;
        private Ano serie;

        public Aluno()
        {

        }
        public Aluno(string nomeCompleto, int codAluno, Ano serie)
        {
            this.nomeCompleto = nomeCompleto;
            this.codAluno = codAluno;
            this.serie = serie;
        }

        //O que falta aqui?
        public string NomeCompleto
        {
            get { return nomeCompleto; }
            set { nomeCompleto = value; }
        }

        public int CodAluno
        { 
            get { return codAluno; }
            set { codAluno = value; }
        }

        public Ano Serie
        {
            get { return serie; }
            set { serie = value; }
        }
    }

    public enum Ano
    {
        PrimeiraSerie = 1,
        SegundaSerie = 2,
        TerceiraSerie = 3,
        QuartaSerie = 4,
        QuintaSerie = 5,
        SextaSerie = 6,
        SetimaSerie = 7,
        OitavaSerie = 8,
        PrimeiroAnoMedio = 9,
        SegundoAnoMedio = 10,
        TerceiroAnoMedio = 11
    }
}