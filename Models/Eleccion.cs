//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComputosPJ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Eleccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Eleccion()
        {
            this.EnlaceEleccionEscuela = new HashSet<EnlaceEleccionEscuela>();
            this.EnlaceEleccionTipoCategoria = new HashSet<EnlaceEleccionTipoCategoria>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioID { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnlaceEleccionEscuela> EnlaceEleccionEscuela { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnlaceEleccionTipoCategoria> EnlaceEleccionTipoCategoria { get; set; }
    }
}
