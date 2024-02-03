using ApiRH.Dominio.Commands.Input.Candidatos;
using ApiRH.Dominio.Core.Data.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRH.Dominio.Entidades;

public class Candidato : EntidadeBase<int>
{
    public Candidato()
    {            
    }

    public Candidato(
        string? nome, 
        string? funcao)
    {
        Nome = nome;
        Funcao = funcao;
    }

    [Column("CandidatoId")]
    public override int Id { get; set; }
    public string? Nome { get; set; }
    public string? Funcao { get; set; }

	public void MontaAlteracao(CandidatoCommand command)
	{
		Nome = command.Nome;
        Funcao = command.Funcao;
	}
}
