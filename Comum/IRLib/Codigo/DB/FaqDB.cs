﻿/******************************************************
* Arquivo FaqDB.cs
* Gerado em: 13/04/2011
* Autor: Celeritas Ltda
*******************************************************/

using CTLib;
using System;
using System.Data;
using System.Runtime.Serialization;
using System.Text;

namespace IRLib
{

    #region "Faq_B"

    public abstract class Faq_B : BaseBD
    {

        public pergunta Pergunta = new pergunta();
        public resposta Resposta = new resposta();
        public faqtipoid FaqTipoID = new faqtipoid();
        public tags Tags = new tags();
        public exibicao Exibicao = new exibicao();

        public Faq_B() { }

        // passar o Usuario logado no sistema
        public Faq_B(int usuarioIDLogado)
        {
            this.Control.UsuarioID = usuarioIDLogado;
        }

        /// <summary>
        /// Preenche todos os atributos de Faq
        /// </summary>
        /// <param name="id">Informe o ID</param>
        /// <returns></returns>
        public override void Ler(int id)
        {

            try
            {

                string sql = "SELECT * FROM tFaq WHERE ID = " + id;
                bd.Consulta(sql);

                if (bd.Consulta().Read())
                {
                    this.Control.ID = id;
                    this.Pergunta.ValorBD = bd.LerString("Pergunta");
                    this.Resposta.ValorBD = bd.LerString("Resposta");
                    this.FaqTipoID.ValorBD = bd.LerInt("FaqTipoID").ToString();
                    this.Tags.ValorBD = bd.LerString("Tags");
                    this.Exibicao.ValorBD = bd.LerString("Exibicao");
                }
                else
                {
                    this.Limpar();
                }
                bd.Fechar();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Preenche todos os atributos de Faq do backup
        /// </summary>
        /// <param name="id">Informe o ID</param>
        /// <returns></returns>
        public void LerBackup(int id)
        {

            try
            {

                string sql = "SELECT * FROM xFaq WHERE ID = " + id;
                bd.Consulta(sql);

                if (bd.Consulta().Read())
                {
                    this.Control.ID = id;
                    this.Pergunta.ValorBD = bd.LerString("Pergunta");
                    this.Resposta.ValorBD = bd.LerString("Resposta");
                    this.FaqTipoID.ValorBD = bd.LerInt("FaqTipoID").ToString();
                    this.Tags.ValorBD = bd.LerString("Tags");
                    this.Exibicao.ValorBD = bd.LerString("Exibicao");
                }
                bd.Fechar();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void InserirControle(string acao)
        {

            try
            {

                System.Text.StringBuilder sql = new System.Text.StringBuilder();
                sql.Append("INSERT INTO cFaq (ID, Versao, Acao, TimeStamp, UsuarioID) ");
                sql.Append("VALUES (@ID,@V,'@A','@TS',@U)");
                sql.Replace("@ID", this.Control.ID.ToString());

                if (!acao.Equals("I"))
                    this.Control.Versao++;

                sql.Replace("@V", this.Control.Versao.ToString());
                sql.Replace("@A", acao);
                sql.Replace("@TS", DateTime.Now.ToString("yyyyMMddHHmmssffff"));
                sql.Replace("@U", this.Control.UsuarioID.ToString());

                bd.Executar(sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void InserirLog()
        {

            try
            {

                StringBuilder sql = new StringBuilder();

                sql.Append("INSERT INTO xFaq (ID, Versao, Pergunta, Resposta, FaqTipoID, Tags, Exibicao) ");
                sql.Append("SELECT ID, @V, Pergunta, Resposta, FaqTipoID, Tags, Exibicao FROM tFaq WHERE ID = @I");
                sql.Replace("@I", this.Control.ID.ToString());
                sql.Replace("@V", this.Control.Versao.ToString());

                bd.Executar(sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Inserir novo(a) Faq
        /// </summary>
        /// <returns></returns>	
        public override bool Inserir()
        {

            try
            {

                bd.IniciarTransacao();

                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT MAX(ID) AS ID FROM cFaq");
                object obj = bd.ConsultaValor(sql);
                int id = (obj != null) ? Convert.ToInt32(obj) : 0;

                this.Control.ID = ++id;
                this.Control.Versao = 0;

                sql = new StringBuilder();
                sql.Append("INSERT INTO tFaq(ID, Pergunta, Resposta, FaqTipoID, Tags, Exibicao) ");
                sql.Append("VALUES (@ID,'@001','@002',@003,'@004','@005')");

                sql.Replace("@ID", this.Control.ID.ToString());
                sql.Replace("@001", this.Pergunta.ValorBD);
                sql.Replace("@002", this.Resposta.ValorBD);
                sql.Replace("@003", this.FaqTipoID.ValorBD);
                sql.Replace("@004", this.Tags.ValorBD);
                sql.Replace("@005", this.Exibicao.ValorBD);

                int x = bd.Executar(sql.ToString());

                bool result = (x == 1);

                if (result)
                    InserirControle("I");

                bd.FinalizarTransacao();

                return result;

            }
            catch (Exception ex)
            {
                bd.DesfazerTransacao();
                throw ex;
            }
            finally
            {
                bd.Fechar();
            }

        }

        /// <summary>
        /// Atualiza Faq
        /// </summary>
        /// <returns></returns>	
        public override bool Atualizar()
        {

            try
            {

                bd.IniciarTransacao();

                string sqlVersion = "SELECT MAX(Versao) FROM cFaq WHERE ID=" + this.Control.ID;
                object obj = bd.ConsultaValor(sqlVersion);
                int versao = (obj != null) ? Convert.ToInt32(obj) : 0;
                this.Control.Versao = versao;

                InserirControle("U");
                InserirLog();

                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE tFaq SET Pergunta = '@001', Resposta = '@002', FaqTipoID = @003, Tags = '@004', Exibicao = '@005' ");
                sql.Append("WHERE ID = @ID");
                sql.Replace("@ID", this.Control.ID.ToString());
                sql.Replace("@001", this.Pergunta.ValorBD);
                sql.Replace("@002", this.Resposta.ValorBD);
                sql.Replace("@003", this.FaqTipoID.ValorBD);
                sql.Replace("@004", this.Tags.ValorBD);
                sql.Replace("@005", this.Exibicao.ValorBD);

                int x = bd.Executar(sql.ToString());

                bool result = (x == 1);

                bd.FinalizarTransacao();

                return result;

            }
            catch (Exception ex)
            {
                bd.DesfazerTransacao();
                throw ex;
            }
            finally
            {
                bd.Fechar();
            }

        }

        /// <summary>
        /// Exclui Faq com ID especifico
        /// </summary>
        /// <param name="id">Informe o ID</param>
        /// <returns></returns>
        public override bool Excluir(int id)
        {

            try
            {

                bd.IniciarTransacao();

                this.Control.ID = id;

                string sqlSelect = "SELECT MAX(Versao) FROM cFaq WHERE ID=" + this.Control.ID;
                object obj = bd.ConsultaValor(sqlSelect);
                int versao = (obj != null) ? Convert.ToInt32(obj) : 0;
                this.Control.Versao = versao;

                InserirControle("D");
                InserirLog();

                string sqlDelete = "DELETE FROM tFaq WHERE ID=" + id;

                int x = bd.Executar(sqlDelete);

                bool result = (x == 1);

                bd.FinalizarTransacao();

                return result;

            }
            catch (Exception ex)
            {
                bd.DesfazerTransacao();
                throw ex;
            }
            finally
            {
                bd.Fechar();
            }

        }

        /// <summary>
        /// Exclui Faq
        /// </summary>
        /// <returns></returns>		
        public override bool Excluir()
        {

            try
            {
                return this.Excluir(this.Control.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override void Limpar()
        {

            this.Pergunta.Limpar();
            this.Resposta.Limpar();
            this.FaqTipoID.Limpar();
            this.Tags.Limpar();
            this.Exibicao.Limpar();
            this.Control.ID = 0;
            this.Control.Versao = 0;
        }

        public override void Desfazer()
        {

            this.Control.Desfazer();
            this.Pergunta.Desfazer();
            this.Resposta.Desfazer();
            this.FaqTipoID.Desfazer();
            this.Tags.Desfazer();
            this.Exibicao.Desfazer();
        }

        public class pergunta : TextProperty
        {

            public override string Nome
            {
                get
                {
                    return "Pergunta";
                }
            }

            public override int Tamanho
            {
                get
                {
                    return 300;
                }
            }

            public override string Valor
            {
                get
                {
                    return base.Valor;
                }
                set
                {
                    base.Valor = value;
                }
            }

            public override string ToString()
            {
                return base.Valor;
            }

        }

        public class resposta : TextProperty
        {

            public override string Nome
            {
                get
                {
                    return "Resposta";
                }
            }

            public override int Tamanho
            {
                get
                {
                    return 2000;
                }
            }

            public override string Valor
            {
                get
                {
                    return base.Valor;
                }
                set
                {
                    base.Valor = value;
                }
            }

            public override string ToString()
            {
                return base.Valor;
            }

        }

        public class faqtipoid : IntegerProperty
        {

            public override string Nome
            {
                get
                {
                    return "FaqTipoID";
                }
            }

            public override int Tamanho
            {
                get
                {
                    return 50;
                }
            }

            public override int Valor
            {
                get
                {
                    return base.Valor;
                }
                set
                {
                    base.Valor = value;
                }
            }

            public override string ToString()
            {
                return base.Valor.ToString();
            }

        }

        public class tags : TextProperty
        {

            public override string Nome
            {
                get
                {
                    return "Tags";
                }
            }

            public override int Tamanho
            {
                get
                {
                    return 300;
                }
            }

            public override string Valor
            {
                get
                {
                    return base.Valor;
                }
                set
                {
                    base.Valor = value;
                }
            }

            public override string ToString()
            {
                return base.Valor;
            }

        }

        public class exibicao : TextProperty
        {

            public override string Nome
            {
                get
                {
                    return "Exibicao";
                }
            }

            public override int Tamanho
            {
                get
                {
                    return 1;
                }
            }

            public override string Valor
            {
                get
                {
                    return base.Valor;
                }
                set
                {
                    base.Valor = value;
                }
            }

            public override string ToString()
            {
                return base.Valor;
            }

        }

        /// <summary>
        /// Obtem uma tabela estruturada com todos os campos dessa classe.
        /// </summary>
        /// <returns></returns>
        public static DataTable Estrutura()
        {

            //Isso eh util para desacoplamento.
            //A Tabela fica vazia e usamos ela para associar a uma tela com baixo nivel de acoplamento.

            try
            {

                DataTable tabela = new DataTable("Faq");

                tabela.Columns.Add("ID", typeof(int));
                tabela.Columns.Add("Pergunta", typeof(string));
                tabela.Columns.Add("Resposta", typeof(string));
                tabela.Columns.Add("FaqTipoID", typeof(int));
                tabela.Columns.Add("Tags", typeof(string));
                tabela.Columns.Add("Exibicao", typeof(string));

                return tabela;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
    #endregion

    #region "FaqLista_B"

    public abstract class FaqLista_B : BaseLista
    {

        private bool backup = false;
        protected Faq faq;

        // passar o Usuario logado no sistema
        public FaqLista_B()
        {
            faq = new Faq();
        }

        // passar o Usuario logado no sistema
        public FaqLista_B(int usuarioIDLogado)
        {
            faq = new Faq(usuarioIDLogado);
        }

        public Faq Faq
        {
            get { return faq; }
        }

        /// <summary>
        /// Retorna um IBaseBD de Faq especifico
        /// </summary>
        public override IBaseBD this[int indice]
        {
            get
            {
                if (indice < 0 || indice >= lista.Count)
                {
                    return null;
                }
                else
                {
                    int id = (int)lista[indice];
                    faq.Ler(id);
                    return faq;
                }
            }
        }

        /// <summary>
        /// Carrega a lista
        /// </summary>
        /// <param name="tamanhoMax">Informe o tamanho maximo que a lista pode ter</param>
        /// <returns></returns>		
        public void Carregar(int tamanhoMax)
        {

            try
            {

                string sql;

                if (tamanhoMax == 0)
                    sql = "SELECT ID FROM tFaq";
                else
                    sql = "SELECT top " + tamanhoMax + " ID FROM tFaq";

                if (FiltroSQL != null && FiltroSQL.Trim() != "")
                    sql += " WHERE " + FiltroSQL.Trim();

                if (OrdemSQL != null && OrdemSQL.Trim() != "")
                    sql += " ORDER BY " + OrdemSQL.Trim();

                lista.Clear();

                bd.Consulta(sql);

                while (bd.Consulta().Read())
                    lista.Add(bd.LerInt("ID"));

                lista.TrimToSize();

                bd.Fechar();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Carrega a lista
        /// </summary>
        public override void Carregar()
        {

            try
            {

                string sql;

                if (tamanhoMax == 0)
                    sql = "SELECT ID FROM tFaq";
                else
                    sql = "SELECT top " + tamanhoMax + " ID FROM tFaq";

                if (FiltroSQL != null && FiltroSQL.Trim() != "")
                    sql += " WHERE " + FiltroSQL.Trim();

                if (OrdemSQL != null && OrdemSQL.Trim() != "")
                    sql += " ORDER BY " + OrdemSQL.Trim();

                lista.Clear();

                bd.Consulta(sql);

                while (bd.Consulta().Read())
                    lista.Add(bd.LerInt("ID"));

                lista.TrimToSize();

                bd.Fechar();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Carrega a lista pela tabela x (de backup)
        /// </summary>
        public void CarregarBackup()
        {

            try
            {

                string sql;

                if (tamanhoMax == 0)
                    sql = "SELECT ID FROM xFaq";
                else
                    sql = "SELECT top " + tamanhoMax + " ID FROM xFaq";

                if (FiltroSQL != null && FiltroSQL.Trim() != "")
                    sql += " WHERE " + FiltroSQL.Trim();

                if (OrdemSQL != null && OrdemSQL.Trim() != "")
                    sql += " ORDER BY " + OrdemSQL.Trim();

                lista.Clear();

                bd.Consulta(sql);

                while (bd.Consulta().Read())
                    lista.Add(bd.LerInt("ID"));

                lista.TrimToSize();

                bd.Fechar();

                backup = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Preenche Faq corrente da lista
        /// </summary>
        /// <param name="id">Informe o ID</param>
        /// <returns></returns>
        protected override void Ler(int id)
        {

            try
            {

                if (!backup)
                    faq.Ler(id);
                else
                    faq.LerBackup(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Exclui o item corrente da lista
        /// </summary>
        /// <returns></returns>
        public override bool Excluir()
        {

            try
            {

                bool ok = faq.Excluir();
                if (ok)
                    lista.RemoveAt(Indice);

                return ok;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Exclui todos os itens da lista carregada
        /// </summary>
        /// <returns></returns>
        public override bool ExcluirTudo()
        {

            try
            {
                if (lista.Count == 0)
                    Carregar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {

                bool ok = false;

                if (lista.Count > 0)
                { //verifica se tem itens

                    Ultimo();
                    //fazer varredura de traz pra frente.
                    do
                        ok = Excluir();
                    while (ok && Anterior());

                }
                else
                { //nao tem itens na lista
                    //Devolve true como se os itens ja tivessem sido excluidos, com a premissa dos ids existirem de fato.
                    ok = true;
                }

                return ok;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Inseri novo(a) Faq na lista
        /// </summary>
        /// <returns></returns>		
        public override bool Inserir()
        {

            try
            {

                bool ok = faq.Inserir();
                if (ok)
                {
                    lista.Add(faq.Control.ID);
                    Indice = lista.Count - 1;
                }

                return ok;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        ///  Obtem uma tabela de todos os campos de Faq carregados na lista
        /// </summary>
        /// <returns></returns>
        public override DataTable Tabela()
        {

            try
            {

                DataTable tabela = new DataTable("Faq");

                tabela.Columns.Add("ID", typeof(int));
                tabela.Columns.Add("Pergunta", typeof(string));
                tabela.Columns.Add("Resposta", typeof(string));
                tabela.Columns.Add("FaqTipoID", typeof(int));
                tabela.Columns.Add("Tags", typeof(string));
                tabela.Columns.Add("Exibicao", typeof(string));

                if (this.Primeiro())
                {

                    do
                    {
                        DataRow linha = tabela.NewRow();
                        linha["ID"] = faq.Control.ID;
                        linha["Pergunta"] = faq.Pergunta.Valor;
                        linha["Resposta"] = faq.Resposta.Valor;
                        linha["FaqTipoID"] = faq.FaqTipoID.Valor;
                        linha["Tags"] = faq.Tags.Valor;
                        linha["Exibicao"] = faq.Exibicao.Valor;
                        tabela.Rows.Add(linha);
                    } while (this.Proximo());

                }

                return tabela;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtem uma tabela a ser jogada num relatorio
        /// </summary>
        /// <returns></returns>
        public override DataTable Relatorio()
        {

            try
            {

                DataTable tabela = new DataTable("RelatorioFaq");

                if (this.Primeiro())
                {

                    tabela.Columns.Add("Pergunta", typeof(string));
                    tabela.Columns.Add("Resposta", typeof(string));
                    tabela.Columns.Add("FaqTipoID", typeof(int));
                    tabela.Columns.Add("Tags", typeof(string));
                    tabela.Columns.Add("Exibicao", typeof(string));

                    do
                    {
                        DataRow linha = tabela.NewRow();
                        linha["Pergunta"] = faq.Pergunta.Valor;
                        linha["Resposta"] = faq.Resposta.Valor;
                        linha["FaqTipoID"] = faq.FaqTipoID.Valor;
                        linha["Tags"] = faq.Tags.Valor;
                        linha["Exibicao"] = faq.Exibicao.Valor;
                        tabela.Rows.Add(linha);
                    } while (this.Proximo());

                }
                else
                { //erro: nao carregou a lista
                    tabela = null;
                }

                return tabela;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Retorna um IDataReader com ID e o Campo.
        /// </summary>
        /// <param name="campo">Informe o campo. Exemplo: Nome</param>
        /// <returns></returns>
        public override IDataReader ListaPropriedade(string campo)
        {

            try
            {
                string sql;
                switch (campo)
                {
                    case "Pergunta":
                        sql = "SELECT ID, Pergunta FROM tFaq WHERE " + FiltroSQL + " ORDER BY Pergunta";
                        break;
                    case "Resposta":
                        sql = "SELECT ID, Resposta FROM tFaq WHERE " + FiltroSQL + " ORDER BY Resposta";
                        break;
                    case "FaqTipoID":
                        sql = "SELECT ID, FaqTipoID FROM tFaq WHERE " + FiltroSQL + " ORDER BY FaqTipoID";
                        break;
                    case "Tags":
                        sql = "SELECT ID, Tags FROM tFaq WHERE " + FiltroSQL + " ORDER BY Tags";
                        break;
                    case "Exibicao":
                        sql = "SELECT ID, Exibicao FROM tFaq WHERE " + FiltroSQL + " ORDER BY Exibicao";
                        break;
                    default:
                        sql = null;
                        break;
                }

                IDataReader dataReader = bd.Consulta(sql);

                bd.Fechar();

                return dataReader;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Devolve um array dos IDs que compoem a lista
        /// </summary>
        /// <returns></returns>		
        public override int[] ToArray()
        {

            try
            {

                int[] a = (int[])lista.ToArray(typeof(int));

                return a;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Devolve uma string dos IDs que compoem a lista concatenada por virgula
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            try
            {

                StringBuilder idsBuffer = new StringBuilder();

                int n = lista.Count;
                for (int i = 0; i < n; i++)
                {
                    int id = (int)lista[i];
                    idsBuffer.Append(id + ",");
                }

                string ids = "";

                if (idsBuffer.Length > 0)
                {
                    ids = idsBuffer.ToString();
                    ids = ids.Substring(0, ids.Length - 1);
                }

                return ids;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

    #endregion

    #region "FaqException"

    [Serializable]
    public class FaqException : Exception
    {

        public FaqException() : base() { }

        public FaqException(string msg) : base(msg) { }

        public FaqException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

    }

    #endregion

}