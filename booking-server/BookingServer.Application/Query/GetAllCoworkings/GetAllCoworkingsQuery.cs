﻿using BookingServer.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Application.Query.GetAllCoworkings
{
    public record GetAllCoworkingsQuery: IRequest<List<CoworkingDto>>
    {
    }
}
