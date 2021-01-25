using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Models
{
    public class Restaurant : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public Owner Owner { get; set; }
        
        [Required]
        [MaxLength(255)]
        [Display(Name = "Name of the Owner")]
        public string Name { get; set; }
       
        [DisplayFormat(NullDisplayText = "0")]
        [Display(Name="Type of food")]
        public CuisineType Cuisine { get; set; }

        [@CustomValidation(ErrorMessage = "Create date must be less than or equal to today's date!")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool containsSearchResult = Name.Contains("Italian");
            if (Cuisine == CuisineType.Italian)
                containsSearchResult = false;
            if(containsSearchResult == false)
            {
                containsSearchResult = Name.Contains("Indian");
                if(Cuisine == CuisineType.Indian)
                    containsSearchResult = false;
                if(containsSearchResult == false)
                {
                    containsSearchResult = Name.Contains("French");
                }
                    if(Cuisine == CuisineType.French)
                        containsSearchResult = false;
            }
            if(containsSearchResult)
            {
                yield return new ValidationResult("This restaurant has different type in its name!", new List<string> { "CuisineType"});
            }
        }
    }
}
