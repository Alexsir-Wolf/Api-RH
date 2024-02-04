using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Empresas;

public class EmpresaDetalheCommandResult
{
    public EmpresaDetalheCommandResult()
    {
    }

    public EmpresaDetalheCommandResult(
        int? id,
        string? nome,
        string? cnpj,
        bool ativo,
        List<TecnologiaCommandResult>? tecnologias)
    {
        Id = id;
        Nome = nome;
        CNPJ = cnpj;
        Status = ativo ? "Ativo" : "Inativo";
        Tecnologias = tecnologias;
    }

    public int? Id { get; private set; }
    public string? Nome { get; private set; }
    public string? CNPJ { get; private set; }
    public string? Status { get; private set; }
    public ICollection<TecnologiaCommandResult>? Tecnologias { get; set; }

    public EmpresaDetalheCommandResult MontarEmpresa(Empresa? empresa)
    {
        var tec = new TecnologiaCommandResult().AdicionarEmpresaTecnologias(
                   empresa.EmpresaTecnologias.ToList());

        return new EmpresaDetalheCommandResult(
            empresa.Id,
            empresa.Nome,
            empresa.CNPJ,
            empresa.Ativo,
            tec);
    }
}
