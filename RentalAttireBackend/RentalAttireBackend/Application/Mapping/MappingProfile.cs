using AutoMapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RentalAttireBackend.Application.Employees.Commands.CreateEmployee;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;
using RentalAttireBackend.Application.Users.Commands.CreateUser;
using RentalAttireBackend.Domain.Entities;

namespace RentalAttireBackend.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.ToString()))
                .ForMember(dest => dest.RolePosition, opt => opt.MapFrom(src => src.Role.RolePosition.ToString()));

            CreateMap<CreateEmployeeCommand, Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.FullName, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender, true)))
                .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => Enum.Parse<MaritalStatus>(src.MaritalStatus, true)))
                .ForMember(dest => dest.RoleId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.HashedPassword, opt => opt.MapFrom(src => src.Password));

        }

        private static DateTime GetPhilippineTime()
        {
            // Philippine timezone is UTC+8
            TimeZoneInfo philippineTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, philippineTimeZone);
        }

        private static int GetRolePosition(string position)
        {
            return position switch
            {
                "Administrator" => 0,
                "ClothesManager" => 1,
                "Cashier" => 2,
                _ => throw new ArgumentException($"Unkown Role Position: {position}"),
            };
        }
    }
}
