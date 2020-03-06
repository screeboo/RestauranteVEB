﻿using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteVEB.Models
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
    }
}