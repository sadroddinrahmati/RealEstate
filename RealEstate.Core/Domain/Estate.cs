 
using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RealEstate.Core.Enum.EnumTypes;

namespace RealEstate.Core.Domain
{
    public class Estate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Display(Name = "عنوان ملک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Name { get; set; }

        [Display(Name = "صاحب ملک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int OwnerId { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Address { get; set; }

        [Display(Name = "متراژ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")] 
        public int Area { get; set; }

        [Display(Name = "نوع ملک")]
        public EstateType EstateType { get; set; }

        public bool IsDelete { get; set; } 
        public DateTime? CreatedTime { get; set; } 
        public DateTime? LastModified { get; set; } 
        public int UserId { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }
         
    }
}
