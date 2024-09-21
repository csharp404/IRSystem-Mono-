namespace Data.EntityModels
{
    public class Room
    {
        public string RoomId { get; set; }

        public string NLivingRoom { get; set; }
        public string NBathroom { get; set; }
        public string NGarage { get; set; }
        public string NBedroom { get; set; }
        public string NKitchen { get; set; }
        public string NFloors { get; set; }
        public string NRooms { get; set; }

        public string RealEsId { get; set; }
        public RealEs RealEs { get; set; }
    }
}
