
namespace Academia.Domain.Entities
{
    public class AcademiaInputDTO
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public AcademiaInputDTO(string nome, string endereco, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
        }

    }
}