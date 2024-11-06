using App.Application.Contracts.Persistence;
using App.Application.Features.Tickets.Create;
using App.Application.Features.Tickets.Dto;
using App.Application.Features.Tickets.Update;
using App.Domain.Entities;
using AutoMapper;
using QRCoder;
using System.Drawing.Imaging;
using System.Net;

namespace App.Application.Features.Tickets
{
    public class TicketService(ICustomerRepository customerRepository, IEventRepository eventRepository, ITicketRepository ticketRepository, IUnitOfWork unitOfWork, IMapper mapper) : ITicketService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateTicketRequest request)
        {
            var eventEntityExists = await eventRepository.GetByIdAsync(request.EventId);
            var customerEntityExists = await customerRepository.GetByIdAsync(request.CustomerId);

            if (eventEntityExists == null || customerEntityExists == null)
            {
                return ServiceResult<int>.Fail("Etkinlik veya müşteri bulunamadı", HttpStatusCode.NotFound);
            }

            var qrData = $"{eventEntityExists.Name}-{customerEntityExists.Email}-{request.CustomerId}";

            var qrCodeBase64 = GenerateQRCode(qrData);

            var newTicket = mapper.Map<Ticket>(request);
            newTicket.QrCode = qrCodeBase64;

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
                return ServiceResult<TicketDto>.Fail("Ticket bulunamadı", HttpStatusCode.NoContent);
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

        public async Task<ServiceResult> UpdateAsync(int id, UpdateTicketRequest request)
        {
            var ticket = await ticketRepository.GetByIdAsync(id);

            var eventEntityExists = await eventRepository.GetByIdAsync(request.EventId);
            var customerEntityExists = await customerRepository.GetByIdAsync(request.CustomerId);

            if (eventEntityExists == null || customerEntityExists == null)
            {
                return ServiceResult.Fail("Etkinlik veya müşteri bulunamadı", HttpStatusCode.NotFound);
            }

            mapper.Map(request, ticket);

            ticketRepository.Update(ticket!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        private string GenerateQRCode(string data)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new QRCode(qrCodeData);

            // QR kodunu Bitmap formatında oluşturuyoruz
            using (var qrBitmap = qrCode.GetGraphic(20))
            {
                using (var ms = new MemoryStream())
                {
                    // QR kodunu PNG formatında kaydediyoruz
                    qrBitmap.Save(ms, ImageFormat.Png);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}
