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
    
    public partial class EnlaceEleccionTipoCategoriaLista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EnlaceEleccionTipoCategoriaLista()
        {
            this.RecuentoVoto = new HashSet<RecuentoVoto>();
        }
    
        public int ID { get; set; }
        public int ListaID { get; set; }
        public int EnlaceEleccionTipoCategoriaID { get; set; }
    
        public virtual EnlaceEleccionTipoCategoria EnlaceEleccionTipoCategoria { get; set; }
        public virtual Lista Lista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecuentoVoto> RecuentoVoto { get; set; }
    }
}
