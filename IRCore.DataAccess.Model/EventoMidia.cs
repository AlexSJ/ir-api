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
    
    public partial class EventoMidia
    {
        public int ID { get; set; }
        public int EventoTipoMidiaID { get; set; }
        public bool Publicado { get; set; }
        public int EventoID { get; set; }
        public string Valor { get; set; }
    
        public virtual EventoTipoMidia EventoTipoMidia { get; set; }
        public virtual tEvento tEvento { get; set; }
    }
}
