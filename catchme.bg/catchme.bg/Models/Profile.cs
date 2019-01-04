using catchme.bg.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public class Profile
    {
        public int ID { set; get; }

        public CatchmebgUser ProfileUser { get; set; }

        [Display(Name = "Pets:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedPets { get; set; }

        [Display(Name = "Children:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedChildren { get; set; }

        [Display(Name = "Drugs:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedDrugs { get; set; }

        [Display(Name = "Diet:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedDiet { get; set; }

        [Display(Name = "Drinks:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedDrinks { get; set; }

        [Display(Name = "Smokes:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedSmokes { get; set; }

        [Display(Name = "Religion:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedReligion { get; set; }

        [Display(Name = "Ethnicity:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedEthnicity { get; set; }

        [Display(Name = "Education:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedEducation { get; set; }

        [Display(Name = "Hair Color:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedHairColor { get; set; }

        [Display(Name = "Eye Color:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedEyeColor { get; set; }

        [Display(Name = "Body Type:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedBodyType { get; set; }

        [Display(Name = "Weight:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedWeight { get; set; }

        [Display(Name = "Height:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedHeight { get; set; }

        [Display(Name = "Languages:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedLanguages { get; set; }

        [Display(Name = "Gender:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedGender { get; set; }

        [Display(Name = "Age:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedAge { get; set; }

        [Display(Name = "Looking For:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedLookingFor { get; set; }

        [Display(Name = "Marital Status:")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? SelectedMaritalStatus { get; set; }

        public string EducationDescription { get; set; }
        public string JobDescription { get; set; }
        public string Details { get; set; }
        public string Job { get; set; }

        public DateTime DateLastChange { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
