using System;
using AutoMapper;
using productMicroService.Data.Dto.Incomming;
using productMicroService.Entities;

namespace productMicroService.Data.Dto.Outcomming
{
	public class ProductRead
	{
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string SerialNumber { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public bool IsDeactivated { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductCreateModel, Product>();
            //CreateMap<ProductUpdate, Product>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !srcMember.Equals(0)));
        }
    }
}

