using Engenharia2.Classes.Entidades;
using System;
using System.Data;

namespace Engenharia2.Classes.Controladoras
{
    class ctrProduto
    {
        private clsProduto produto;

        public ctrProduto()
        {
            produto = new clsProduto();
        }
        //falta validações, mensagens de erro, try catch
        //recebe apenas strings
        public int getCodigo()
        {
            return produto.getCodigo();
        }
        public void setCodigo(string codigo)
        {
            int cod = Convert.ToInt32(codigo);
            produto.setCodigo(cod);
        }
        public string getDescricao()
        {
            return produto.getDescricao();
        }
        public void setDescricao(string descricao)
        {
            produto.setDescricao(descricao);
        }
        public int getQuantidade()
        {
            return produto.getQuantidade();
        }
        public void setQuantidade(string qtde)
        {
            int quantidade = Convert.ToInt32(qtde);
            produto.setQuantidade(quantidade);
        }
        public decimal getPreco()
        {
            return produto.getPreco();
        }
        public void setPreco(string preco)
        {
            decimal p = Convert.ToDecimal(preco);
            produto.setPreco(p);
        }
        public string getMarca()
        {
            return produto.getMarca();
        }
        public void setMarca(string marca)
        {
            produto.setMarca(marca);
        }
        public string getObservacao()
        {
            return produto.getObservacao();
        }
        public void setObservacao(string observacao)
        {
            produto.setObservacao(observacao);
        }
        public int getCategoria()
        {
            return produto.getCategoria();
        }
        
        public string getCategoriaDesc()
        {
            return produto.getCategoriaDesc();
        }
        public void setCategoria(string codigo)
        {
            int cod = Convert.ToInt32(codigo);
            produto.setCategoria(cod);
        }

        public int Gravar()
        {
            if (produto.getCodigo() == 0)
            {
                return produto.Insert();
            }else
            {
                return produto.Update();
            }
        }

        public void Delete() {
            produto.Delete();
        }

        public void Select() {
            produto.Select();
        }

        public DataTable List() {
            return produto.List("");
        }
        
    }
}
