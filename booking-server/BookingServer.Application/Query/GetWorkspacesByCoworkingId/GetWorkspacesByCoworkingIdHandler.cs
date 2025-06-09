using AutoMapper;
using BookingServer.Application.DTOs;
using BookingServer.Application.Exceptions;
using BookingServer.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.GetWorkspacesByCoworkingId
{
    public class GetWorkspacesByCoworkingIdHandler : IRequestHandler<GetWorkspacesByCoworkingIdQuery, List<WorkspaceDto>>
    {
        private readonly IWorkspaceRepository repository;
        private readonly IMapper mapper;

        public GetWorkspacesByCoworkingIdHandler(IWorkspaceRepository repository, IMapper mapper)
        {
            this.repository = repository;   
            this.mapper = mapper;
        }

        public async Task<List<WorkspaceDto>> Handle(GetWorkspacesByCoworkingIdQuery request, CancellationToken cancellationToken)
        {
            var workspace = await repository.GetWorkspacesByCoworkingIdAsync(request.id, cancellationToken)
           ?? throw new NotFoundException($"Workspaces with given id doesn't exist.");

            return mapper.Map<List<WorkspaceDto>>(workspace);
        }
    }
}
