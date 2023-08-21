using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationApi.Model
{
    public class Reservation

    {
             [Key]
             [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string phone { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zipcode { get; set; }
            public string country { get; set; }
            public int vehicleid { get; set; }
            public Vehicles vehicle { get; set; }
            public bool IsMailSent  { get; set; }
    }

        public class Vehicles
        {
           [Key]
           public int VID { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
