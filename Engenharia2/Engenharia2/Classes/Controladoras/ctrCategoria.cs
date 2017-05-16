using Engenharia2.Classes.Entidades;
using System.Data;

namespace Engenharia2.Classes.Controladoras
{
    class ctrCategoria
    {
        private clsCategoria _categoria;
        
        public ctrCategoria()
        {
            Categoria = new clsCategoria();
        }

        public ctrCategoria(int codigo, string descricao)
        {
            Categoria = new clsCategoria(codigo, descricao);
        }

        private clsCategoria Categoria
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

        public void setCodigo(int codigo)
        {
            Categoria.setCodigo(codigo);
        }
        public void setDescricao(string descricao)
        {
            Categoria.setDescricao(descricao);
        }
        public int getCodigo()
        {
            return Categoria.getCodigo();
        }
        public string getDescricao()
        {
            return Categoria.getDescricao();
        }

        public void select()
        {
            Categoria.Select();
        }

        public DataTable lista()
        {
            DataTable lista = Categoria.List();
            return lista;
        }

        public void delete()
        {
            Categoria.Delete();
        }

        public void gravar()
        {
            if (Categoria.getCodigo() == 0)
                Categoria.Insert();
            else
                Categoria.Update();
        }
    }
}
