//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IRCore.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tCliente
    {
        public tCliente()
        {
            this.tVendaBilheteria = new HashSet<tVendaBilheteria>();
            this.Voucher = new HashSet<Voucher>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CarteiraEstudante { get; set; }
        public string Sexo { get; set; }
        public string DDDTelefone { get; set; }
        public string Telefone { get; set; }
        public string DDDTelefoneComercial { get; set; }
        public string TelefoneComercial { get; set; }
        public string DDDCelular { get; set; }
        public string Celular { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string RecebeEmail { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Nullable<int> ClienteIndicacaoID { get; set; }
        public string Obs { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Senha { get; set; }
        public string Ativo { get; set; }
        public string StatusAtual { get; set; }
        public string LoginOSESP { get; set; }
        public string CEPEntrega { get; set; }
        public string EnderecoEntrega { get; set; }
        public string NumeroEntrega { get; set; }
        public string CidadeEntrega { get; set; }
        public string EstadoEntrega { get; set; }
        public string ComplementoEntrega { get; set; }
        public string BairroEntrega { get; set; }
        public string CEPCliente { get; set; }
        public string EnderecoCliente { get; set; }
        public string NumeroCliente { get; set; }
        public string CidadeCliente { get; set; }
        public string EstadoCliente { get; set; }
        public string ComplementoCliente { get; set; }
        public string BairroCliente { get; set; }
        public string NomeEntrega { get; set; }
        public string CPFEntrega { get; set; }
        public string RGEntrega { get; set; }
        public string CPFConsultado { get; set; }
        public string NomeConsultado { get; set; }
        public Nullable<int> StatusConsulta { get; set; }
        public string CPFConsultadoEntrega { get; set; }
        public string NomeConsultadoEntrega { get; set; }
        public Nullable<int> StatusConsultaEntrega { get; set; }
        public string Pais { get; set; }
        public string CPFResponsavel { get; set; }
        public Nullable<bool> Updated { get; set; }
        public Nullable<int> ContatoTipoID { get; set; }
        public Nullable<int> NivelCliente { get; set; }
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public string TipoCadastro { get; set; }
        public string Profissao { get; set; }
        public Nullable<int> SituacaoProfissionalID { get; set; }
        public string DDDTelefoneComercial2 { get; set; }
        public string TelefoneComercial2 { get; set; }
        public string DataCadastro { get; set; }
        public int SiteID { get; set; }
        public Nullable<bool> PossuiEndereco { get; set; }
        public virtual ICollection<tVendaBilheteria> tVendaBilheteria { get; set; }
        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
