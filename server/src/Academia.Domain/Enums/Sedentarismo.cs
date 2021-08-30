using System.ComponentModel;

namespace Academia.Domain.Entities.Enums
{
    public enum Sedentarismo
    {
        [Description("Não informado")]
        NaoInformado,
        [Description("você faz eventuais caminhadas em seu cotidiano, mas fica por isso mesmo. Nenhuma atividade realmente intensa é realizada")]
        Nivel1,
        [Description("você vai ao mercado, carrega algumas sacolas e nada mais. Dificilmente pensa em separar um tempo exclusivamente para mexer seu corpo")]
        Nivel2,
        [Description("se é possível evitar um esforço físico, você o faz. Prefere fazer tudo de carro e detesta carregar peso")]
        Nivel3,
        [Description("Você mal consegue se lembrar da última vez que fez um exercício e passa o dia todo sentado ou deitado")]
        Nivel4,

    }
}