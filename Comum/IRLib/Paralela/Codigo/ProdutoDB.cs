/******************************************************
* Arquivo ProdutoDB.cs
* Gerado em: 15/09/2006
* Autor: Celeritas Ltda
*******************************************************/

using CTLib;
using System;
using System.Data;
using System.Runtime.Serialization;
using System.Text;

namespace IRLib.Paralela {

	#region "Produto_B"

	public abstract class Produto_B : BaseBD {
	
		public empresaid EmpresaID = new empresaid();
		public nome Nome = new nome();
		public produtocategoriaid ProdutoCategoriaID = new produtocategoriaid();
		public precovenda PrecoVenda = new precovenda();
		public precocompra PrecoCompra = new precocompra();
		public foradelinha ForaDeLinha = new foradelinha();
		public unidadedecompra UnidadeDeCompra = new unidadedecompra();
		public unidadedeuso UnidadeDeUso = new unidadedeuso();
		public coeficientedeconversao CoeficienteDeConversao = new coeficientedeconversao();
		public obs Obs = new obs();
		
		public Produto_B(){}
					
		// passar o Usuario logado no sistema
		public Produto_B(int usuarioIDLogado){
			this.Control.UsuarioID = usuarioIDLogado;
		}

		/// <summary>
		/// Preenche todos os atributos de Produto
		/// </summary>
		/// <param name="id">Informe o ID</param>
		/// <returns></returns>
		public override void Ler(int id){
		
			try{
		
				string sql = "SELECT * FROM tProduto WHERE ID = " + id;
				bd.Consulta(sql);
				
				if (bd.Consulta().Read()){
					this.Control.ID = id;
					this.EmpresaID.ValorBD = bd.LerInt("EmpresaID").ToString();
					this.Nome.ValorBD = bd.LerString("Nome");
					this.ProdutoCategoriaID.ValorBD = bd.LerInt("ProdutoCategoriaID").ToString();
					this.PrecoVenda.ValorBD = bd.LerDecimal("PrecoVenda").ToString();
					this.PrecoCompra.ValorBD = bd.LerDecimal("PrecoCompra").ToString();
					this.ForaDeLinha.ValorBD = bd.LerString("ForaDeLinha");
					this.UnidadeDeCompra.ValorBD = bd.LerString("UnidadeDeCompra");
					this.UnidadeDeUso.ValorBD = bd.LerString("UnidadeDeUso");
					this.CoeficienteDeConversao.ValorBD = bd.LerDecimal("CoeficienteDeConversao").ToString();
					this.Obs.ValorBD = bd.LerString("Obs");
				}else{
					this.Limpar();
				}
				bd.Fechar();
				
			}catch(Exception ex){
				throw ex;
			}
						
		}

		/// <summary>
		/// Preenche todos os atributos de Produto do backup
		/// </summary>
		/// <param name="id">Informe o ID</param>
		/// <returns></returns>
		public void LerBackup(int id){
		
			try{
		
				string sql = "SELECT * FROM xProduto WHERE ID = " + id;
				bd.Consulta(sql);
				
				if (bd.Consulta().Read()){
					this.Control.ID = id;
					this.EmpresaID.ValorBD = bd.LerInt("EmpresaID").ToString();
					this.Nome.ValorBD = bd.LerString("Nome");
					this.ProdutoCategoriaID.ValorBD = bd.LerInt("ProdutoCategoriaID").ToString();
					this.PrecoVenda.ValorBD = bd.LerDecimal("PrecoVenda").ToString();
					this.PrecoCompra.ValorBD = bd.LerDecimal("PrecoCompra").ToString();
					this.ForaDeLinha.ValorBD = bd.LerString("ForaDeLinha");
					this.UnidadeDeCompra.ValorBD = bd.LerString("UnidadeDeCompra");
					this.UnidadeDeUso.ValorBD = bd.LerString("UnidadeDeUso");
					this.CoeficienteDeConversao.ValorBD = bd.LerDecimal("CoeficienteDeConversao").ToString();
					this.Obs.ValorBD = bd.LerString("Obs");
				}
				bd.Fechar();
				
			}catch(Exception ex){
				throw ex;
			}
						
		}

