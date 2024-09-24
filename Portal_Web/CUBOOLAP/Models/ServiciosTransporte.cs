using System;
using System.ComponentModel.DataAnnotations;

namespace CUBOOLAP.Models
{
    public class ServiciosTransporte
    {
        [Key]
        public int ID_Servicio { get; set; }  // Llave primaria

        public int ID_Cliente { get; set; }  // Llaves foráneas
        public int ID_Vehiculo { get; set; }
        public int ID_Conductor { get; set; }
        public int ID_Ruta { get; set; }

        public DateTime Fecha_Salida { get; set; }
        public DateTime Fecha_Llegada { get; set; }

        public string Estado { get; set; }

        public decimal Costo { get; set; }
        public decimal Peso_Carga { get; set; }

        public string Descripcion_Carga { get; set; }
    }
}
