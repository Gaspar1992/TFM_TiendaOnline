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
    
    public partial class productos_categorias
    {
        public int id { get; set; }
        public int producto { get; set; }
        public int categoria { get; set; }
    
        public virtual categorias categorias { get; set; }
        public virtual productos productos { get; set; }
    }
}