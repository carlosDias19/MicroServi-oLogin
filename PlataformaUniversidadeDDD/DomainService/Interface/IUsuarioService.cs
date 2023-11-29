using DDD.Domain.ReportRadarContext;
using Domain.ReportRadarContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Interface
{
    public interface IUsuarioService
    {
        void DeleteUsuario(int id);
        Usuario GetUsuarioById(int id);
        List<Usuario> GetUsuario();
        void InsertUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);

        string Login(LoginViewModel loginViewModel);
        Usuario GetUsuarioByEmail(string email);
    }
}
