using AutoMapper;
using FinalWebApp.Dto.Requests.Transaction;
using FinalWebApp.Dto.Responses.Transaction;
using FinalWebApp.Entities;

namespace FinalWebApp.Mappers;

public class TransactionMapperProfile: Profile
{
    public TransactionMapperProfile()
    {
        CreateMap<TransactionCreateRequest, TransactionEntity>()
            .ForSourceMember(s => s.UserId, d => d.DoNotValidate())
            .ForSourceMember(s => s.OrdersId, d => d.DoNotValidate());
        CreateMap<TransactionEntity, TransactionGetListResponse>();
    }
}