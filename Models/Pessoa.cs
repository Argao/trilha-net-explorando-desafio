using System.Globalization;
using System.Text.RegularExpressions;

namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa()
    {
        
    }

    public Pessoa(string nome, string sobrenome, DateTime nascimento, string cpf)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Nascimento = nascimento;
        Cpf = cpf;
    }
    
    public Pessoa(string nome, string sobrenome, string nascimento, string cpf)
    {
        //Verifica se a string recebida esta no formato certo
        if (DateTime.TryParseExact(nascimento,"dd/MM/yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None,out DateTime data))
        {
            Nascimento = data;
        }
        else
        {
            throw new FormatException("Data no formato errado!");
        }
        Nome = nome;
        Sobrenome = sobrenome;
        Cpf = cpf;
    }
    
    

    
    private string cpf;

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime Nascimento { get; set; }
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
    public string Cpf
    {
        get => cpf;
        set
        {   //Verifica de o cpf está em um formato válido
            if (ValidaCpf(value))
            {
                cpf = value;
            }
        } 
    }


    public int RetornaIdade()
    {
        return DateTime.Now.Year - Nascimento.Year;
    }

    public static bool ValidaCpf(String cpf){
            if (Regex.IsMatch(cpf,"[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}"))
            {
                return true;
            }
            else
            {
                throw new FormatException ("Formato invalido de cpf!\nCertifique-se que o cpf está no formato xxx.xxx.xxx-xx");
            }
    }
}