﻿using System.ComponentModel.DataAnnotations;

namespace Identity.API.Data.DTO
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string Username {  get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
