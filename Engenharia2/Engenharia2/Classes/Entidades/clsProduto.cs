using Engenharia2.Classes.Utils;
using System;
using System.Data;

namespace Engenharia2.Classes.Entidades
{
    class clsProduto : Persistencia
    {
        //atributos
        private Int32 _codigo;
        private String _descricao;
        private Decimal _preco;
        private String _marca;
        private String _observacao;
        private Int32 _quantidade;
        private clsCategoria _categoria;

        //construtores
        public clsProduto()
        {
            Codigo = 0;
            Descricao = "";
            Preco = 0;
            Marca = "";
            Observacao = "";
            Quantidade = 0;
            Categoria = new clsCategoria();
            
        }

        public clsProduto(int codigo)
        {
            Codigo = codigo;
        }

        //gets e sets
        public int Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        public string Descricao
        {
            get
            {
                return _descricao;
            }

            set
            {
                _descricao = value;
            }
        }

        public int Quantidade
        {
            get
            {
                return _quantidade;
            }

            set
            {
                _quantidade = value;
            }
        }

        internal clsCategoria Categoria
        {
            get
            {
                return _categoria;
            }

            set
            {
                _categoria = value;
            }
        }

        public decimal Preco
        {
            get
            {
                return _preco;
            }

            set
            {
                _preco = value;
            }
        }

        public string Marca
        {
            get
            {
                return _marca;
            }

            set
            {
                _marca = value;
            }
        }

        public string Observacao
        {
            get
            {
                return _observacao;
            }

            set
            {
                _observacao = value;
            }
        }

        public int getCodigo() {
            return Codigo;
        }
        public void setCodigo(int codigo) {
            Codigo = codigo;
        }
        public string getDescricao() {
            return Descricao;
        }
        public void setDescricao(string descricao) {
            Descricao = descricao;
        }
        public int getQuantidade() {
            return Quantidade;
        }
        public void setQuantidade(int qtde) {
            Quantidade = qtde;
        }
        public decimal getPreco() {
            return Preco;
        }
        public void setPreco(decimal preco) {
            Preco = preco;
        }
        public string getMarca() {
            return Marca;
        }
        public void setMarca(string marca) {
            Marca = marca;
        }
        public string getObservacao() {
            return Observacao;
        }
        public void setObservacao(string observacao) {
            Observacao = observacao;
        }
        public int getCategoria() {
            return Categoria.getCodigo();
        }
        public string getCategoriaDesc()
        {
            return Categoria.getDescricao();
        }
        public clsCategoria getCategoriaObj() {
            return Categoria;
        }
        public void setCategoria(int codigo) {
            Categoria = new clsCategoria();
            Categoria.setCodigo(codigo);
            Categoria.Select();
        }
        public void setCategoria(clsCategoria categoria) {
            Categoria = categoria;
        }

        //operações
        //falta validações
        //select
        public int Select()
        {
            String sSql = "SELECT * FROM PRODUTO WHERE PROD_CODIGO = "+Codigo;
            DataTable dt = RetornaDT(sSql);
            if (dt.Rows.Count > 0)
            {
                Codigo = Convert.ToInt32(dt.Rows[0]["PROD_CODIGO"].ToString());
                Descricao = dt.Rows[0]["PROD_DESCRICAO"].ToString();
                Marca = dt.Rows[0]["PROD_MARCA"].ToString();
                Quantidade = Convert.ToInt32(dt.Rows[0]["PROD_QTDE"].ToString());
                Preco = Convert.ToDecimal(dt.Rows[0]["PROD_PRECO"].ToString());
                Observacao = dt.Rows[0]["PROD_OBS"].ToString();
                Categoria = new clsCategoria();
                Categoria.setCodigo(Convert.ToInt32(dt.Rows[0]["CAT_CODIGO"].ToString()));
                Categoria.Select();
                //outros atributos
                return 1;
            }
            else
                return 0;
        }

        public DataTable List(string Pesquisa)
        {
            String sSql = "SELECT * FROM PRODUTO";
            if (Pesquisa.Trim().Length > 0)
            {
                sSql += " WHERE PROD_DESCRICAO LIKE '%"+Descricao.Trim()+"%'";
            }
            return RetornaDT(sSql);
        }

        //update
        public int Update()
        {
            String sSql = "UPDATE PRODUTO SET "+
                " PROD_DESCRICAO = '" + Descricao+"',"+
                " PROD_QTDE = " + Quantidade + "," +
                " PROD_PRECO = " + Preco.ToString().Replace(",",".") + "," +
                " PROD_MARCA = '" + Marca + "'," +
                " PROD_OBS = '" + Observacao + "'," +
                " CAT_CODIGO = " + Categoria.getCodigo() +
                " WHERE PROD_CODIGO = " + Codigo;
            int linhas = ExecutaSQL(sSql);
            return linhas;
        }

        //insert
        public int Insert()
        {
            String sSql = "INSERT INTO PRODUTO(PROD_DESCRICAO,PROD_MARCA,PROD_PRECO,PROD_QTDE,PROD_OBS,CAT_CODIGO) "+
                " VALUES('"+Descricao+"', '"+Marca + "', " + Preco.ToString().Replace(",", ".") + ", " + Quantidade + ", '" + Observacao + "', " + Categoria.getCodigo()+")";
            int linhas = ExecutaSQL(sSql);
            return linhas;
        }

        public int Delete()
        {
            String sSql = "DELETE FROM PRODUTO WHERE PROD_CODIGO = " + Codigo;//ADICIONAR ATRIBUTOS
            int linhas = ExecutaSQL(sSql);
            return linhas;
        }
    }
}
