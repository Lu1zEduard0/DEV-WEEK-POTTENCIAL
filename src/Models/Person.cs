namespace src.Models;
using System.Collections.Generic;
public class Person
{
    //nome, idade, cpf, ativa
    public Person()
    {
        this.Nome = "template";
        this.Idade = 0;
        this.contratos = new List<Contract>();
        this.Ativo = true;
        this.Id = 0;
    }

    public Person(string Nome, int Idade, string Cpf) {
        this.Nome = Nome;
        this.Idade = Idade;
        this.Cpf  = Cpf;
        this.contratos = new List<Contract>();
        this.Ativo = true;
        this.Id = 0;
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string? Cpf { get; set; }
    public bool Ativo { get; set; }
    public List<Contract> contratos { get; set;}



}