using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// // Cria os modelos de hóspedes e cadastra na lista de hóspedes
// List<Pessoa> hospedes = new List<Pessoa>();

// Pessoa p1 = new Pessoa(nome: "Hóspede 1");
// Pessoa p2 = new Pessoa(nome: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// // Cria a suíte
// Suite suite = new Suite(tipoSuite: "Premium", capacidade: 1, valorDiaria: 30);

// // Cria uma nova reserva, passando a suíte e os hóspedes
// Reserva reserva = new Reserva(diasReservados: 5);
// reserva.CadastrarSuite(suite);
// reserva.CadastrarHospedes(hospedes);

// // Exibe a quantidade de hóspedes e o valor da diária
// Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
// Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

bool continuar = true;
List<Pessoa> clientes = new List<Pessoa>();
List<Suite> suites = new List<Suite>();

while (continuar)
{
    string senha = "wdwdwd";
    if (senha.Length>5)
    {
        
    }
    Console.Clear();
    Console.WriteLine("Digite uma opção: \n");
    Console.WriteLine("1- Cadastrar hospede");
    Console.WriteLine("2- Cadastrar suite");
    Console.WriteLine("3- Fazer reserva");
    Console.WriteLine("4- Listar hospedes");
    Console.WriteLine("5 Listar suites");
    Console.WriteLine("6- Listar Reservas");
    Console.WriteLine("7- Sair\n");
    
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
                Console.Clear();
                Console.WriteLine("Digite a data de nascimento no formato dd/MM/yyyy: ");
                string nascimento = Console.ReadLine();
                clientes.Add(new Pessoa(nome,sobrenome,nascimento,cpf));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("Digite o tipo da suite: ");
            string tipoSuite = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Digite a capacidade da suite: ");
            int capacidade = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Digite o valor da diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());
            suites.Add(new Suite(tipoSuite,capacidade,valorDiaria));
            break;
        case "3":
            break;
        case "4":
            foreach (var cliente in clientes)
            {
                Console.WriteLine(cliente.NomeCompleto);
                Console.WriteLine(cliente.Cpf);
                Console.WriteLine(cliente.Nascimento + "\n");
            }
            break;
        case"5":
            break;
        case "6":
            break;               
        case "7":
            continuar = false;
            break;
        default:
            Console.WriteLine("Digite uma opção válida!");
            break;
    }
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
}






