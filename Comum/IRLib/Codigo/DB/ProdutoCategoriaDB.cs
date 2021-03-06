/******************************************************
* Arquivo ProdutoCategoriaDB.cs
* Gerado em: 15/09/2006
* Autor: Celeritas Ltda
*******************************************************/

using CTLib;
using System;
using System.Data;
using System.Runtime.Serialization;
using System.Text;

namespace IRLib {

	#region "ProdutoCategoria_B"

	public abstract class ProdutoCategoria_B : BaseBD {
	
		public empresaid EmpresaID = new empresaid();
		public nome Nome = new nome();
		public descricao Descricao = new descricao();
		
		public ProdutoCategoria_B(){}
					
		// passar o Usuario logado no sistema
		public ProdutoCategoria_B(int usuarioIDLogado){
			this.Control.UsuarioID = usuarioIDLogado;
		}

		/// <summary>
		/// Preenche todos os atributos de ProdutoCategoria
		/// </summary>
		/// <param name="id">Informe o ID</param>
		/// <returns></returns>
		public override void Ler(int id){
		
			try{
		
				string sql = "SELECT * FROM tProdutoCategoria WHERE ID = " + id;
				bd.Consulta(sql);
				
				if (bd.Consulta().Read()){
					this.Control.ID = id;
					this.EmpresaID.ValorBD = bd.LerInt("EmpresaID").ToString();
					this.Nome.ValorBD = bd.LerString("Nome");
					this.Descricao.ValorBD = bd.LerString("Descricao");
				}else{
					this.Limpar();
				}
				bd.Fechar();
				
			}catch(Exception ex){
				throw ex;
			}
						
		}

		/// <summary>
		/// Preenche todos os atributos de ProdutoCategoria do backup
		/// </summary>
		/// <param name="id">Informe o ID</param>
		/// <returns></returns>
		public void LerBackup(int id){
		
			try{
		
				string sql = "SELECT * FROM xProdutoCategoria WHERE ID = " + id;
				bd.Consulta(sql);
				
				if (bd.Consulta().Read()){
					this.Control.ID = id;
					this.EmpresaID.ValorBD = bd.LerInt("EmpresaID").ToString();
					this.Nome.ValorBD = bd.LerString("Nome");
					this.Descricao.ValorBD = bd.LerString("Descricao");
				}
				bd.Fechar();
				
			}catch(Exception ex){
				throw ex;
			}
						
		}

		protected void InserirControle(string acao){
		
			try{
			
				System.Text.StringBuilder sql = new System.Text.StringBuilder();
				sql.Append("INSERT INTO cProdutoCategoria (ID, Versao, Acao, TimeStamp, UsuarioID) ");
				sql.Append("VALUES (@ID,@V,'@A','@TS',@U)");
				sql.Replace("@ID", this.Control.ID.ToString());
				
				if (!acao.Equals("I"))
					this.Control.Versao++;
				
				sql.Replace("@V", this.Control.Versao.ToString());
				sql.Replace("@A", acao);
				sql.Replace("@TS", DateTime.Now.ToString("yyyyMMddHHmmssffff"));
				sql.Replace("@U", this.Control.UsuarioID.ToString());
				
				bd.Executar(sql.ToString());
	
			}catch(Exception ex){
				throw ex;
			}
					
		}
			
		protected void InserirLog(){
			
			try{
				
				StringBuilder sql = new StringBuilder();
				
				sql.Append("INSERT INTO xProdutoCategoria (ID, Versao, EmpresaID, Nome, Descricao) ");
				sql.Append("SELECT ID, @V, EmpresaID, Nome, Descricao FROM tProdutoCategoria WHERE ID = @I");
				sql.Replace("@I", this.Control.ID.ToString());
				sql.Replace("@V", this.Control.Versao.ToString());
				
				bd.Executar(sql.ToString());
				
			}catch(Exception ex){
				throw ex;
			}
					
		}

