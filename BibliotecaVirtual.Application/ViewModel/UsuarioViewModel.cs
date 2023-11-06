using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Application.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string nomeCompleto, string email)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
        }

        public UsuarioViewModel(string nomeCompleto, string email, int idLivro)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            IdLivro = idLivro;
        }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public int IdLivro { get; set; }
    }
}
