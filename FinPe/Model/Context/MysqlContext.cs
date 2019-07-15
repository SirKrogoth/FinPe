using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinPe.Model;

namespace FinPe.Model.Context
{
    public class MysqlContext : DbContext
    {
        public MysqlContext()
        {

        }

        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<LogUsuario> LogUsuario { get; set; }
        public DbSet<LogUsuarioDeAtividade> LogUsuarioDeAtividade { get; set; }
    }
}
