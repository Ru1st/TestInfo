using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestInfoTecs.Models
{
    public class User
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо задать имя!")]
        [StringLength(100, ErrorMessage = "Длина имени не должна превышать 100 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо задать фамилию!")]
        [StringLength(100, ErrorMessage = "Длина фамилии не должна превышать 100 символов")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Выберите город!")]
        public int CitiesId { get; set; }

        [ForeignKey("CitiesId")]
        public virtual City City { get; set; }
    }
}