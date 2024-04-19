namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public Pessoa Responsavel { get; set; }
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public DateTime HorarioDaReserva { get; set; }
        

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }


        public Reserva(Pessoa responsavel, List<Pessoa> hospedes, Suite suite, int diasReservados)
        {
            Responsavel = responsavel;
            CadastrarSuite(suite);
            CadastrarHospedes(hospedes);
            DiasReservados = diasReservados;
            HorarioDaReserva = DateTime.Now;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new Exception("Quantidade de hospedes maior que a capacidade da suite!");
            }
        }

        public bool CadastrarHospede(Pessoa p)
        {
            if(Hospedes.Exists(x => x.Cpf == p.Cpf))
            {
                return false;
            }
            return true;
        }




        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                valor *= 0.9m;
            }

            return valor;
        }
    }
}