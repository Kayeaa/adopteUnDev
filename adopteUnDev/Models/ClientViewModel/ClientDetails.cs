using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace adopteUnDev.Models.ClientViewModel
{
    public class ClientDetails
    {
        [DisplayName("Identifiant :")]
        public int idClient { get; set; }

        [DisplayName("Nom :")]
        public string CliName { get; set; }

        [DisplayName("Prenom :")]
        public string CliFirstName { get; set; }

        [DisplayName("Email :")]
        public string CliMail { get; set; }

        [DisplayName("Entreprise :")]
        public string CliCompany { get; set; }

        [DisplayName("Login :")]
        public string CliLogin { get; set; }

    }
}
