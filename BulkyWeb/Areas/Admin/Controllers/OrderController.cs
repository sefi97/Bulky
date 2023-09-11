using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
        }

        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			List<OrderHeader> orderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "AppplicationUser").ToList();

			return Json(new { data = orderHeaders });
		}
	}
}
