using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunderySystem.Models
{
    public class ReservationLaunderyRoom
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public DateTime Date { get; set; }
        public DateTime BookingTime { get; set; }
        public UserProfile userProfile { get; set; }
        public int userId { get; set; }
        public LaunderyRoom launderyRoom { get; set; }
        public int launderyRoomId { get; set; }
    }
}