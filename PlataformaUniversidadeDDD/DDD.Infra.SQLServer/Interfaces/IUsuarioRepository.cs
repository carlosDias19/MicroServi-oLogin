
using DDD.Domain.ReportRadarContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IUsuarioRepository
    {
        public List<Usuario> GetUsuario();
        public Usuario GetUsuarioById(int id);
        public void InsertUsuario(Usuario usuario);
        public void UpdateUsuario(Usuario usuario);
        public void DeleteUsuario(Usuario usuario);

        Usuario? GetUsuarioByEmail(string email);
    }
}
