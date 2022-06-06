using FinalWebApp.Context;
using FinalWebApp.Entities;
using FinalWebApp.Repositories.Interfaces;

namespace FinalWebApp.Repositories;

public class ContactRepository: BaseRepository<ContactRepository, ContactEntity, string>, IContactRepository
{
    public ContactRepository(ILogger<ContactRepository> logger, ApplicationContext context) : base(logger, context)
    {
    }
}