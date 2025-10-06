namespace Api.Gateway.Models.Seguros.Queries.Reportes
{
    public class RJubiladoDto
    {
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public int Titular { get; set; }
        public int Conyuge { get; set; }
        public int Hijo { get; set; }
        public int Total { get; set; }
    }
}
