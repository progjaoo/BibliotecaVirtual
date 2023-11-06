using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Application.ViewModel
{
    public class ComentariosViewModel 
    {
        public ComentariosViewModel(int id, int idUsuario, string conteudo, DateTime? criadoEm)
        {
            Id = id;
            IdUsuario = idUsuario;
            Conteudo = conteudo;
            CriadoEm = criadoEm;
        }

        public ComentariosViewModel(int id, int idUsuario, UsuarioViewModel usuario, string conteudo, DateTime? criadoEm)
        {
            Id = id;
            IdUsuario = idUsuario;
            Usuario = usuario;
            Conteudo = conteudo;
            CriadoEm = criadoEm;
        }

        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public UsuarioViewModel Usuario { get; set; }

        public string Conteudo { get; set; }

        public DateTime? CriadoEm { get; set; }
    } 
}
