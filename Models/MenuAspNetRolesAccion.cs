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
    
    public partial class MenuAspNetRolesAccion
    {
        public int ID { get; set; }
        public int AccionId { get; set; }
        public int MenuAspNetRolesId { get; set; }
    
        public virtual Accion Accion { get; set; }
        public virtual MenuAspNetRoles MenuAspNetRoles { get; set; }
    }
}
