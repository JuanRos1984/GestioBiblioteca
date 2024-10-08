﻿using GestionBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionBiblioteca.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> op)
            :base(op)
        {
            
        }

        public DbSet<Autor> Autor { get; set; }
    }
}
