using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public MessageBox mensagem { get; set; }
        public MainWindowsVM()
        {
            listaAlunos = new ObservableCollection<Aluno>();
            
            IniciaComandos();
        }

        public void IniciaComandos()
        {
            AlunosContext db = new AlunosContext();

            foreach (Aluno aluno in db.Alunos.ToList())
            {
                listaAlunos.Add(aluno);
            }

            Add = new RelayCommand( (object _) => {
                


                Aluno userAluno = new Aluno();

                CadastroAluno tela = new CadastroAluno();
                tela.DataContext = userAluno;
                if (tela.ShowDialog() ?? false) {
                    Console.WriteLine(userAluno.nomecompleto);
                    Console.WriteLine(userAluno.serie);
                    if (userAluno.serie >(Ano)11 || userAluno.serie <(Ano)1 || userAluno.nomecompleto == null ||  userAluno.codaluno == 0)
                    {
                        MessageBox.Show("Dados Inválidos");
     
                    }
                    else { 
                    listaAlunos.Add(userAluno);
                    db.Alunos.Add(userAluno);
                        db.SaveChanges();
                    }
                }
            });
            Remove = new RelayCommand((object _) =>
            {
                db.Alunos.Remove(AlunoSelecionado);
                listaAlunos.Remove(AlunoSelecionado);
                db.SaveChanges();
            }, (object _) => {
                return listaAlunos.Count>0;
            });
            Alterar = new RelayCommand((object _) =>
            {
                if (AlunoSelecionado != null)
                {
                    Aluno userAluno = new Aluno(AlunoSelecionado.nomecompleto, AlunoSelecionado.codaluno, AlunoSelecionado.serie);
                    CadastroAluno tela = new CadastroAluno();
                    tela.DataContext = userAluno;
                    if (tela.ShowDialog() ?? false)
                    {
                        if (userAluno.serie > (Ano)11 || userAluno.serie < (Ano)1 || userAluno.nomecompleto == null || userAluno.nomecompleto == "" || userAluno.codaluno == 0)
                        {
                            MessageBox.Show("Dados Inválidos");
                        }
                        else { 
                            AlunoSelecionado.nomecompleto = userAluno.nomecompleto;
                            AlunoSelecionado.codaluno = userAluno.codaluno;
                            AlunoSelecionado.serie = userAluno.serie;
                            db.Alunos.SqlQuery("update aluno set nomecompleto, serie where codaluno", userAluno);
                            db.SaveChanges();
                         }
                    }
                }
            }, (object _) => {
                return listaAlunos.Count > 0;
            });
        }
    }
}
