using Flunt.Notifications;
using Flunt.Validations;

namespace ApiWeb.ViewModels.Produto
{
    public class EdtProdutoViewModel : Notifiable, IValidatable
    {
        #region Propriedades
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string CaminhoImagem { get; set; }
        public int CategoriaId { get; set; }
        #endregion

        #region Metodos
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMaxLen(Titulo, 120, "Título", "O Título deve conter no máximo 120 caracteres!")
                .HasMinLen(Titulo, 3, "Título", "O Título deve conter no mínimo 3 caracteres!")
                .IsGreaterThan(Preco, 0, "Preço", "O Preço deve ser maior que zero!")
                );
        } 
        #endregion
    }
}
