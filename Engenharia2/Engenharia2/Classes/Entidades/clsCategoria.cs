using Engenharia2.Classes.Utils;
using System;
using System.Data;

namespace Engenharia2.Classes.Entidades
{
    class clsCategoria : Persistencia
    {
        //atributos
        private Int32 _codigo;
        private String _descricao;

        //construtores
        public clsCategoria()
        {
            _codigo = 0;
            _descricao = "";
        }

        public clsCategoria(int codigo, string descricao)
        {
            _codigo = codigo;
            _descricao = descricao;
        }

        //gets e sets

        public void setCodigo(int codigo)
        {
            _codigo = codigo;
        }
        public void setDescricao(string descricao)
        {
            _descricao = descricao;
        }

        public int getCodigo()
        {
            return _codigo;
        }
        public string getDescricao()
        {
            return _descricao;
        }
        //operações
        //falta validações
        //select
        public int Select()
        {
            String sSql = "SELECT * FROM CATEGORIA WHERE CAT_CODIGO = "+_codigo;
            DataTable dt = RetornaDT(sSql);
            if (dt.Rows.Count > 0)
            {
                _codigo = Convert.ToInt32(dt.Rows[0]["CAT_CODIGO"].ToString());
                _descricao = dt.Rows[0]["CAT_DESCRICAO"].ToString();
                //outros atributos
                return 1;
            }
            else
                return 0;
        }

        //listar
        public DataTable List()
        {
            //List<clsCategoria> lista = new List<clsCategoria>();
            //clsCategoria cat;
            bool ultimo = false;
            String sSql = "SELECT * FROM CATEGORIA";
            if (_descricao.Trim().Length > 0)
            {
                sSql += " WHERE CAT_DESCRICAO LIKE '%" + _descricao.Trim() + "%'";
                ultimo = true;
            }
            if(_codigo!=0)
            {
                if(ultimo)
                    sSql += " AND CAT_CODIGO = " + _codigo;
                else
                    sSql += " WHERE CAT_CODIGO = " + _codigo;
            }
            //DataTable dt = RetornaDT(sSql);
            return RetornaDT(sSql);
            /*for (int i = 0; i < dt.Rows.Count; i++)
            {
                cat = new clsCategoria();
                cat.setCodigo( Convert.ToInt32(dt.Rows[i]["CAT_CODIGO"].ToString()));
                cat.setDescricao( dt.Rows[i]["CAT_DESCRICAO"].ToString());
                lista.Add(cat);
            }
            return lista;*/
        }

        //update
        public int Update()
        {
            String sSql = "UPDATE CATEGORIA SET CAT_DESCRICAO = '" +_descricao+"'"+//ADICIONAR ATRIBUTOS
                " WHERE CAT_CODIGO = " + _codigo;
            int linhas = ExecutaSQL(sSql);
            return linhas;
        }

        //insert
        public int Insert()
        {
            String sSql = "INSERT INTO CATEGORIA(CAT_DESCRICAO) VALUES('"+_descricao+"')";//ADICIONAR ATRIBUTOS
            int linhas = ExecutaSQL(sSql);
            return linhas;
        }

        public int Delete()
        {
            String sSql = "DELETE FROM CATEGORIA WHERE CAT_CODIGO = "+_codigo;//ADICIONAR ATRIBUTOS
            int linhas = ExecutaSQL(sSql);
            return linhas;
        }
    }
}
