
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
    
public partial class NodoConexion
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public NodoConexion()
    {

        this.PuertoConexions = new HashSet<PuertoConexion>();

    }


    public string IPv4 { get; set; }

    public string IPv6 { get; set; }

    public string Usuario { get; set; }

    public string Contraseña { get; set; }

    public string NombreNodo { get; set; }

    public string FQDN { get; set; }

    public Nullable<int> IdTranscoder { get; set; }



    public virtual Transcoder Transcoder { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PuertoConexion> PuertoConexions { get; set; }

}

}
