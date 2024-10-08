﻿using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Email{ get; set; }
        public string Contrasena{ get; set; }
        public string Nombre{ get; set; }
        public string Apellido{ get; set; }
        public bool Activo{ get; set; }
    }
}
