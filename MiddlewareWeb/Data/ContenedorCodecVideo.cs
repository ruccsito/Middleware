
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
    
public partial class ContenedorCodecVideo
{

    public int IdContenedorCodecVideo { get; set; }

    public Nullable<int> IdContenedor { get; set; }

    public Nullable<int> IdCodecVideo { get; set; }



    public virtual CodecVideo CodecVideo { get; set; }

    public virtual Contenedor Contenedor { get; set; }

}

}
