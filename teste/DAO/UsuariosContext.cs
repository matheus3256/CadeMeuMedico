using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using teste.Models;

namespace teste.DAO
{
    public class UsuariosContext:DbContext


    {
        public UsuariosContext() : base("TrabalhoMedico")
        {

        }

        public virtual DbSet<Cidades> Cidades { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Estados> Estado { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }       
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }

}