namespace LocadoraVeiculos.Models
{
    public class Reserva
    {
        public long Id { get; set; }
        public long ClienteId {  get; set; }
        public Cliente Cliente { get; set; }
        public long VeiculoId {  get; set; }
        public Veiculo Veiculo { get; set; }
        public string? DataInicio { get; set; }
        public string? DataTermino { get; set; }
        public decimal valor { get; set; }
        
    }
}
