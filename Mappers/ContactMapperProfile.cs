using AutoMapper;
using FinalWebApp.Dto.Requests.Contact;
using FinalWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Mappers
{
    public class ContactMapperProfile: Profile
    {
        public ContactMapperProfile()
        {
            CreateMap<ContactCreateRequest, ContactEntity>();
        }
    }
}
