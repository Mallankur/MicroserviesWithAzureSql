namespace CustomerApi.Model
{
    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string phone  { get; set; }

        public string city { get; set; }


        public string state { get; set; }


        public string zipcode { get; set; }


        public string country { get; set; }

        public int  vehicleid { get; set; }

        public Vehicle vehicle { get; set; }



    }
}
