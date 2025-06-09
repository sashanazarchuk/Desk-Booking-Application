using AutoMapper;
using BookingServer.Application.DTOs;
using BookingServer.Application.Interfaces;
using BookingServer.Application.Interfaces.AI;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingServer.Application.Services
{
    public class PromptReaderService : IPromptReaderService
    {
        private readonly string _promptFilePath;

        private readonly IBookingRepository _bookingRepository;
        private readonly IWorkspaceRepository _workspaceRepository;
        private readonly ICoworkingRepository _coworkingRepository;
        private readonly IMapper mapper;
        public PromptReaderService(IMapper mapper, IConfiguration configuration, IBookingRepository bookingRepository, IWorkspaceRepository workspaceRepository, ICoworkingRepository coworkingRepository) {


            _promptFilePath = configuration["Prompts:SystemPromptPath"]
                ?? throw new ArgumentNullException("Prompts:SystemPromptPath", "Configuration value is missing.");

            _bookingRepository = bookingRepository;
            _workspaceRepository = workspaceRepository;
            _coworkingRepository = coworkingRepository;
            this.mapper = mapper;   
        }


        public async Task<string> GenerateDynamicPromptAsync(CancellationToken cancellationToken)
        {
            var bookings = await _bookingRepository.GetAllAsync(cancellationToken);
            var workspaces = await _workspaceRepository.GetAllAsync(cancellationToken);
            var coworkings = await _coworkingRepository.GetAllAsync(cancellationToken);

            var bookingDtos = mapper.Map<List<BookingDto>>(bookings);
            var workspaceDtos = mapper.Map<List<WorkspaceDto>>(workspaces);
            var coworkingDtos = mapper.Map<List<CoworkingDto>>(coworkings);


            // Short description of booking
            var bookingSummary = bookingDtos.Select((b, i) =>
                $"{i + 1}. {b.Name} booked {b.Workspace.Name}, RoomCapacity: {b.Rooms.Capacity}, RoomCount: {b.Rooms.RoomsCount}, SeatsBooked: {b.SeatsBooked},  StartDate: {b.StartDate:dd.MM.yyyy}, EndDate: {b.EndDate:dd.MM.yyyy}");


            // Short description of workspace
            var workspaceSummary = workspaceDtos.Select((w, i) =>
                $"{i + 1}. {w.Name}: rooms: {w.Rooms.Count}");

            // Short description of coworkings
            var coworkingSummary = coworkingDtos.Select((c, i) =>
                $"{i + 1}. {c.Name}, address: {c.Address}, OpenSpace: {c.OpenSpaceCount}, PrivateRooms: {c.PrivateRoomCount}, MeetingRooms: {c.MeetingRoomCount}");

            // Form the final description for AI
            var prompt =
                "Here are the current bookings: \r\n:\n" + string.Join("\n", bookingSummary) + "\n\n" +
                "Here are the available workspaces: \n" + string.Join("\n", workspaceSummary) + "\n\n" +
                "Here is information about coworking spaces: \r\n:\n" + string.Join("\n", coworkingSummary);

            return prompt;
  
        }


        public async Task<string> GetSystemPromptAsync(CancellationToken cancellationToken)
        {
            if (!File.Exists(_promptFilePath))
                throw new FileNotFoundException("Prompt file not found", _promptFilePath);

            return await File.ReadAllTextAsync(_promptFilePath, cancellationToken);
        }
    }
}