		/// <summary>
		/// Inserir novo(a) ProdutoCategoria
		/// </summary>
		/// <returns></returns>	
		public override bool Inserir(){
		
			try{

				bd.IniciarTransacao();
		
				StringBuilder sql = new StringBuilder();
				sql.Append("SELECT MAX(ID) AS ID FROM cProdutoCategoria");
				object obj = bd.ConsultaValor(sql);
				int id = (obj!=null) ? Convert.ToInt32(obj) : 0;
				
				this.Control.ID = ++id;
				this.Control.Versao = 0;
				
				sql = new StringBuilder();
				sql.Append("INSERT INTO tProdutoCategoria(ID, EmpresaID, Nome, Descricao) ");
				sql.Append("VALUES (@ID,@001,'@002','@003')");
				
				sql.Replace("@ID", this.Control.ID.ToString());
				sql.Replace("@001", this.EmpresaID.ValorBD);
				sql.Replace("@002", this.Nome.ValorBD);
				sql.Replace("@003", this.Descricao.ValorBD);
				
				int x = bd.Executar(sql.ToString());
				
				bool result = (x == 1);
				
				if (result)
					InserirControle("I");

				bd.FinalizarTransacao();	
				
				return result;
				
			}catch(Exception ex){
				bd.DesfazerTransacao();
				throw ex;
			}finally{
				bd.Fechar();
			}
			
		}

		/// <summary>
		/// Atualiza ProdutoCategoria
		/// </summary>
		/// <returns></returns>	
		public override bool Atualizar(){
		
			try{

				bd.IniciarTransacao();
		
				string sqlVersion = "SELECT MAX(Versao) FROM cProdutoCategoria WHERE ID="+this.Control.ID;
				object obj = bd.ConsultaValor(sqlVersion);
				int versao = (obj!=null) ? Convert.ToInt32(obj) : 0;
				this.Control.Versao = versao;
				
				InserirControle("U");
				InserirLog();
					
				StringBuilder sql = new StringBuilder();
				sql.Append("UPDATE tProdutoCategoria SET EmpresaID = @001, Nome = '@002', Descricao = '@003' ");
				sql.Append("WHERE ID = @ID");
				sql.Replace("@ID", this.Control.ID.ToString());
				sql.Replace("@001", this.EmpresaID.ValorBD);
				sql.Replace("@002", this.Nome.ValorBD);
				sql.Replace("@003", this.Descricao.ValorBD);
				
				int x = bd.Executar(sql.ToString());
				
				bool result = (x == 1);

				bd.FinalizarTransacao();
				
				return result;
				
			}catch(Exception ex){
				bd.DesfazerTransacao();
				throw ex;
			}finally{
				bd.Fechar();
			}
			
		}

		/// <summary>
		/// Exclui ProdutoCategoria com ID especifico
		/// </summary>
		/// <param name="id">Informe o ID</param>
		/// <returns></returns>
		public override bool Excluir(int id){
		
			try{

				bd.IniciarTransacao();
			
				this.Control.ID=id;
			
				string sqlSelect = "SELECT MAX(Versao) FROM cProdutoCategoria WHERE ID="+this.Control.ID;
				object obj = bd.ConsultaValor(sqlSelect);
				int versao = (obj!=null) ? Convert.ToInt32(obj) : 0;
				this.Control.Versao = versao;
				
				InserirControle("D");
				InserirLog();
					
				string sqlDelete = "DELETE FROM tProdutoCategoria WHERE ID="+id;
				
				int x = bd.Executar(sqlDelete);
				
				bool result = (x == 1);

				bd.FinalizarTransacao();
				
				return result;
			
			}catch(Exception ex){
				bd.DesfazerTransacao();
				throw ex;
			}finally{
				bd.Fechar();
			}
			
		}
		
		/// <summary>
		/// Exclui ProdutoCategoria
		/// </summary>
		/// <returns></returns>		
		public override bool Excluir(){
		
			try{
				return this.Excluir(this.Control.ID);
			}catch(Exception ex){
				throw ex;
			}
			
		}

		public override void Limpar(){
		
			this.EmpresaID.Limpar();
			this.Nome.Limpar();
			this.Descricao.Limpar();
			this.Control.ID = 0;
			this.Control.Versao = 0;
		}

		public override void Desfazer(){
		
			this.Control.Desfazer();
			this.EmpresaID.Desfazer();
			this.Nome.Desfazer();
			this.Descricao.Desfazer();
		}

