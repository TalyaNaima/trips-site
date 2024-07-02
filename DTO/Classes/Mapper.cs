using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class Mapper : Profile
    {
        public Mapper()
        {

            //Invitation
            CreateMap<Invitation, InvitationDTO>()
                   //הוספת שם פרטי ושם משפחה בשדה אחד
                   .ForMember(dest => dest.InvitationUserName, opt => opt.MapFrom(src => src.InvitationUser.FirstName + " " + src.InvitationUser.LastName))
                    //הוספת יעד לטיול
                    .ForMember(dest => dest.InvitationTripYhad, opt => opt.MapFrom(src => src.InvitationTrip.Yhad))
                    //הוספת תאריך לטיול
                    .ForMember(dest => dest.InvitationTripDate, opt => opt.MapFrom(src => src.InvitationTrip.TripDate));

            CreateMap<InvitationDTO, Invitation>()
                 .ForMember(dest => dest.InvitationId, opt => opt.Ignore());

            //Trip
            CreateMap<Trip, TripDTO>()
                   .ForMember(dest => dest.TripTypeName, opt => opt.MapFrom(src => src.TripType.TypeName));
            // .ForMember(dest => dest.IsFirstAid, opt => opt.MapFrom(src =>trur));
            CreateMap<TripDTO, Trip>()
                 .ForMember(dest => dest.TripId, opt => opt.Ignore());
    //     


            //TypeTrip
            CreateMap<TypeTrip, TypeTripDTO>();

            CreateMap<TypeTripDTO, TypeTrip>()
                 .ForMember(dest => dest.TypeId, opt => opt.Ignore());

            //User
            CreateMap<User, UserDTO>();

            CreateMap<UserDTO, User>()
                 .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
