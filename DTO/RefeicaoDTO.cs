﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class RefeicaoDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public virtual ICollection<PedidoRefeicao> Pedidos { get; set; }

        public RefeicaoDTO()
        {
            this.Pedidos = new List<PedidoRefeicao>();
        }
    }
}
