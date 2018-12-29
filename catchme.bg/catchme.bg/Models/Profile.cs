using catchme.bg.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public class Profile
    {
        public int ID { set; get; }

        public CatchmebgUser User { get; set; }

        public int SelectedPets { get; set; }
        public int SelectedChildren { get; set; }
        public int SelectedDrugs { get; set; }
        public int SelectedDiet { get; set; }
        public int SelectedDrinks { get; set; }
        public int SelectedSmokes { get; set; }
        public int SelectedReligion { get; set; }
        public int SelectedEthnicity { get; set; }
        public int SelectedEducation { get; set; }
        public int SelectedHairColor { get; set; }
        public int SelectedEyeColor { get; set; }
        public int SelectedBodyType { get; set; }
        public int SelectedWeight { get; set; }
        public int SelectedHeight { get; set; }
        public int SelectedLanguages { get; set; }
        public int SelectedGender { get; set; }
        public int SelectedAge { get; set; }
        public int SelectedLookingFor { get; set; }
        public int SelectedMaritalStatus { get; set; }

        public string EducationDescription { get; set; }
        public string JobDescription { get; set; }
        public string Details { get; set; }
        public string Job { get; set; }

        public DateTime DateLastChange { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
