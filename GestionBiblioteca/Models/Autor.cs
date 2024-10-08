﻿using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; } 
        public string Nombre { get; set;}
        public bool Activo { get; set;}
    }
}
