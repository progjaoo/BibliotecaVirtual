using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Application.ViewModel
{
    public class LoginUsuarioViewModel
    {
        public LoginUsuarioViewModel(string email, string token )
        {
            Email = email;
            Token = token;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
