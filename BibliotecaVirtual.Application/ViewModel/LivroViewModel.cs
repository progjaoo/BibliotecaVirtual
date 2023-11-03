using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Application.ViewModel
{
    public class LivroViewModel
    {
        public LivroViewModel(int id, string titulo, string autor)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;

        }
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Autor { get; set; }
    }
}
