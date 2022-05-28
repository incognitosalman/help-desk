using HelpDesk.Application.Features.Ticket.Queries.GetTicket;
using HelpDesk.Application.Features.Ticket.Queries.GetTicketsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var query = new GetTicketsListQuery();
                var result = await _mediator.Send(query);
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured", ex);
            }
            finally
            {
                //TODO: Add cleanup code
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var query = new GetTicketQuery(id);
                var result = await _mediator.Send(query);
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured", ex);
            }
            finally
            {
                //TODO: Add cleanup code
            }
        }


    }
}
