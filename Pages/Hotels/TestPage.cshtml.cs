using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Hotels
{
    public class TestPageModel : PageModel
    {
        private IHotelService _hotelService;
        
        public Hotel ClickedHotel { get; set; }
        public string Message { get; set; }
        private int _count = 0;

        public TestPageModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public void OnGet()
        {
            ClickedHotel = _hotelService.GetHotelFromId(3);
            Message = $"OnGetCalled! ClickedHotel = [{ClickedHotel.HotelNr}] {ClickedHotel.Navn}";
        }

        public void OnGetNavn()
        {
            Message = "OnGetNavn";
        }

    }
}
