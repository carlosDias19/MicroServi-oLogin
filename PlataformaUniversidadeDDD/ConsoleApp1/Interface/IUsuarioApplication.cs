using DDD.Domain.ReportRadarContext;
using Domain.ReportRadarContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interface
{
    public interface IUsuarioApplication
    {
        void DeleteUsuario(int id);
        List<Usuario> GetUsuario();
        Usuario GetUsuarioById(int id);
        void InsertUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        string Login(LoginViewModel loginViewModel);
        Usuario GetUsuarioByEmail(string email);
    }
}
