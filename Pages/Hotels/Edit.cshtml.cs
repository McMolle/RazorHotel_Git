using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Hotels
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public Hotel HotelToEdit { get; set; }

        [BindProperty] public int EditHotelNumber { get; set; }
        [BindProperty] public string EditHotelName { get; set; }
        [BindProperty] public string EditHotelAddress { get; set; }
        private Hotel _editedHotel;

        #region Dependencies and constructor-injection
        private IHotelService _hotelService;
        public EditModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        #endregion
        public void OnGet(int hotelnumber)
        {
            HotelToEdit = _hotelService.GetHotelFromId(hotelnumber);
        }

        public void OnGetMolleEdit(int hotelnr)
        {

        }

        public IActionResult OnPost()
        {
            _editedHotel = new Hotel(EditHotelNumber, EditHotelName, EditHotelAddress);
            

            if (_hotelService.UpdateHotel(_editedHotel, HotelToEdit.HotelNr))
            {
                return RedirectToPage("/Hotels/GetAllHotels");
            }
            else
            {
                return RedirectToPage("/Hotels/GetAllHotels");
            }
        }
    }
}
