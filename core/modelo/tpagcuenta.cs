//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class tpagcuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tpagcuenta()
        {
            this.tpagmovimiento = new HashSet<tpagmovimiento>();
            this.tpagmovimiento1 = new HashSet<tpagmovimiento>();
        }
    
        public long cuenta { get; set; }
        public Nullable<long> cusuario { get; set; }
        public Nullable<decimal> saldo { get; set; }
        public Nullable<System.DateTime> fultimomov { get; set; }
        public string moneda { get; set; }
        public Nullable<bool> estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tpagmovimiento> tpagmovimiento { get; set; }
        public virtual tsegusuario tsegusuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tpagmovimiento> tpagmovimiento1 { get; set; }
    }
}
