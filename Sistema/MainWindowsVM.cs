using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sistema
{
    public class MainWindowsVM
    { 
         public ObservableCollection<Aluno> listaAlunos { get; set; }

        public string nomeCompleto { get; set; }
        public int index { get; set; }

        public int codigo { get; set; }

        public Ano serie { get; set; }
        public ICommand Add { get; private set; }

        public ICommand Remove { get; private set; }

        public ICommand Alterar { get; private set; }

        public Aluno AlunoSelecionado { get; set; }
        

        public MainWindowsVM()
        {
            listaAlunos = new ObservableCollection<Aluno>()
            {
                new Aluno()
                {
                    NomeCompleto = "Everton Bitencourt",
                    CodAluno = 1111,
                    Serie = (Ano) 1
                }
            };
            IniciaComandos();
        }

        public void IniciaComandos()
        {
            
            Add = new RelayCommand( (object _) => {
                /*listaAlunos.Add(new Aluno(nomeCompleto, codigo, (Ano)serie));
                nomeCompleto ="";*/


                Aluno userAluno = new Aluno();

                CadastroAluno tela = new CadastroAluno();
                tela.DataContext = userAluno;
                if (tela.ShowDialog() ?? false) { 
                    listaAlunos.Add(userAluno);
                }
            });
            Remove = new RelayCommand((object _) =>
            {

                listaAlunos.Remove(AlunoSelecionado);
            }, (object _) => {
                return listaAlunos.Count>0;
            });

            Alterar = new RelayCommand((object _) =>
            {
                if (AlunoSelecionado != null)
                {
                    Aluno userAluno = new Aluno(AlunoSelecionado.NomeCompleto, AlunoSelecionado.CodAluno, AlunoSelecionado.Serie);
                    CadastroAluno tela = new CadastroAluno();
                    tela.DataContext = userAluno;
                    if (tela.ShowDialog() ?? false)
                    {
                        /*listaAlunos.Remove(AlunoSelecionado);
                        listaAlunos.Add(userAluno);*/

                        AlunoSelecionado.NomeCompleto = userAluno.NomeCompleto;
                        AlunoSelecionado.CodAluno = userAluno.CodAluno;
                        AlunoSelecionado.Serie = userAluno.Serie;
                    }
                }
            }, (object _) => {
                return listaAlunos.Count > 0;
            });
        }
    }
}
