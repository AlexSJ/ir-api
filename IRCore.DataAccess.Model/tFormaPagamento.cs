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
    
    public partial class tFormaPagamento
    {
        public tFormaPagamento()
        {
            this.tVendaBilheteriaFormaPagamento = new HashSet<tVendaBilheteriaFormaPagamento>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public Nullable<int> Tipo { get; set; }
        public Nullable<decimal> Parcelas { get; set; }
        public Nullable<int> BandeiraID { get; set; }
        public Nullable<decimal> TaxaAdministrativa { get; set; }
        public Nullable<byte> DiasRepasse { get; set; }
        public string Padrao { get; set; }
        public Nullable<int> FormaPagamentoTipoID { get; set; }
        public string Ativo { get; set; }
        public string RedePreferencial { get; set; }
    
        public virtual ICollection<tVendaBilheteriaFormaPagamento> tVendaBilheteriaFormaPagamento { get; set; }
    }
}
