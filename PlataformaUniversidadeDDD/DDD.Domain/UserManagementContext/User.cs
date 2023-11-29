using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.UserManagementContext
{
    public abstract class User
    {
        [Key]
        public int UsuarioId { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? NomeCompleto { get; set; } 
        public bool Ativo { get; set; }
    }
}
