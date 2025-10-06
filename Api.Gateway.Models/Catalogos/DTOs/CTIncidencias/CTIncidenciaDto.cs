namespace Api.Gateway.Models.Catalogos.DTOs.CTIncidencias
{
    public class CTIncidenciaDto
    {
        public int Id { get; set; }
        public string Abreviacion { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
    }
}
