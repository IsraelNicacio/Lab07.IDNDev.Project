using IDN.Core.DomainObject;

namespace IDNDev.Cadastro.Api.Domain;

public class Pessoa : EntityBase
{
    public string Nome { get; private set; }
    public string Documento { get; private set; }
    public int Idade { get; private set; }

    //Usado pelo EFCore
    public Pessoa()
    { }

    public Pessoa(string nome, string documento, int idade)
    {
        Nome = nome;
        Documento = documento;
        Idade = idade;

        Validate();
    }

    private void Validate()
    {
        var assert = new ValidationEntity()
            .NotNullOrEmpty(Nome, "O campo Nome deve ser informado")
            .HasMaxLen(Nome, 3, "O campo Nome deve ter o tamanho minimo de 3 caracteres")
            .HasMaxLen(Nome, 60, "O campo Nome deve ter o tamanho maximo de 60 caracteres")
            .NotNullOrEmpty(Documento, "O campo Documento deve ser informado")
            .HasMaxLen(Nome, 60, "O campo Nome deve ter o tamanho maximo de 14 caracteres")
            .IsBetween(Idade, 0, 120, "O campo Idade de ter entre 0 e 120 anos");

        assert.ThrowIfInvalid();
    }
}
