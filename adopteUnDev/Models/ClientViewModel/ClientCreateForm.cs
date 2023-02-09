using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace adopteUnDev.Models.ClientViewModel
{
    public class ClientCreateForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Nom de Famille")]
        public string CliName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Prénom")]
        public string CliFirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(250)]
        [DisplayName("Email")]
        public string CliMail { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Entreprise")]
        public string CliCompany { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Login")]
        public string CliLogin { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(32)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string CliPassword { get; set; }
    }
}
