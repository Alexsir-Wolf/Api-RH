using ApiRH.Dominio.Commands.Input.Empresas;
using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Empresas;

public class EmpresaCommandResult
{
    public EmpresaCommandResult()
    {
    }

    public EmpresaCommandResult(
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

    public EmpresaCommandResult MontarEmpresa(Empresa? empresa)
    {
        var tec = new TecnologiaCommandResult().AdicionarEmpresaTecnologias(
                    empresa.EmpresaTecnologias.ToList());

        return new EmpresaCommandResult(
            empresa.Id,
            empresa.Nome,
            empresa.CNPJ,
            empresa.Ativo,
            tec);
    }

    public List<EmpresaCommandResult> MontarLista(ICollection<Empresa>? empresas)
    {
        var result = new List<EmpresaCommandResult>();

        if (empresas != null)
        {
            foreach (var empresa in empresas)
            {
                var tec = new TecnologiaCommandResult().AdicionarEmpresaTecnologias(
                    empresa.EmpresaTecnologias.ToList());

                result.Add(new EmpresaCommandResult(
                    empresa.Id,
                    empresa.Nome,
                    empresa.CNPJ,
                    empresa.Ativo,
                    tec));
            }
        }
        return result;
    }
}
