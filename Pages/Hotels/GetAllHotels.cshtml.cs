using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Hotels
{
    public class GetAllHotelsModel : PageModel
    {
        
        public List<Hotel> AllHotels { get; set; }
        public string Message { get; set; }

        #region Dependencies and constructor-injection
        private IHotelService _hotelService;
        public GetAllHotelsModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        #endregion
        public void OnGet()
        {
            AllHotels = _hotelService.GetAllHotel();
        }

        public void OnGetDeleteHandler(int hotelnumber)
        {
            AllHotels = _hotelService.GetAllHotel();
            Message = $"Deletehandler called for Hotel nr. {hotelnumber}";
        }
    }
}
