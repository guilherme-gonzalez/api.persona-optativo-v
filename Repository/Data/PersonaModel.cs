using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class PersonaModel
    {
        public int Id { get; set; } // This property corresponds to the 'id' field in your database table
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
    }
}
