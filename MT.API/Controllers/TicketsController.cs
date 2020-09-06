using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AggriPortal.API.Contracts;
using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using ReflectionIT.Mvc.Paging;
using System.Linq;
using AggriPortal.API.Resources;
using Microsoft.Extensions.Configuration;
using AggriPortal.API.Security.Permission;
using System;
using AggriPortal.API.Extensions;
using AggriPortal.API.Domain.Enums;

namespace  AggriPortal.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.SuperAdmin + "," + Roles.Administrator + "," + Roles.ManageTickets)]
    public class TicketsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public TicketsController( IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper  )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        [HttpPost(ApiRoute.Ticket.Tickets)]
        public IActionResult GetTicketsRequest([FromBody] TicketsRequestDto req)
        {
            var data = unitOfWork.Ticket.GetTickets(req);

            int pageSize = req.PageSize ?? configuration.GetValue<int>("PagingOptions:PageSize");
            int pageNumber = req.PageNumber ?? configuration.GetValue<int>("PagingOptions:PageNumber");

            TicketsResponseDto response = new TicketsResponseDto()
            {
                Data = mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketsDto>>(PagingList.Create(data, pageSize, pageNumber)),
                TotalRecord = data.Count(),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            return Ok(response);
        }

        [HttpGet(ApiRoute.Ticket.FollowUp)]
        public async  Task<IActionResult> GetTicketFollowUp(Guid Id)
        {
            var currentUser = HttpContext.GetUserId();

            var data = unitOfWork.TicketFollowUp.GetTicketFollowUp(Id);
            if (data == null)
            {
                return NotFound(new BaseResponse(false, 404, "Previous request data was not found"));
            }
            foreach (var item in data)
            {
                var ticketFollowUp = await unitOfWork.TicketFollowUp.GetAsync(p => p.Id == item.Id);
                if (!ticketFollowUp.IsRead)
                {
                    ticketFollowUp.IsRead = true;
                    ticketFollowUp.ReadDate = DateTime.Now;
                }
                 unitOfWork.TicketFollowUp.UpdateAsync(ticketFollowUp);
                await unitOfWork.Commit();
            }

            TicketFollowUpResponseDto response = new TicketFollowUpResponseDto()
            {
                Data = mapper.Map<IEnumerable<TicketFollowUp>, IEnumerable<TicketFollowUpDto>>(data),
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Request has been complited successfully"
            };
            return Ok(response);
        }
        [HttpPost(ApiRoute.Ticket.TicketFollowUp)]
        public async Task<IActionResult> AddTicketFollowUpRequest([FromBody] TicketFollowUpRequestDto req)
        {
            var currentUser = HttpContext.GetUserId();

            var ticketFollowUp = new TicketFollowUp()
            {
                TicketId = req.TicketId,
                Message = req.Message,
                CreatedDate = DateTime.Now,
                CreatedBy = currentUser,
                IsRead = false,
                Sender = "1"
            }; 
            await unitOfWork.TicketFollowUp.AddAsync(ticketFollowUp);
            await unitOfWork.Commit();
            return Ok(new BaseResponse(true, 200, "Data has been added successfully"));
        }

        [HttpPost(ApiRoute.Ticket.UpdateStatus)]
        public async Task<IActionResult> UpdateTicketStatusRequest([FromBody] UpdateTicketStatusRequestDto req)
        {
            var ticket = await unitOfWork.Ticket.GetAsync(p => p.Id == req.TicketId);

            var currentUser = HttpContext.GetUserId();

            var ticketFollowUp = new TicketFollowUp()
            {
                TicketId = req.TicketId,
                Message = req.Message,
                CreatedDate = DateTime.Now,
                CreatedBy = currentUser,
                Sender = "1"
            };
            if (ticket == null)
            {
                return NotFound(new BaseResponse(false, 404, "data is not found"));
            }
            ticket.TicketStatusId = req.TicketStatusId;
            if(req.TicketStatusId == (int) TicketStatusEnum.Resolved)
            {
                ticket.ClosedBy = currentUser;
                ticket.ClosedDate = DateTime.Now;
            }    

            unitOfWork.Ticket.UpdateAsync(ticket);
            await unitOfWork.TicketFollowUp.AddAsync(ticketFollowUp);
            await unitOfWork.Commit();
            return Ok(new BaseResponse(true, 200, "data has been updated successfully"));
        }

    }
}
