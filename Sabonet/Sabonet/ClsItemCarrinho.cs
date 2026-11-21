using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabonet
{
    public class ClsItemCarrinho
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int Estoque { get; set; }

        public decimal Subtotal
        {
            get { return Preco * Quantidade; }
        }
    }
}