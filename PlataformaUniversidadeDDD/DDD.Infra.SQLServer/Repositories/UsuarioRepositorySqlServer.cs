

using DDD.Domain.ReportRadarContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class UsuarioRepositorySqlServer : IUsuarioRepository
    {

        private readonly SqlContext _context;

        public UsuarioRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteUsuario(Usuario usuario)
        {
            try
            {
                _context.Set<Usuario>().Remove(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Usuario GetUsuarioById(int id)
        {
            return _context.Usuario.Find(id);
        }

        public List<Usuario> GetUsuario()
        {
            //return  _context.Alunos.Include(x => x.Disciplinas).ToList();
            return _context.Usuario.ToList();

        }

        public void InsertFuncionario(Usuario usuario)
        {
            try
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public void UpdateUsuario(Usuario usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Usuario? GetUsuarioByEmail(string email)
        {
            return _context.Usuario.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
