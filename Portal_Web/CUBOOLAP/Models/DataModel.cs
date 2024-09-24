namespace CUBOOLAP.Models
{
    public class DataModel
    {
        public int Id { get; set; }         // ID de los datos
        public string Nombre { get; set; }  // Nombre del modelo de datos
        public string Descripcion { get; set; } // Descripción del modelo de datos
        public DateTime FechaCreacion { get; set; } // Fecha de creación de los datos
    }
}
