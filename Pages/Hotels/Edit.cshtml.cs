using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Hotels
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Hotel ClickedHotel { get; set; }

        #region Dependencies and constructor-injection
        private IHotelService _hotelService;
        public EditModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        #endregion
        public void OnGet(int hotelnumber)
        {
            ClickedHotel = _hotelService.GetHotelFromId(hotelnumber);
        }

        public void OnGetMolleEdit(int hotelnr)
        {

        }

        public IActionResult OnPost()
        {
            if (_hotelService.UpdateHotel(ClickedHotel, ClickedHotel.HotelNr))
            {
                return RedirectToPage("/Hotels/GetAllHotels");
            }
            else
            {
                return RedirectToPage("./");
            }
        }
    }
}
