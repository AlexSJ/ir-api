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
    
    public partial class DestaqueLinkRegiao
    {
        public int ID { get; set; }
        public int RegiaoID { get; set; }
        public int TipoID { get; set; }
        public string Titulo { get; set; }
        public string Link { get; set; }
    
        public virtual Regiao Regiao { get; set; }
        public virtual Tipo Tipo { get; set; }
    }
}