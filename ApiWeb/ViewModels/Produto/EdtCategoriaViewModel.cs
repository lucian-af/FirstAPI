using Flunt.Notifications;
using Flunt.Validations;

namespace ApiWeb.ViewModels.Produto
{
    public class EdtCategoriaViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMaxLen(Titulo, 120, "Título", "O Título deve conter no máximo 120 caracteres!")
                .HasMinLen(Titulo, 3, "Título", "O Título deve conter no mínimo 3 caracteres!")
                );
        }
    }
}
