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
    
    public partial class ContenedorCodecAudio
    {
        public int IdContenedorAudio { get; set; }
        public int IdContenedor { get; set; }
        public int IdCodecAudio { get; set; }
    
        public virtual CodecAudio CodecAudio { get; set; }
        public virtual Contenedor Contenedor { get; set; }
    }
}
