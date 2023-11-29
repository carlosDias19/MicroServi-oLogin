using DDD.Domain.ReportRadarContext;
using DDD.Domain.Services;
using DDD.Infra.SQLServer.Interfaces;
using Domain.ReportRadarContext;
using DomainService.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Service
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

            public List<Usuario> GetUsuario()
            {
                return _usuarioRepository.GetUsuario();
            }

            public Usuario GetUsuarioById(int id)
            {
                return _usuarioRepository.GetUsuarioById(id);
            }

            public void InsertUsuario(Usuario usuario)
            {
            _usuarioRepository.InsertUsuario(usuario);
            }

            public void UpdateUsuario(Usuario usuario)
            {
                _usuarioRepository.UpdateUsuario(usuario);
            }

            public void DeleteUsuario(int id)
            {

                var usuario = _usuarioRepository.GetUsuarioById(id);
                if (usuario == null)
                    throw new Exception("Esse Usuario Não Existe.");

                _usuarioRepository.DeleteUsuario(usuario);
            }

            public string Login(LoginViewModel loginViewModel)
            {
                var usuario = _usuarioRepository.GetUsuarioByEmail(loginViewModel.email);
                if (usuario == null) throw new Exception("Usuario inexistente.");

                if (usuario.Senha != loginViewModel.senha) throw new Exception("Senha errada.");

                var token = TokenService.GenerateToken(usuario);

                return token;
            }
            public Usuario GetUsuarioByEmail(string email)
            {
                return _usuarioRepository.GetUsuarioByEmail(email);
            }
    }
}
