//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFM_VentaOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class telefonos
    {
        public int id { get; set; }
        public int usuario { get; set; }
        public int pais { get; set; }
        public string telefono { get; set; }
    
        public virtual paises paises { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
