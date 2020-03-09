﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IIngredienteService
    {
        Task Insert(IngredienteDTO ingrediente);
        Task<List<IngredienteDTO>> GetData();
    }
}