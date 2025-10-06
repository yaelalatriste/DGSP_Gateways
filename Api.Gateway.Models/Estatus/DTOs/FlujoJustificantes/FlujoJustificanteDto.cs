namespace Api.Gateway.Models.Estatus.DTOs.FlujoJustificantes
{
    public class FlujoJustificanteDto
    {
        public int ModuloId { get; set; }
        public int SubmoduloId { get; set; }
        public int EstatusId { get; set; }
        public int ESucesivoId { get; set; }
        public bool Editable { get; set; }
        public bool Eliminar { get; set; }
        public string Boton { get; set; }
    }
}
