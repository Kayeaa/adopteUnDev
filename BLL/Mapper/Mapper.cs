using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mapper
{
    static class Mapper
    {
        //DAL EN BLL

        public static BLL.Entities.Client ToBLL(this DAL.Entities.Client entity)
        {
            if (entity is null) return null;
            return new BLL.Entities.Client()
            {
                idClient = entity.idClient,
                CliName = entity.CliName,
                CliFirstName = entity.CliFirstName,
                CliMail = entity.CliMail,
                CliCompany = entity.CliCompany,
                CliLogin = entity.CliLogin,
                CliPassword = entity.CliPassword

            };
        }
        //BLL to DAL
        public static DAL.Entities.Client ToDAL(this BLL.Entities.Client entity)
        {
            if (entity is null) return null;
            return new DAL.Entities.Client()
            {
                idClient = entity.idClient,
                CliName = entity.CliName,
                CliFirstName = entity.CliFirstName,
                CliMail = entity.CliMail,
                CliCompany = entity.CliCompany,
                CliLogin = entity.CliLogin,
                CliPassword = entity.CliPassword

            };
        }

        //DAL EN BLL
        public static BLL.Entities.Developer ToBLL(this DAL.Entities.Developer entity)
        {
            if (entity is null) return null;
            return new BLL.Entities.Developer()
            {
                idDev = entity.idDev,
                DevName = entity.DevName,
                DevFirstName = entity.DevFirstName,
                DevBirthDate = entity.DevBirthDate,
                DevPicture = entity.DevPicture,
                DevHourCost = entity.DevHourCost,
                DevDayCost = entity.DevDayCost,
                DevMonthCost = entity.DevMonthCost,
                DevMail = entity.DevMail,
                DevCategPrincipal = entity.DevCategPrincipal
            };
        }

        //BLL to DAL
        public static DAL.Entities.Developer ToDAL(this BLL.Entities.Developer entity)
        {
            if (entity is null) return null;
            return new DAL.Entities.Developer()
            {
                idDev = entity.idDev,
                DevName = entity.DevName,
                DevFirstName = entity.DevFirstName,
                DevBirthDate = entity.DevBirthDate,
                DevPicture = entity.DevPicture,
                DevHourCost = entity.DevHourCost,
                DevDayCost = entity.DevDayCost,
                DevMonthCost = entity.DevMonthCost,
                DevMail = entity.DevMail,
                DevCategPrincipal = entity.DevCategPrincipal
            };
        }

        //DAL EN BLL
        public static BLL.Entities.ITLang ToBLL(this DAL.Entities.ITLang entity)
        {
            if (entity is null) return null;
            return new BLL.Entities.ITLang()
            {
                idIT = entity.idIT,
                ITLabel = entity.ITLabel
            };
        }

        //BLL to DAL
        public static DAL.Entities.ITLang ToDAL(this BLL.Entities.ITLang entity)
        {
            if (entity is null) return null;
            return new DAL.Entities.ITLang()
            {
                idIT = entity.idIT,
                ITLabel = entity.ITLabel
            };
        }

        //DAL EN BLL
        public static BLL.Entities.Categories ToBLL(this DAL.Entities.Categories entity)
        {
            if (entity is null) return null;
            return new BLL.Entities.Categories()
            {
                idCategory = entity.idCategory,
                CategLabel = entity.CategLabel
            };
        }

        //BLL to DAL
        public static DAL.Entities.Categories ToDAL(this BLL.Entities.Categories entity)
        {
            if (entity is null) return null;
            return new DAL.Entities.Categories()
            {
                idCategory = entity.idCategory,
                CategLabel = entity.CategLabel
            };
        }
    }
}