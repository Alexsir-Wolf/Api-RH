using ApiRH.Dominio.Commands.Input.Tecnologias;
using ApiRH.Dominio.Core.Data;

namespace ApiRH.Dominio.Entidades;

public class Tecnologia : EntidadeBase<int>
{
    public Tecnologia()
    {            
    }
    public Tecnologia(
        string? nome, 
        string? peso)
    {
        Nome = nome;
        Peso = peso;
    }

    public override int Id { get; set; }
    public string? Nome { get; set; }
    public string? Peso { get; set; }

    public void MontaTecnologia(Tecnologia command) 
    {
        Nome = command.Nome;
        Peso = command.Peso;
    }
}
