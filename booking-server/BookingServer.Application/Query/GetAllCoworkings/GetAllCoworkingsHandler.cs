using AutoMapper;
using BookingServer.Application.DTOs;
using BookingServer.Application.Interfaces;
using BookingServer.Application.Query.Workspace;
using BookingServer.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.GetAllCoworkings
{
    public class GetAllCoworkingsHandler : IRequestHandler<GetAllCoworkingsQuery, List<CoworkingDto>>
    {
        private readonly ICoworkingRepository repository;
        private readonly IMapper mapper;

        public GetAllCoworkingsHandler(ICoworkingRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<CoworkingDto>> Handle(GetAllCoworkingsQuery request, CancellationToken cancellationToken)
        {
            var coworkings = await repository.GetAllAsync(cancellationToken);
            return mapper.Map<List<CoworkingDto>>(coworkings);
        }
    }
}

