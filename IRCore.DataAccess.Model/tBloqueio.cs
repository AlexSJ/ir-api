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
    
    public partial class tBloqueio
    {
        public tBloqueio()
        {
            this.tLugar = new HashSet<tLugar>();
            this.tLugar1 = new HashSet<tLugar>();
        }
    
        public int ID { get; set; }
        public Nullable<int> LocalID { get; set; }
        public Nullable<int> CorID { get; set; }
        public string Nome { get; set; }
        public string Obs { get; set; }
    
        public virtual tLocal tLocal { get; set; }
        public virtual ICollection<tLugar> tLugar { get; set; }
        public virtual ICollection<tLugar> tLugar1 { get; set; }
        public string Ativo { get; set; }
        public Nullable<int> ParceiroMediaID { get; set; }
    }
}