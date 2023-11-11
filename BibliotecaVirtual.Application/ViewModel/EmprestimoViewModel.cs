using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Application.ViewModel
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(int idLivro, int idUsuario, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            IdLivro = idLivro;
            IdUsuario = idUsuario;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }

        public int IdLivro { get; set; }

        public int IdUsuario { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
