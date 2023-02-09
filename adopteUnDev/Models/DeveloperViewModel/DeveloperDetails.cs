using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace adopteUnDev.Models.DeveloperViewModel
{
    public class DeveloperDetails
    {
        [DisplayName("Identifiant :")]
        [ScaffoldColumn(false)]
        public int idDev { get; set; }

        [DisplayName("Nom :")]
        public string DevName { get; set; }

        [DisplayName("Prenom :")]
        public string DevFirstName { get; set; }

        [DisplayName("Date de Naissance :")]
        public DateTime DevBirthDate { get; set; }

        [DisplayName("Picture :")]
        public string DevPicture { get; set; }

        [DisplayName("Cout/heure :")]
        public double DevHourCost { get; set; }

        [DisplayName("Cout/jour : ")]
        public double DevDayCost { get; set; }

        [DisplayName("Cout/mois :")]
        public double DevMonthCost { get; set; }

        [DisplayName("Email :")]
        public string DevMail { get; set; }

        [DisplayName("Categorie Principale :")]
        public string DevCategPrincipal { get; set; }
    }
}
