﻿using App.Application.Features.Tickets.Dto;

namespace App.Application.Features.Users.Dto;

public record UserWithTicketsResponse(int Id, string FirstName, string LastName, string Email, List<TicketResponse> Tickets);