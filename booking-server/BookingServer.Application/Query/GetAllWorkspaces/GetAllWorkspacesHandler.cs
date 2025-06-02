using AutoMapper;
using BookingServer.Application.DTOs;
using BookingServer.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.Workspace
{
    public class GetAllWorkspacesHandler : IRequestHandler<GetAllWorkspacesQuery, List<WorkspaceDto>>
    {
        private readonly IWorkspaceRepository repository;
        private readonly IMapper mapper;

        public GetAllWorkspacesHandler(IWorkspaceRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<WorkspaceDto>> Handle(GetAllWorkspacesQuery request, CancellationToken cancellationToken)
        {
            var workspaces = await repository.GetAllAsync(cancellationToken);
            
            return mapper.Map<List<WorkspaceDto>>(workspaces);
        }
    }
}