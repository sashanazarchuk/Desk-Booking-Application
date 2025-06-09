using AutoMapper;
using BookingServer.Application.DTOs;
using BookingServer.Domain.Entities;
using BookingServer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Workspace 
            CreateMap<Workspace, WorkspaceDto>()
                .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src.WorkspaceAmenities.Select(wa => wa.Amenity)));

            CreateMap<WorkspaceDto, Workspace>();

            // Room  
            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.WorkspaceType, opt => opt.MapFrom(src => src.WorkspaceType.ToString()));

            CreateMap<RoomDto, Room>()
                .ForMember(dest => dest.WorkspaceType, opt => opt.Ignore());

            // WorkspacePhoto  
            CreateMap<WorkspacePhoto, WorkspacePhotoDto>().ReverseMap();

            // Amenity
            CreateMap<Amenity, AmenityDto>().ReverseMap();

            // Booking
            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.Workspace, opt => opt.MapFrom(src => src.Rooms.Workspace))
                .ReverseMap()
                .ForMember(dest => dest.Rooms, opt => opt.Ignore());

            CreateMap<CreateBookingDto, Booking>();


            CreateMap<Booking, PatchBookingDto>()
                .ForMember(dest => dest.Workspace, opt => opt.MapFrom(src => src.Rooms.Workspace))
                .ForMember(dest => dest.WorkspaceType, opt => opt.MapFrom(src => src.Rooms.WorkspaceType))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId));

            CreateMap<PatchBookingDto, Booking>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));


            //Coworking
            CreateMap<Coworking, CoworkingDto>()
             .ForMember(dest => dest.OpenSpaceCount, opt => opt.MapFrom(src =>
                 src.Workspaces.SelectMany(ws => ws.Rooms)
                     .Where(r => r.WorkspaceType == WorkspaceType.OpenSpace)
                     .Sum(r => r.Capacity)))
             .ForMember(dest => dest.PrivateRoomCount, opt => opt.MapFrom(src =>
                 src.Workspaces.SelectMany(ws => ws.Rooms)
                     .Where(r => r.WorkspaceType == WorkspaceType.PrivateRoom)
                     .Sum(r => r.RoomsCount)))
             .ForMember(dest => dest.MeetingRoomCount, opt => opt.MapFrom(src =>
                 src.Workspaces.SelectMany(ws => ws.Rooms)
                     .Where(r => r.WorkspaceType == WorkspaceType.MeetingRoom)
                     .Sum(r => r.RoomsCount)));

        }
    }
}
