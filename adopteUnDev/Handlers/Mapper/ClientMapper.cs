using adopteUnDev.Models;
using adopteUnDev.Models.ClientViewModel;
using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adopteUnDev.Handlers.Mapper
{
    public static class ClientMapper
    {
        public static ClientListItem ToListItem(this BLL.Entities.Client entity)
        {
            if (entity is null) return null;
            return new ClientListItem()
            {
                idClient = entity.idClient,
                CliName = entity.CliName,
                CliFirstName = entity.CliFirstName,
                CliCompany = entity.CliCompany,
                CliLogin = entity.CliLogin
            };
        }

        public static BLL.Entities.Client ToBLL(this ClientCreateForm entity)
        {
            if (entity is null) return null;
            return new BLL.Entities.Client()
            {
                CliName = entity.CliName,
                CliFirstName = entity.CliFirstName,
                CliCompany = entity.CliCompany,
                CliMail = entity.CliMail,
                CliLogin = entity.CliLogin,
                CliPassword=entity.CliPassword
            };
        }

        public static ClientDetails ToDetails(this Client entity)
        {
            if (entity is null) return null;
            return new ClientDetails()
            {
                CliName = entity.CliName,
                CliFirstName = entity.CliFirstName,
                CliCompany = entity.CliCompany,
                CliMail = entity.CliMail,
                CliLogin = entity.CliLogin
            };
        }
    }
}
