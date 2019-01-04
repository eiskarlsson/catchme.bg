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

        public CatchmebgUser User { get; set; }

        [Display(Name = "Pets:")]
        public int? SelectedPets { get; set; }

        [Display(Name = "Children:")]
        public int? SelectedChildren { get; set; }

        [Display(Name = "Drugs:")]
        public int? SelectedDrugs { get; set; }

        [Display(Name = "Diet:")]
        public int? SelectedDiet { get; set; }

        [Display(Name = "Drinks:")]
        public int? SelectedDrinks { get; set; }

        [Display(Name = "Smokes:")]
        public int? SelectedSmokes { get; set; }

        [Display(Name = "Religion:")]
        public int? SelectedReligion { get; set; }

        [Display(Name = "Ethnicity:")]
        public int? SelectedEthnicity { get; set; }

        [Display(Name = "Education:")]
        public int? SelectedEducation { get; set; }

        [Display(Name = "Hair Color:")]
        public int? SelectedHairColor { get; set; }

        [Display(Name = "Eye Color:")]
        public int? SelectedEyeColor { get; set; }

        [Display(Name = "Body Type:")]
        public int? SelectedBodyType { get; set; }

        [Display(Name = "Weight:")]
        public int? SelectedWeight { get; set; }

        [Display(Name = "Height:")]
        public int? SelectedHeight { get; set; }

        [Display(Name = "Languages:")]
        public int? SelectedLanguages { get; set; }

        [Display(Name = "Gender:")]
        public int? SelectedGender { get; set; }

        [Display(Name = "Age:")]
        public int? SelectedAge { get; set; }

        [Display(Name = "Looking For:")]
        public int? SelectedLookingFor { get; set; }

        [Display(Name = "Marital Status:")]
        public int? SelectedMaritalStatus { get; set; }

        public string EducationDescription { get; set; }
        public string JobDescription { get; set; }
        public string Details { get; set; }
        public string Job { get; set; }

        public DateTime DateLastChange { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