		public class empresaid : IntegerProperty{
		
			public override string Nome{
				get{
					return "EmpresaID";
				}
			}
			
			public override int Tamanho{
				get{
					return 0;
				}
			}
			
			public override int Valor{
				get{
					return base.Valor;
				}
				set{
					base.Valor = value;
				}
			}
			
			public override string ToString(){
				return base.Valor.ToString();
			}
			
		}
		
		public class nome : TextProperty{
		
			public override string Nome{
				get{
					return "Nome";
				}
			}
			
			public override int Tamanho{
				get{
					return 50;
				}
			}
			
			public override string Valor{
				get{
					return base.Valor;
				}
				set{
					base.Valor = value;
				}
			}
			
			public override string ToString(){
				return base.Valor;
			}
			
		}
		
		public class descricao : TextProperty{
		
			public override string Nome{
				get{
					return "Descricao";
				}
			}
			
			public override int Tamanho{
				get{
					return 0;
				}
			}
			
			public override string Valor{
				get{
					return base.Valor;
				}
				set{
					base.Valor = value;
				}
			}
			
			public override string ToString(){
				return base.Valor;
			}
			
		}
		
		/// <summary>
		/// Obtem uma tabela estruturada com todos os campos dessa classe.
		/// </summary>
		/// <returns></returns>
		public static DataTable Estrutura(){
		
			//Isso eh util para desacoplamento.
			//A Tabela fica vazia e usamos ela para associar a uma tela com baixo nivel de acoplamento.
				
			try{

				DataTable tabela = new DataTable("ProdutoCategoria");
				
				tabela.Columns.Add("ID", typeof(int));
				tabela.Columns.Add("EmpresaID", typeof(int));
				tabela.Columns.Add("Nome", typeof(string));
				tabela.Columns.Add("Descricao", typeof(string));
			
				return tabela;
				
			}catch(Exception ex){
				throw ex;
			}
			
		}		
				
	}
	#endregion

	#region "ProdutoCategoriaLista_B"
	
	public abstract class ProdutoCategoriaLista_B : BaseLista {
	
		private bool backup = false;
		protected ProdutoCategoria produtoCategoria;
	
		// passar o Usuario logado no sistema
		public ProdutoCategoriaLista_B(){
			produtoCategoria = new ProdutoCategoria();
		}
	
		// passar o Usuario logado no sistema
		public ProdutoCategoriaLista_B(int usuarioIDLogado){
			produtoCategoria = new ProdutoCategoria(usuarioIDLogado);
		}
		
		public ProdutoCategoria ProdutoCategoria{
			get{ return produtoCategoria; }
		}

		/// <summary>
		/// Retorna um IBaseBD de ProdutoCategoria especifico
		/// </summary>
		public override IBaseBD this[int indice]{
			get{
				if (indice < 0 || indice >= lista.Count){
					return null;
				}else{
					int id = (int)lista[indice];
					produtoCategoria.Ler(id);
					return produtoCategoria;
				}
			}
		}
		
		/// <summary>
		/// Carrega a lista
		/// </summary>
		/// <param name="tamanhoMax">Informe o tamanho maximo que a lista pode ter</param>
		/// <returns></returns>		
		public void Carregar(int tamanhoMax){
		
			try{
			
				string sql;
			
				if (tamanhoMax==0)
					sql = "SELECT ID FROM tProdutoCategoria";
				else
					sql = "SELECT top "+tamanhoMax+" ID FROM tProdutoCategoria";
				
				if (FiltroSQL!=null && FiltroSQL.Trim()!="")
					sql += " WHERE " + FiltroSQL.Trim();
					
				if (OrdemSQL!=null && OrdemSQL.Trim()!="")
					sql += " ORDER BY " + OrdemSQL.Trim();
				
				lista.Clear();
				
				bd.Consulta(sql);
				
				while (bd.Consulta().Read())
					lista.Add(bd.LerInt("ID"));
				
				lista.TrimToSize();
				
				bd.Fechar();
				
			}catch(Exception ex){
				throw ex;
			}
			
		}
				
