using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;

namespace GStation.Core.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<CustomerSignupDto, Customer>()
                .ForMember(customer => customer.Addresses, map => map
                    .MapFrom(customerSignupDto => customerSignupDto.Addresses
                        .Select(addressDto => new CustomerAddress
                            { 
                                Address = new Address 
                                { 
                                    PostalCode = addressDto.PostalCode,
                                    Street = addressDto.Street,
                                    Subdivision = addressDto.Subdivision,
                                    City = addressDto.City,
                                    StateId = addressDto.StateId,
                                }
                            }
                        )
                    )
                )
                .ReverseMap();
        }
    }
}
