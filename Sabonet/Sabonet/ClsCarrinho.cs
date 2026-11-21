using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabonet
{
    public class ClsCarrinho
    {
        public List<ClsItemCarrinho> Itens
        {
            get
            {
                if (HttpContext.Current.Session["Carrinho"] == null)
                {
                    HttpContext.Current.Session["Carrinho"] =
                        new List<ClsItemCarrinho>();
                }

                return (List<ClsItemCarrinho>)HttpContext.Current.Session["Carrinho"];
            }
        }

        public void Adicionar(ClsItemCarrinho item)
        {
            ClsItemCarrinho existente = Itens.Find(
                x => x.IdProduto == item.IdProduto
            );

            if (existente != null)
            {
                existente.Quantidade += item.Quantidade;
            }
            else
            {
                Itens.Add(item);
            }
        }
    }
}