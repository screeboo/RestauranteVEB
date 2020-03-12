﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class IngredienteDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public int RefeicaoID { get; set; }
        public IngredienteDTO Refeicao { get; set; }
        public virtual ICollection<RefeicaoDTO> RefeicaoCollection { get; set; }

        public IngredienteDTO()
        {
            this.RefeicaoCollection = new List<RefeicaoDTO>();
        }
    }
}
