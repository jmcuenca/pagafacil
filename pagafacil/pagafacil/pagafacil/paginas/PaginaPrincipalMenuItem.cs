using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pagafacil.paginas
{

    public class PaginaPrincipalMenuItem
    {
        public PaginaPrincipalMenuItem()
        {
            TargetType = typeof(PaginaPrincipalDetail);
        }
        public PaginaPrincipalMenuItem(Type TargetType )

        {
            this.TargetType = TargetType;
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}