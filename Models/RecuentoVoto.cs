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
    
    public partial class RecuentoVoto
    {
        public int ID { get; set; }
        public int CantidadVotos { get; set; }
        public int EnlaceEleccionTipoCategoriaListaID { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public string UsuarioCreacionID { get; set; }
        public string UsuarioActualizacionID { get; set; }
        public int MesaID { get; set; }
    
        public virtual EnlaceEleccionTipoCategoriaLista EnlaceEleccionTipoCategoriaLista { get; set; }
        public virtual Mesa Mesa { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
    }
}
