using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;

namespace catchme.bg.Models
{
    public class ProfileViewModel
    {
        public int ID { set; get; }

        public CatchmebgUser User { get; set; }

        public Profile Profile { get; set; }

        public IEnumerable<Pets> Pets { get; set; }
        public IEnumerable<Children> Children { get; set; }
        public IEnumerable<Drugs> Drugs { get; set; }
        public IEnumerable<Diet> Diet { get; set; }
        public IEnumerable<Drinks> Drinks { get; set; }
        public IEnumerable<Smokes> Smokes { get; set; }
        public IEnumerable<Religion> Religion { get; set; }
        public IEnumerable<Ethnicity> Ethnicity { get; set; }
        public IEnumerable<Education> Education { get; set; }
        public IEnumerable<HairColor> HairColor { get; set; }
        public IEnumerable<EyeColor> EyeColor { get; set; }
        public IEnumerable<BodyType> BodyType { get; set; }
        public IEnumerable<Weight> Weight { get; set; }
        public IEnumerable<Height> Height { get; set; }
        public IEnumerable<Languages> Languages { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
        public IEnumerable<Age> Age { get; set; }
        public IEnumerable<LookingFor> LookingFor { get; set; }
        public IEnumerable<MaritalStatus> MaritalStatus { get; set; }

        
    }
}
