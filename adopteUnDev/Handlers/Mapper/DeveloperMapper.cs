using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adopteUnDev.Models;
using adopteUnDev.Models.DeveloperViewModel;
using BLL.Entities;

namespace adopteUnDev.Handlers.Mapper
{
    public static class DeveloperMapper
    {
        public static DeveloperListItem ToListItem(this BLL.Entities.Developer entity)
        {
            if (entity is null) return null;
            return new DeveloperListItem()
            {
                idDev = entity.idDev,
                DevName = entity.DevName,
                DevFirstName = entity.DevFirstName,
                DevBirthDate= entity.DevBirthDate,
                DevPicture = entity.DevPicture,
                DevHourCost = entity.DevHourCost,
                DevDayCost = entity.DevDayCost,
                DevMonthCost = entity.DevMonthCost,
                DevMail = entity.DevMail,
                DevCategPrincipal = entity.DevCategPrincipal

            };
        }

        public static BLL.Entities.Developer ToBLL(this DeveloperCreateFrom entity)
        {
            if (entity is null) return null;
            return new BLL.Entities.Developer
            {
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

        public static DeveloperDetails ToDetails(this Developer entity)
        {
            if (entity is null) return null;
            return new DeveloperDetails()
            {
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
    }
}