		protected void InserirControle(string acao){
		
			try{
			
				System.Text.StringBuilder sql = new System.Text.StringBuilder();
				sql.Append("INSERT INTO cProduto (ID, Versao, Acao, TimeStamp, UsuarioID) ");
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
				
				sql.Append("INSERT INTO xProduto (ID, Versao, EmpresaID, Nome, ProdutoCategoriaID, PrecoVenda, PrecoCompra, ForaDeLinha, UnidadeDeCompra, UnidadeDeUso, CoeficienteDeConversao, Obs) ");
				sql.Append("SELECT ID, @V, EmpresaID, Nome, ProdutoCategoriaID, PrecoVenda, PrecoCompra, ForaDeLinha, UnidadeDeCompra, UnidadeDeUso, CoeficienteDeConversao, Obs FROM tProduto WHERE ID = @I");
				sql.Replace("@I", this.Control.ID.ToString());
				sql.Replace("@V", this.Control.Versao.ToString());
				
				bd.Executar(sql.ToString());
				
			}catch(Exception ex){
				throw ex;
			}
					
		}

		/// <summary>
		/// Inserir novo(a) Produto
		/// </summary>
		/// <returns></returns>	
		public override bool Inserir(){
		
			try{

				bd.IniciarTransacao();
		
				StringBuilder sql = new StringBuilder();
				sql.Append("SELECT MAX(ID) AS ID FROM cProduto");
				object obj = bd.ConsultaValor(sql);
				int id = (obj!=null) ? Convert.ToInt32(obj) : 0;
				
				this.Control.ID = ++id;
				this.Control.Versao = 0;
				
				sql = new StringBuilder();
				sql.Append("INSERT INTO tProduto(ID, EmpresaID, Nome, ProdutoCategoriaID, PrecoVenda, PrecoCompra, ForaDeLinha, UnidadeDeCompra, UnidadeDeUso, CoeficienteDeConversao, Obs) ");
				sql.Append("VALUES (@ID,@001,'@002',@003,'@004','@005','@006','@007','@008','@009','@010')");
				
				sql.Replace("@ID", this.Control.ID.ToString());
				sql.Replace("@001", this.EmpresaID.ValorBD);
				sql.Replace("@002", this.Nome.ValorBD);
				sql.Replace("@003", this.ProdutoCategoriaID.ValorBD);
				sql.Replace("@004", this.PrecoVenda.ValorBD);
				sql.Replace("@005", this.PrecoCompra.ValorBD);
				sql.Replace("@006", this.ForaDeLinha.ValorBD);
				sql.Replace("@007", this.UnidadeDeCompra.ValorBD);
				sql.Replace("@008", this.UnidadeDeUso.ValorBD);
				sql.Replace("@009", this.CoeficienteDeConversao.ValorBD);
				sql.Replace("@010", this.Obs.ValorBD);
				
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
		/// Atualiza Produto
		/// </summary>
		/// <returns></returns>	
		public override bool Atualizar(){
		
			try{

				bd.IniciarTransacao();
		
				string sqlVersion = "SELECT MAX(Versao) FROM cProduto WHERE ID="+this.Control.ID;
				object obj = bd.ConsultaValor(sqlVersion);
				int versao = (obj!=null) ? Convert.ToInt32(obj) : 0;
				this.Control.Versao = versao;
				
				InserirControle("U");
				InserirLog();
					
				StringBuilder sql = new StringBuilder();
				sql.Append("UPDATE tProduto SET EmpresaID = @001, Nome = '@002', ProdutoCategoriaID = @003, PrecoVenda = '@004', PrecoCompra = '@005', ForaDeLinha = '@006', UnidadeDeCompra = '@007', UnidadeDeUso = '@008', CoeficienteDeConversao = '@009', Obs = '@010' ");
				sql.Append("WHERE ID = @ID");
				sql.Replace("@ID", this.Control.ID.ToString());
				sql.Replace("@001", this.EmpresaID.ValorBD);
				sql.Replace("@002", this.Nome.ValorBD);
				sql.Replace("@003", this.ProdutoCategoriaID.ValorBD);
				sql.Replace("@004", this.PrecoVenda.ValorBD);
				sql.Replace("@005", this.PrecoCompra.ValorBD);
				sql.Replace("@006", this.ForaDeLinha.ValorBD);
				sql.Replace("@007", this.UnidadeDeCompra.ValorBD);
				sql.Replace("@008", this.UnidadeDeUso.ValorBD);
				sql.Replace("@009", this.CoeficienteDeConversao.ValorBD);
				sql.Replace("@010", this.Obs.ValorBD);
				
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
		/// Exclui Produto com ID especifico
		/// </summary>
		/// <param name="id">Informe o ID</param>
		/// <returns></returns>
		public override bool Excluir(int id){
		
			try{

				bd.IniciarTransacao();
			
				this.Control.ID=id;
			
				string sqlSelect = "SELECT MAX(Versao) FROM cProduto WHERE ID="+this.Control.ID;
				object obj = bd.ConsultaValor(sqlSelect);
				int versao = (obj!=null) ? Convert.ToInt32(obj) : 0;
				this.Control.Versao = versao;
				
				InserirControle("D");
				InserirLog();
					
				string sqlDelete = "DELETE FROM tProduto WHERE ID="+id;
				
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
		/// Exclui Produto
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
			this.ProdutoCategoriaID.Limpar();
			this.PrecoVenda.Limpar();
			this.PrecoCompra.Limpar();
			this.ForaDeLinha.Limpar();
			this.UnidadeDeCompra.Limpar();
			this.UnidadeDeUso.Limpar();
			this.CoeficienteDeConversao.Limpar();
			this.Obs.Limpar();
			this.Control.ID = 0;
			this.Control.Versao = 0;
		}

		public override void Desfazer(){
		
			this.Control.Desfazer();
			this.EmpresaID.Desfazer();
			this.Nome.Desfazer();
			this.ProdutoCategoriaID.Desfazer();
			this.PrecoVenda.Desfazer();
			this.PrecoCompra.Desfazer();
			this.ForaDeLinha.Desfazer();
			this.UnidadeDeCompra.Desfazer();
			this.UnidadeDeUso.Desfazer();
			this.CoeficienteDeConversao.Desfazer();
			this.Obs.Desfazer();
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
		
		public class produtocategoriaid : IntegerProperty{
		
			public override string Nome{
				get{
					return "ProdutoCategoriaID";
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
		
		public class precovenda : NumberProperty{
		
			public override string Nome{
				get{
					return "PrecoVenda";
				}
			}
			
			public override int Tamanho{
				get{
					return 12;
				}
			}
			
			public override decimal Valor{
				get{
					return base.Valor;
				}
				set{
					base.Valor = value;
				}
			}
			
			public override string ToString(){
				return base.Valor.ToString("###,##0.00");
			}
			
		}
		
		public class precocompra : NumberProperty{
		
			public override string Nome{
				get{
					return "PrecoCompra";
				}
			}
			
			public override int Tamanho{
				get{
					return 12;
				}
			}
			
			public override decimal Valor{
				get{
					return base.Valor;
				}
				set{
					base.Valor = value;
				}
			}
			
			public override string ToString(){
				return base.Valor.ToString("###,##0.00");
			}
			
		}
		
		public class foradelinha : BooleanProperty{
		
			public override string Nome{
				get{
					return "ForaDeLinha";
				}
			}
			
			public override int Tamanho{
				get{
					return 0;
				}
			}
			
			public override bool Valor{
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
		
		public class unidadedecompra : TextProperty{
		
			public override string Nome{
				get{
					return "UnidadeDeCompra";
				}
			}
			
			public override int Tamanho{
				get{
					return 20;
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
		
		public class unidadedeuso : TextProperty{
		
			public override string Nome{
				get{
					return "UnidadeDeUso";
				}
			}
			
			public override int Tamanho{
				get{
					return 20;
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
		
		public class coeficientedeconversao : NumberProperty{
		
			public override string Nome{
				get{
					return "CoeficienteDeConversao";
				}
			}
			
			public override int Tamanho{
				get{
					return 12;
				}
			}
			
			public override decimal Valor{
				get{
					return base.Valor;
				}
				set{
					base.Valor = value;
				}
			}
			
			public override string ToString(){
				return base.Valor.ToString("###,##0.00");
			}
			
		}
		
		public class obs : TextProperty{
		
			public override string Nome{
				get{
					return "Obs";
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

				DataTable tabela = new DataTable("Produto");
				
				tabela.Columns.Add("ID", typeof(int));
				tabela.Columns.Add("EmpresaID", typeof(int));
				tabela.Columns.Add("Nome", typeof(string));
				tabela.Columns.Add("ProdutoCategoriaID", typeof(int));
				tabela.Columns.Add("PrecoVenda", typeof(decimal));
				tabela.Columns.Add("PrecoCompra", typeof(decimal));
				tabela.Columns.Add("ForaDeLinha", typeof(bool));
				tabela.Columns.Add("UnidadeDeCompra", typeof(string));
				tabela.Columns.Add("UnidadeDeUso", typeof(string));
				tabela.Columns.Add("CoeficienteDeConversao", typeof(decimal));
				tabela.Columns.Add("Obs", typeof(string));
			
				return tabela;
				
			}catch(Exception ex){
				throw ex;
			}
			
		}		
				
		public abstract DataTable ItensPedidos();

		public abstract DataTable ItensEstoques();

	}
	#endregion

	#region "ProdutoLista_B"
	
	public abstract class ProdutoLista_B : BaseLista {
	
		private bool backup = false;
		protected Produto produto;
	
		// passar o Usuario logado no sistema
		public ProdutoLista_B(){
			produto = new Produto();
		}
	
		// passar o Usuario logado no sistema
		public ProdutoLista_B(int usuarioIDLogado){
			produto = new Produto(usuarioIDLogado);
		}
		
		public Produto Produto{
			get{ return produto; }
		}

		/// <summary>
		/// Retorna um IBaseBD de Produto especifico
		/// </summary>
		public override IBaseBD this[int indice]{
			get{
				if (indice < 0 || indice >= lista.Count){
					return null;
				}else{
					int id = (int)lista[indice];
					produto.Ler(id);
					return produto;
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
					sql = "SELECT ID FROM tProduto";
				else
					sql = "SELECT top "+tamanhoMax+" ID FROM tProduto";
				
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
					sql = "SELECT ID FROM tProduto";
				else
					sql = "SELECT top "+tamanhoMax+" ID FROM tProduto";
				
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
					sql = "SELECT ID FROM xProduto";
				else
					sql = "SELECT top "+tamanhoMax+" ID FROM xProduto";
				
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
		/// Preenche Produto corrente da lista
		/// </summary>
		/// <param name="id">Informe o ID</param>
		/// <returns></returns>
		protected override void Ler(int id){
			
			try{
		
				if (!backup)
					produto.Ler(id);
				else	
					produto.LerBackup(id);
				
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
		
				bool ok = produto.Excluir();
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
		/// Inseri novo(a) Produto na lista
		/// </summary>
		/// <returns></returns>		
		public override bool Inserir(){
		
			try{
		
				bool ok = produto.Inserir();
				if (ok){
					lista.Add(produto.Control.ID);
					Indice = lista.Count - 1;
				}
			
				return ok;
				
			}catch(Exception ex){
				throw ex;
			}
			
		}

		/// <summary>
		///  Obtem uma tabela de todos os campos de Produto carregados na lista
		/// </summary>
		/// <returns></returns>
		public override DataTable Tabela(){
				
			try{
				
					DataTable tabela = new DataTable("Produto");
				
					tabela.Columns.Add("ID", typeof(int));
					tabela.Columns.Add("EmpresaID", typeof(int));
					tabela.Columns.Add("Nome", typeof(string));
					tabela.Columns.Add("ProdutoCategoriaID", typeof(int));
					tabela.Columns.Add("PrecoVenda", typeof(decimal));
					tabela.Columns.Add("PrecoCompra", typeof(decimal));
					tabela.Columns.Add("ForaDeLinha", typeof(bool));
					tabela.Columns.Add("UnidadeDeCompra", typeof(string));
					tabela.Columns.Add("UnidadeDeUso", typeof(string));
					tabela.Columns.Add("CoeficienteDeConversao", typeof(decimal));
					tabela.Columns.Add("Obs", typeof(string));
			
				if (this.Primeiro()){

					do{
						DataRow linha = tabela.NewRow();
						linha["ID"]= produto.Control.ID;
						linha["EmpresaID"]= produto.EmpresaID.Valor;
						linha["Nome"]= produto.Nome.Valor;
						linha["ProdutoCategoriaID"]= produto.ProdutoCategoriaID.Valor;
						linha["PrecoVenda"]= produto.PrecoVenda.Valor;
						linha["PrecoCompra"]= produto.PrecoCompra.Valor;
						linha["ForaDeLinha"]= produto.ForaDeLinha.Valor;
						linha["UnidadeDeCompra"]= produto.UnidadeDeCompra.Valor;
						linha["UnidadeDeUso"]= produto.UnidadeDeUso.Valor;
						linha["CoeficienteDeConversao"]= produto.CoeficienteDeConversao.Valor;
						linha["Obs"]= produto.Obs.Valor;
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

				DataTable tabela = new DataTable("RelatorioProduto");
			
				if (this.Primeiro()){
				
					tabela.Columns.Add("EmpresaID", typeof(int));
					tabela.Columns.Add("Nome", typeof(string));
					tabela.Columns.Add("ProdutoCategoriaID", typeof(int));
					tabela.Columns.Add("PrecoVenda", typeof(decimal));
					tabela.Columns.Add("PrecoCompra", typeof(decimal));
					tabela.Columns.Add("ForaDeLinha", typeof(bool));
					tabela.Columns.Add("UnidadeDeCompra", typeof(string));
					tabela.Columns.Add("UnidadeDeUso", typeof(string));
					tabela.Columns.Add("CoeficienteDeConversao", typeof(decimal));
					tabela.Columns.Add("Obs", typeof(string));

					do{
						DataRow linha = tabela.NewRow();
						linha["EmpresaID"]= produto.EmpresaID.Valor;
						linha["Nome"]= produto.Nome.Valor;
						linha["ProdutoCategoriaID"]= produto.ProdutoCategoriaID.Valor;
						linha["PrecoVenda"]= produto.PrecoVenda.Valor;
						linha["PrecoCompra"]= produto.PrecoCompra.Valor;
						linha["ForaDeLinha"]= produto.ForaDeLinha.Valor;
						linha["UnidadeDeCompra"]= produto.UnidadeDeCompra.Valor;
						linha["UnidadeDeUso"]= produto.UnidadeDeUso.Valor;
						linha["CoeficienteDeConversao"]= produto.CoeficienteDeConversao.Valor;
						linha["Obs"]= produto.Obs.Valor;
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
						sql = "SELECT ID, EmpresaID FROM tProduto WHERE "+FiltroSQL+" ORDER BY EmpresaID";
						break;
					case "Nome":
						sql = "SELECT ID, Nome FROM tProduto WHERE "+FiltroSQL+" ORDER BY Nome";
						break;
					case "ProdutoCategoriaID":
						sql = "SELECT ID, ProdutoCategoriaID FROM tProduto WHERE "+FiltroSQL+" ORDER BY ProdutoCategoriaID";
						break;
					case "PrecoVenda":
						sql = "SELECT ID, PrecoVenda FROM tProduto WHERE "+FiltroSQL+" ORDER BY PrecoVenda";
						break;
					case "PrecoCompra":
						sql = "SELECT ID, PrecoCompra FROM tProduto WHERE "+FiltroSQL+" ORDER BY PrecoCompra";
						break;
					case "ForaDeLinha":
						sql = "SELECT ID, ForaDeLinha FROM tProduto WHERE "+FiltroSQL+" ORDER BY ForaDeLinha";
						break;
					case "UnidadeDeCompra":
						sql = "SELECT ID, UnidadeDeCompra FROM tProduto WHERE "+FiltroSQL+" ORDER BY UnidadeDeCompra";
						break;
					case "UnidadeDeUso":
						sql = "SELECT ID, UnidadeDeUso FROM tProduto WHERE "+FiltroSQL+" ORDER BY UnidadeDeUso";
						break;
					case "CoeficienteDeConversao":
						sql = "SELECT ID, CoeficienteDeConversao FROM tProduto WHERE "+FiltroSQL+" ORDER BY CoeficienteDeConversao";
						break;
					case "Obs":
						sql = "SELECT ID, Obs FROM tProduto WHERE "+FiltroSQL+" ORDER BY Obs";
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

	#region "ProdutoException"
	
	[Serializable]
	public class ProdutoException : Exception {

		public ProdutoException() : base (){}

		public ProdutoException(string msg) : base (msg){}

		public ProdutoException(SerializationInfo info, StreamingContext context) : base(info, context) {}

		public override void GetObjectData(SerializationInfo info, StreamingContext context){
			base.GetObjectData(info, context);
		}

	}

	#endregion
	
}