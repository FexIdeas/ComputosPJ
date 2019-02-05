using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComputosPJ.Models
{
    public class UsuarioApi
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public string foto { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string x { get; set; }


    }

   
}