//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proiect1
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class Automobil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Automobil()
        {
            this.Comandas = new HashSet<Comanda>();
            this.DetaliiComandas = new HashSet<DetaliiComanda>();
        }
        
        [DataMember]public int AutoId { get; set; }
        [DataMember]public int ClientId { get; set; }
        [DataMember]public string NumarAuto { get; set; }
        [DataMember]public int SasiuId { get; set; }
        [DataMember]public string SerieSasiu { get; set; }

        [DataMember]public virtual Sasiu Sasiu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]public virtual ICollection<Comanda> Comandas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]public virtual ICollection<DetaliiComanda> DetaliiComandas { get; set; }
    }
}