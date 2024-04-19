namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria,int numeroDoQuarto)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
            NumeroDoQuarto = numeroDoQuarto;
            Ocupado = false;
        }
  

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public int NumeroDoQuarto { get; set; }
        public bool Ocupado { get; set; } = false;
    }
}