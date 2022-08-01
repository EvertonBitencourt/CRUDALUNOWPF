using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    [Table("aluno", Schema = "public")]
    public class Aluno : INotifyPropertyChanged
    {

        private string nomeCompleto;

        private int codAluno;
        private Ano laserie;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void Notifica(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Aluno()
        {

        }
        public Aluno(string nomeCompleto, int codAluno, Ano serie)
        {
            this.nomeCompleto = nomeCompleto;
            this.codAluno = codAluno;
            this.laserie = serie;
        }

        //O que falta aqui?
        public string nomecompleto
        {
            get { return nomeCompleto; }
            set {
                nomeCompleto = value;
                Notifica("nomeCompleto");
            }
        }
        [Key]
        public int codaluno
        {
            get { return codAluno; }
            set {
                codAluno = value;
                Notifica("CodAluno");
            }
        }

        public Ano serie
        {
            get { return laserie; }
            set {
                laserie = value;
                Notifica("Serie");
            }
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
