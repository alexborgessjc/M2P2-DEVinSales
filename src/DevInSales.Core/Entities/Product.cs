using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevInSales.Core.Entities
{
    public class Product : Entity
    {


        public Product(string name, decimal suggestedPrice)
        {
            Name = name;
            SuggestedPrice = suggestedPrice;
        }

        public Product(int id, string name, decimal suggestedPrice)
        {
            Id = id;
            Name = name;
            SuggestedPrice = suggestedPrice;
        }

        public void AtualizarDados(string name, decimal suggestedPrice)
        {
            Name = name;
            SuggestedPrice = suggestedPrice;
        }

        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        public string Name { get; private set; }


        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        [Range(1, (double)decimal.MaxValue)]
        public decimal SuggestedPrice { get; private set; }
    }
}