		/// <summary>
		/// Carrega a lista
		/// </summary>
		public override void Carregar(){
		
			try{
			
				string sql;
			
				if (tamanhoMax==0)
					sql = "SELECT ID FROM tProdutoCategoria";
				else
					sql = "SELECT top "+tamanhoMax+" ID FROM tProdutoCategoria";
				
				if (FiltroSQL!=null && FiltroSQL.Trim()!="")
					sql += " WHERE " + FiltroSQL.Trim();
					
				if (OrdemSQL!=null && OrdemSQL.Trim()!="")
					sql += " ORDER BY " + OrdemSQL.Trim();
				
				lista.Clear();
				
				bd.Consulta(sql);
				
				while (bd.Consulta().Read())
					lista.Add(bd.LerInt("ID"));
				
				lista.TrimToSize();
				
				bd.Fechar();
				
			}catch(Exception ex){
				throw ex;
			}
			
		}
				
		/// <summary>
		/// Carrega a lista pela tabela x (de backup)
		/// </summary>
		public void CarregarBackup(){
		
			try{
			
				string sql;
			
				if (tamanhoMax==0)
					sql = "SELECT ID FROM xProdutoCategoria";
				else
					sql = "SELECT top "+tamanhoMax+" ID FROM xProdutoCategoria";
				
				if (FiltroSQL!=null && FiltroSQL.Trim()!="")
					sql += " WHERE " + FiltroSQL.Trim();
					
				if (OrdemSQL!=null && OrdemSQL.Trim()!="")
					sql += " ORDER BY " + OrdemSQL.Trim();
				
				lista.Clear();
				
				bd.Consulta(sql);
				
				while (bd.Consulta().Read())
					lista.Add(bd.LerInt("ID"));
				
				lista.TrimToSize();
				
				bd.Fechar();

				backup = true;
				
			}catch(Exception ex){
				throw ex;
			}
			
		}

		/// <summary>
		/// Preenche ProdutoCategoria corrente da lista
		/// </summary>
		/// <param name="id">Informe o ID</param>
		/// <returns></returns>
		protected override void Ler(int id){
			
			try{
		
				if (!backup)
					produtoCategoria.Ler(id);
				else	
					produtoCategoria.LerBackup(id);
				
			}catch(Exception ex){
				throw ex;
			}
			
		}

		/// <summary>
		/// Exclui o item corrente da lista
		/// </summary>
		/// <returns></returns>
		public override bool Excluir(){
		
			try{
		
				bool ok = produtoCategoria.Excluir();
				if (ok)				
					lista.RemoveAt(Indice);
			
				return ok;
				
			}catch(Exception ex){
				throw ex;
			}
			
		}
		
		/// <summary>
		/// Exclui todos os itens da lista carregada
		/// </summary>
		/// <returns></returns>
		public override bool ExcluirTudo(){
			
			try{
				if (lista.Count == 0)
					Carregar();
			}catch(Exception ex){
				throw ex;
			}
			
			try{
		
				bool ok = false;

				if (lista.Count > 0){ //verifica se tem itens

					Ultimo();
					//fazer varredura de traz pra frente.
					do
						ok = Excluir();
					while (ok && Anterior());

				}else{ //nao tem itens na lista
					//Devolve true como se os itens ja tivessem sido excluidos, com a premissa dos ids existirem de fato.
					ok = true;
				}
				
				return ok;
			
			}catch(Exception ex){
				throw ex;
			}

		}		
		
		/// <summary>
		/// Inseri novo(a) ProdutoCategoria na lista
		/// </summary>
		/// <returns></returns>		
		public override bool Inserir(){
		
			try{
		
				bool ok = produtoCategoria.Inserir();
				if (ok){
					lista.Add(produtoCategoria.Control.ID);
					Indice = lista.Count - 1;
				}
			
				return ok;
				
			}catch(Exception ex){
				throw ex;
			}
			
		}

