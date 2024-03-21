using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IHotelService _hotelService;
        public List<Hotel> AllHotels { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHotelService hotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
        }

        public void OnGet()
        {
            AllHotels = _hotelService.GetAllHotel();
        }
    }
}
