using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace adopteUnDev.Models.DeveloperViewModel
{
    public class DeveloperCreateFrom
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Nom de Famille")]
        public string DevName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Prénom")]
        public string DevFirstName { get; set; }

        [Required]
        [DisplayName("Date de Naissance")]
        public DateTime DevBirthDate { get; set; }

        [MaxLength(50)]
        [DisplayName("Photo")]
        public string DevPicture { get; set; }

        [Required]
        [DisplayName("Cout/heure")]
        public double DevHourCost { get; set; }

        [Required]
        [DisplayName("Cout/jour")]
        public double DevDayCost { get; set; }

        [Required]
        [DisplayName("Cout/mois")]
        public double DevMonthCost { get; set; }

        [Required]
        [MaxLength(250)]
        [DisplayName("Email")]
        public string DevMail { get; set; }

        [MaxLength(250)]
        [MinLength(1)]
        [DisplayName("Categorie Principal")]
        public string DevCategPrincipal { get; set; }
    }
}
