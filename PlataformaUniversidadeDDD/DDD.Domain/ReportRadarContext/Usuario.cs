using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ReportRadarContext
{
    public class Usuario : User
    {
        public int Nivel { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
