using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Application.ViewModel
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
