using ApiRH.Dominio.Commands.Input.Tecnologias;
using ApiRH.Dominio.Core.Data.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

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
    [Column("TecnologiaId")]
    public override int Id { get; set; }
    public string? Nome { get; set; }
    public string? Peso { get; set; }

    public ICollection<EmpresaTecnologia> EmpresaTecnologias { get; set; }
    public ICollection<CandidatoTecnologia> CandidatoTecnologias { get; set; }
    public ICollection<VagaTecnologia> VagaTecnologias { get; set; }


    public void MontaAlteracao(TecnologiaCommand command)
	{
		Nome = command.Nome;
        Peso = command.Peso;
	}
}
