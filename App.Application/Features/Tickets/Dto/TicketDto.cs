﻿namespace App.Application.Features.Tickets.Dto;

public record TicketDto(int Id, int EventId, int UserId, DateTimeOffset PurchaseDate);