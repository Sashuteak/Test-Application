namespace Test_App.Server_Requests
{

    public class Rootobject
    {
        public string CommandStatus { get; set; }
        public string rows { get; set; }
        public List[] list { get; set; }
    }

    public class List
    {
        public string id { get; set; }
        public string name { get; set; }
        public string buildingId { get; set; }
        public string buildingName { get; set; }
        public string cityId { get; set; }
        public string hasPNG { get; set; }
        public string hallType { get; set; }
        public string description { get; set; }
    }

}
