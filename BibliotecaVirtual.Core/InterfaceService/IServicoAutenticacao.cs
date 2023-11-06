using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Core.InterfaceService
{
    public interface IServicoAutenticacao
    {
        string GerarTokenJWT(string email, string role);
        string ComputarHashSha256(string password);
    }
}
