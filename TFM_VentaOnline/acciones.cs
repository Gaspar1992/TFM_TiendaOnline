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
    
    public partial class acciones
    {
        public int id { get; set; }
        public string tipoAccion { get; set; }
        public Nullable<int> usuario { get; set; }
        public Nullable<int> producto { get; set; }
        public Nullable<int> vendedor { get; set; }
        public string informacion { get; set; }
    
        public virtual productos productos { get; set; }
        public virtual tiposAccion tiposAccion { get; set; }
        public virtual usuarios usuarios { get; set; }
        public virtual vendedores vendedores { get; set; }
    }
}