		/// <summary>
		///  Obtem uma tabela de todos os campos de ProdutoCategoria carregados na lista
		/// </summary>
		/// <returns></returns>
		public override DataTable Tabela(){
				
			try{
				
					DataTable tabela = new DataTable("ProdutoCategoria");
				
					tabela.Columns.Add("ID", typeof(int));
					tabela.Columns.Add("EmpresaID", typeof(int));
					tabela.Columns.Add("Nome", typeof(string));
					tabela.Columns.Add("Descricao", typeof(string));
			
				if (this.Primeiro()){

					do{
						DataRow linha = tabela.NewRow();
						linha["ID"]= produtoCategoria.Control.ID;
						linha["EmpresaID"]= produtoCategoria.EmpresaID.Valor;
						linha["Nome"]= produtoCategoria.Nome.Valor;
						linha["Descricao"]= produtoCategoria.Descricao.Valor;
						tabela.Rows.Add(linha);
					}while(this.Proximo());

				}
			
				return tabela;
				
			}catch(Exception ex){
				throw ex;
			}
			
		}
			
		/// <summary>
		/// Obtem uma tabela a ser jogada num relatorio
		/// </summary>
		/// <returns></returns>
		public override DataTable Relatorio(){
				
			try{

				DataTable tabela = new DataTable("RelatorioProdutoCategoria");
			
				if (this.Primeiro()){
				
					tabela.Columns.Add("EmpresaID", typeof(int));
					tabela.Columns.Add("Nome", typeof(string));
					tabela.Columns.Add("Descricao", typeof(string));

					do{
						DataRow linha = tabela.NewRow();
						linha["EmpresaID"]= produtoCategoria.EmpresaID.Valor;
						linha["Nome"]= produtoCategoria.Nome.Valor;
						linha["Descricao"]= produtoCategoria.Descricao.Valor;
						tabela.Rows.Add(linha);
					}while(this.Proximo());

				}else{ //erro: nao carregou a lista
					tabela = null;
				}		
			
				return tabela;
				
			}catch(Exception ex){
				throw ex;
			}

		}		
		
		/// <summary>
		/// Retorna um IDataReader com ID e o Campo.
		/// </summary>
		/// <param name="campo">Informe o campo. Exemplo: Nome</param>
		/// <returns></returns>
		public override IDataReader ListaPropriedade(string campo){
		
			try{
				string sql;
				switch (campo){
					case "EmpresaID":
						sql = "SELECT ID, EmpresaID FROM tProdutoCategoria WHERE "+FiltroSQL+" ORDER BY EmpresaID";
						break;
					case "Nome":
						sql = "SELECT ID, Nome FROM tProdutoCategoria WHERE "+FiltroSQL+" ORDER BY Nome";
						break;
					case "Descricao":
						sql = "SELECT ID, Descricao FROM tProdutoCategoria WHERE "+FiltroSQL+" ORDER BY Descricao";
						break;
					default:
						sql = null;
						break;
				}
				
				IDataReader dataReader = bd.Consulta(sql);

				bd.Fechar();
				
				return dataReader;

			}catch(Exception ex){
				throw ex;
			}
			
		}
		
		/// <summary>
		/// Devolve um array dos IDs que compoem a lista
		/// </summary>
		/// <returns></returns>		
		public override int[] ToArray(){
		
			try{

				int[] a = (int[])lista.ToArray(typeof(int));

				return a;
			
			}catch(Exception ex){
				throw ex;
			}

		}

		/// <summary>
		/// Devolve uma string dos IDs que compoem a lista concatenada por virgula
		/// </summary>
		/// <returns></returns>
		public override string ToString(){
		
			try{

				StringBuilder idsBuffer = new StringBuilder();

				int n = lista.Count;
				for(int i=0; i < n; i++){
					int id = (int)lista[i];
					idsBuffer.Append(id+",");
				}
					
				string ids = "";

				if (idsBuffer.Length > 0){
					ids = idsBuffer.ToString();
					ids = ids.Substring(0, ids.Length -1);
				}

				return ids;
				
			}catch(Exception ex){
				throw ex;
			}

		}		
		
	}
	
	#endregion

	#region "ProdutoCategoriaException"
	
	[Serializable]
	public class ProdutoCategoriaException : Exception {

		public ProdutoCategoriaException() : base (){}

		public ProdutoCategoriaException(string msg) : base (msg){}

		public ProdutoCategoriaException(SerializationInfo info, StreamingContext context) : base(info, context) {}

		public override void GetObjectData(SerializationInfo info, StreamingContext context){
			base.GetObjectData(info, context);
		}

	}

	#endregion
	
}