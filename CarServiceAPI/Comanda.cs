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
    public partial class Comanda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comanda()
        {
            this.DetaliiComandas = new HashSet<DetaliiComanda>();
        }

        [DataMember] public int ComandaId { get; set; }
        [DataMember] public int AutoId { get; set; }
        [DataMember] public int ClientId { get; set; }
        [DataMember] public string StareComanda { get; set; }
        [DataMember] public System.DateTime DataSystem { get; set; }
        [DataMember] public Nullable<System.DateTime> DataProgramare { get; set; }
        [DataMember] public Nullable<System.DateTime> DataFinalizare { get; set; }
        [DataMember] public int KmBord { get; set; }
        [DataMember] public string Descriere { get; set; }
        [DataMember] public decimal ValoarePiese { get; set; }

        [DataMember] public virtual Automobil Automobil { get; set; }
        [DataMember] public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember] public virtual ICollection<DetaliiComanda> DetaliiComandas { get; set; }
    }
}