//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiddlewareWeb.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PuertoConexion
    {
        public int Id { get; set; }
        public string NodoConexion { get; set; }
        public string Tipo { get; set; }
        public int Numero { get; set; }
    
        public virtual NodoConexion NodoConexion1 { get; set; }
    }
}
