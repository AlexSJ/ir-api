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
    
    public partial class EventoTipoMidia
    {
        public EventoTipoMidia()
        {
            this.EventoMidia = new HashSet<EventoMidia>();
        }
    
        public int ID { get; set; }
        public string Chave { get; set; }
        public string Nome { get; set; }
        public string Instrucao { get; set; }
        public int Tipo { get; set; }
    
        public virtual ICollection<EventoMidia> EventoMidia { get; set; }
    }
}
