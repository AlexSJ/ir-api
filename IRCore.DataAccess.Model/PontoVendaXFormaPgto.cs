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
    
    public partial class PontoVendaXFormaPgto
    {
        public int ID { get; set; }
        public int IR_PontoVendaXFormaPgtoID { get; set; }
        public Nullable<int> PontoVendaFormaPgtoID { get; set; }
        public Nullable<int> PontoVendaID { get; set; }
    
        public virtual PontoVenda PontoVenda { get; set; }
        public virtual PontoVendaFormaPgto PontoVendaFormaPgto { get; set; }
    }
}
