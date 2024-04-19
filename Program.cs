using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

bool continuar = true;
List<Pessoa> clientes = new List<Pessoa>();
List<Suite> suites = new List<Suite>();
List<Reserva> reservas = new List<Reserva>();

clientes.Add(new Pessoa("João", "Silva", "01/01/1990", "123.456.789-00"));
clientes.Add(new Pessoa("Maria", "Silva", "01/01/1990", "123.456.789-01"));
clientes.Add(new Pessoa("José", "Silva", "01/02/2000", "123.456.789-02"));
clientes.Add(new Pessoa("Ana", "Silva", "01/03/2000", "123.456.789-03"));
clientes.Add(new Pessoa("Pedro", "Silva", "01/04/2000", "123.456.789-04"));
clientes.Add(new Pessoa("Paulo", "Silva", "01/05/2000", "123.456.789-05"));
clientes.Add(new Pessoa("Lucas", "Silva", "01/06/2000", "123.456.789-06"));

suites.Add(new Suite("Premium", 3, 100, 103));
suites.Add(new Suite("Luxo", 2, 200, 237));
suites.Add(new Suite("Master", 5, 300, 301));
suites.Add(new Suite("Especial", 1, 400, 401));

while (continuar)
{
    Console.Clear();
    Console.WriteLine("Digite uma opção: \n");
    Console.WriteLine("1- Cadastrar hospede");
    Console.WriteLine("2- Cadastrar suite");
    Console.WriteLine("3- Fazer reserva");
    Console.WriteLine("4- Verificar reservas");
    Console.WriteLine("5- Sair\n");

    switch (Console.ReadLine())
    {
        case "1":
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o nome: ");
                string nome = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Digite o sobrenome: ");
                string sobrenome = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Digite o cpf: ");
                string cpf = Console.ReadLine();
                Pessoa.ValidaCpf(cpf);
                if (clientes.Exists(x => x.Cpf == cpf))
                {
                    throw new Exception("CPF já cadastrado!");
                }
                Console.Clear();
                Console.WriteLine("Digite a data de nascimento no formato dd/MM/yyyy: ");
                string nascimento = Console.ReadLine();
                clientes.Add(new Pessoa(nome, sobrenome, nascimento, cpf));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("Digite o nº do quarto da suite: ");
            int numeroQuarto = int.Parse(Console.ReadLine());
            if (!suites.Exists(x => x.NumeroDoQuarto == numeroQuarto))
            {
                Console.WriteLine("Quarto já cadastrado!");
                break;
            }else
            {
                Console.Clear();
                Console.WriteLine("Digite o tipo da suite: ");
                string tipoSuite = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Digite a capacidade da suite: ");
                int capacidade = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Digite o valor da diária: ");
                decimal valorDiaria = decimal.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Digite o nº do quarto!");
                int quarto = int.Parse(Console.ReadLine());
                suites.Add(new Suite(tipoSuite, capacidade, valorDiaria, quarto));
               
            } 
            break;

        case "3":
            List<Pessoa> hospedes = new List<Pessoa>();
            Pessoa responsavel = new Pessoa();

            Console.Clear();
            Console.WriteLine("Digite o cpf do responsável: ");
            string cpfResponsavel = Console.ReadLine();
            if (!clientes.Exists(x => x.Cpf == cpfResponsavel))
            {
                Console.WriteLine("CPF não cadastrado!");
                break;
            }
            else if (!responsavel.MaiorDeIdade())
            {
                Console.WriteLine("O responsável deve ter mais de 18 anos!");
                break;
            }
            else
            {
                responsavel = clientes.Find(x => x.Cpf == cpfResponsavel);
                hospedes.Add(responsavel);

                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i < clientes.Count; i++)
                    {
                        if(hospedes.Exists(x => x.Cpf == clientes[i].Cpf))
                        {   
                            continue;
                        }

                        Console.WriteLine($"{i + 1} - {clientes[i].NomeCompleto}");
                        
                        
                    }
                    Console.WriteLine("Digite o número do hospede que deseja adicionar a reserva: ");

                    int index = int.Parse(Console.ReadLine()) - 1;
                    Pessoa hospede = clientes[index];

                    if (hospedes.Exists(x => x.Cpf == hospede.Cpf))
                    {
                        Console.WriteLine("Hospede já cadastrado!");
                        Console.WriteLine("Deseja adicionar outro hospede? (s/n)");

                        if (Console.ReadLine().ToLower() == "n")
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    hospedes.Add(hospede);
                    Console.WriteLine("Deseja adicionar outro hospede? (s/n)");
                    if (Console.ReadLine().ToLower() == "n")
                    {
                        break;
                    }
                }

                Console.Clear();
                foreach (var suite in suites)
                {
                    if (!suite.Ocupado && suite.Capacidade >= hospedes.Count)
                    {
                        Console.WriteLine($"Quarto: {suite.NumeroDoQuarto}- {suite.TipoSuite}   Valor da diária: R$ {String.Format("{0:C2}", suite.ValorDiaria)}");
                    }
                }

                Console.WriteLine("Digite o número do quarto que deseja reservar: ");
                int nQuarto = int.Parse(Console.ReadLine());

                if (!suites.Exists(x => x.NumeroDoQuarto == nQuarto))
                {
                    Console.WriteLine("Quarto não cadastrado!");
                    break;
                }

                Suite suiteCad = suites.Find(x => x.NumeroDoQuarto == nQuarto);

                Console.Clear();
                Console.WriteLine("Digite a quantidade de dias que deseja reservar: ");
                int dias = int.Parse(Console.ReadLine());
                Console.Clear();
                try
                {
                    Reserva reserva = new Reserva(responsavel, hospedes, suiteCad, dias);
                    reservas.Add(reserva);
                    Console.WriteLine("Reserva feita com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            break;
        case "4":
            Console.Clear();
            foreach (var reserva in reservas)
            {
                Console.WriteLine("Responsável: " + reserva.Responsavel.NomeCompleto);
                Console.WriteLine("Hóspedes: ");
                foreach (var hospede in reserva.Hospedes)
                {
                    Console.WriteLine(hospede.NomeCompleto);
                }
                Console.WriteLine("Suite: " + reserva.Suite.TipoSuite);
                Console.WriteLine("Diárias: " + reserva.DiasReservados);
                Console.WriteLine("Valor total: " + reserva.CalcularValorDiaria());
                Console.WriteLine("Data da reserva: " + reserva.HorarioDaReserva);
                Console.WriteLine("-------------------------------------------------");
            }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            break;
        case "5":
            continuar = false;
            break;
        default:
            Console.WriteLine("Digite uma opção válida!");
            break;
    }
    Console.Clear();
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
}