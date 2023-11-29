using ApplicationService.Interface;
using DDD.Domain.ReportRadarContext;
using DomainService.Interface;
using Domain.ReportRadarContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        public readonly IUsuarioService _usuarioService;

        public UsuarioApplication(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public List<Usuario> GetUsuario()
        {
            return _usuarioService.GetUsuario();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _usuarioService.GetUsuarioById(id);
        }

        public void InsertUsuario(Usuario usuario)
        {
            _usuarioService.InsertUsuario(usuario);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _usuarioService.UpdateUsuario(usuario);
        }

        public void DeleteUsuario(int id)
        {
            _usuarioService.DeleteUsuario(id);
        }
        public string Login(LoginViewModel loginViewModel)
        {
            return _usuarioService.Login(loginViewModel);
        }
        public Usuario GetUsuarioByEmail(string email)
        {
            return _usuarioService.GetUsuarioByEmail(email);
        }

    }
}
