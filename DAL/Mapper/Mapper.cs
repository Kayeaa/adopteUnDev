using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    static class Mapper
    {
        public static Client ToClient(this IDataRecord record)
        {
            if (record is null) return null;
            return new Client()
            {
                idClient = (int)record[nameof(Client.idClient)],
                CliName = (string)record[nameof(Client.CliName)],
                CliFirstName = (string)record[nameof(Client.CliFirstName)],
                CliMail = (string)record[nameof(Client.CliMail)],
                CliCompany = (string)record[nameof(Client.CliCompany)],
                CliLogin = (string)record[nameof(Client.CliLogin)],
                CliPassword = "********"
                //Valeur null ex: adresse =(record[nameof(Client.addresse)] is DBNull)? null = (string)reader[nameof(Client.adresse)]
            };
        }

        public static Developer ToDeveloper (this IDataRecord record)
        {
            if (record is null) return null;
            return new Developer()
            {
                idDev = (int)record[nameof(Developer.idDev)],
                DevName = (string)record[nameof(Developer.DevName)],
                DevFirstName = (string)record[nameof(Developer.DevFirstName)],
                DevBirthDate = (DateTime) record[nameof(Developer.DevBirthDate)],
                DevHourCost = (double)record[nameof(Developer.DevHourCost)],
                DevDayCost = (double)record[nameof(Developer.DevDayCost)],
                DevMonthCost = (double)record[nameof(Developer.DevMonthCost)],
                DevMail = (string)record[nameof(Developer.DevMail)],
                DevCategPrincipal = (string)record[nameof(Developer.DevCategPrincipal)]

            };
        }

        public static ITLang ToITLang(this IDataRecord record)
        {
            if (record is null) return null;
            return new ITLang()
            {
                idIT = (int)record[nameof(ITLang.idIT)],
                ITLabel = (string)record[nameof(ITLang.ITLabel)]
            };
        }

        public static Categories ToCategories(this IDataRecord record)
        {
            if (record is null) return null;
            return new Categories()
            {
                idCategory = (int)record[nameof(Categories.idCategory)],
                CategLabel = (string)record[nameof(Categories.CategLabel)]
            };
        }
    }
}
