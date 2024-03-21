using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Hotels
{
    public class CreateModel : PageModel
    {
        public string Message;
        private Hotel _newHotel { get; set; }

        #region Bound user-input Properties
        [BindProperty] public int NewHotelNumber { get; set; }
        [BindProperty] public string NewHotelName { get; set; }
        [BindProperty] public string NewHotelAdress { get; set; }
        #endregion

        #region Dependencies and constructor-injection
        private IHotelService _hotelService;
        public CreateModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        #endregion

        public void OnGet()
        {
        }

        public void OnPost()
        {
            _newHotel = new Hotel(NewHotelNumber, NewHotelName, NewHotelAdress);
            Message = _newHotel.ToString();
            if (_newHotel != null)
            {
                _hotelService.CreateHotel(_newHotel);
            }
            else
            {
                Message = "could not create new hotel";
            }
        }
    }
}
