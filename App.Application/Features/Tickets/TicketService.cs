using App.Application.Contracts.Persistence;
using App.Application.Features.QRCodes;
using App.Application.Features.Tickets.Create;
using App.Application.Features.Tickets.Dto;
using App.Application.Features.Tickets.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;
using System.Text.Json;

namespace App.Application.Features.Tickets
{
    public class TicketService(IUserRepository userRepository, IEventRepository eventRepository, ITicketRepository ticketRepository, IUnitOfWork unitOfWork, IMapper mapper, IQRCodeService qRCodeService) : ITicketService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateTicketRequest request)
        {
            var eventEntityExists = await eventRepository.GetByIdAsync(request.EventId);
            var userEntityExists = await userRepository.GetByIdAsync(request.UserId);

            if (eventEntityExists is null || userEntityExists is null)
            {
                return ServiceResult<int>.Fail("Etkinlik veya müşteri bulunamadı", HttpStatusCode.NotFound);
            }

            var newTicket = mapper.Map<Ticket>(request);

            await ticketRepository.AddAsync(newTicket);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.Success(newTicket.Id, HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var ticket = await ticketRepository.GetByIdAsync(id);

            ticketRepository.Delete(ticket!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<TicketDto>>> GetAllListAsync()
        {
            var tickets = await ticketRepository.GetAllAsync();

            var ticketsAsDto = mapper.Map<List<TicketDto>>(tickets);

            return ServiceResult<List<TicketDto>>.Success(ticketsAsDto);
        }

        public async Task<ServiceResult<TicketDto>> GetByIdAsync(int id)
        {
            var ticket = await ticketRepository.GetByIdAsync(id);

            if (ticket is null)
            {
                return ServiceResult<TicketDto>.Fail("Ticket bulunamadı", HttpStatusCode.NotFound);
            }

            var ticketAsDto = mapper.Map<TicketDto>(ticket);

            return ServiceResult<TicketDto>.Success(ticketAsDto);
        }

        public async Task<ServiceResult<List<TicketDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<TicketDto>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var tickets = await ticketRepository.GetAllPagedAsync(pageNumber, pageSize);

            var ticketAsDto = mapper.Map<List<TicketDto>>(tickets);

            return ServiceResult<List<TicketDto>>.Success(ticketAsDto);
        }

        public async Task<ServiceResult<byte[]>> QrCodeToUserAndEventAsync(int userId, int eventId)
        {
            var eventEntityExists = await eventRepository.GetByIdAsync(eventId);
            var userEntityExists = await userRepository.GetByIdAsync(userId);

            if (eventEntityExists is null || userEntityExists is null)
            {
                return ServiceResult<byte[]>.Fail("Etkinlik veya müşteri bulunamadı", HttpStatusCode.NotFound);
            }

            var plainObject = new
            {
                eventEntityExists.Name,
                eventEntityExists.Date,
                eventEntityExists.Price,
                userEntityExists.Email
            };

            string plainText = JsonSerializer.Serialize(plainObject);

            return ServiceResult<byte[]>.Success(qRCodeService.GenerateQRCode(plainText));
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateTicketRequest request)
        {
            var ticket = await ticketRepository.GetByIdAsync(id);

            var eventEntityExists = await eventRepository.GetByIdAsync(request.EventId);
            var userEntityExists = await userRepository.GetByIdAsync(request.UserId);

            if (eventEntityExists == null || userEntityExists == null)
            {
                return ServiceResult.Fail("Etkinlik veya müşteri bulunamadı", HttpStatusCode.NotFound);
            }

            mapper.Map(request, ticket);

            ticketRepository.Update(ticket!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
