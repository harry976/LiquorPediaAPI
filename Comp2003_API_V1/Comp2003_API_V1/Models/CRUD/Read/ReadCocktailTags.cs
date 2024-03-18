using System.ComponentModel.DataAnnotations;

namespace Comp2003_API_V1.Models.CRUD.Read
{
    public class ReadCocktailTags
    {

        [MaxLength(15)]
        public string Tag { get; set;  }

    }
}
