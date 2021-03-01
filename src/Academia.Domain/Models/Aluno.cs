namespace Academia.Domain.Models
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }

        public Aluno(string nome)
        {
            Nome = nome;
        }

    }
}