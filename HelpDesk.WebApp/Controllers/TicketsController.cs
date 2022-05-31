using HelpDesk.Application.Contracts.Persistence;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Resuests;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        #region Read
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _ticketRepository.GetAsync();
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
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            var request = new TicketCreateRequest
            {
            };

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            try
            {
                //TODO: Add your code to create object
                var entry = new Ticket
                {
                    AgentId = request.AgentId,
                    Description = request.Description,
                    Email = request.Email,
                    GroupId = request.GroupId,
                    PriorityId = request.PriorityId,
                    SourceId = request.SourceId,
                    StateId = request.StateId,
                    Subject = request.Subject,
                    TypeId = request.TypeId,
                };

                var result = await _ticketRepository.CreateAsync(entry);
                if (result != 0)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", $"Error while creating new resource");
                return View(request);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured", ex);
            }
            finally { }
        }
        #endregion

        #region Detail
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var result = await _ticketRepository.GetByIdAsync(id);
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
        #endregion
    }
}
