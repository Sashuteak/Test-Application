using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App.Server_Requests
{
    public class GetEvents
    {
        public string CommandStatus { get; set; }
        public Event[] Events { get; set; }
        public string EventsCount { get; set; }
    }

    public class Event
    {
        public string ActivityId { get; set; }
        public string City { get; set; }
        public string CityId { get; set; }
        public string BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string BuildingAddress { get; set; }
        public string HallId { get; set; }
        public string HallName { get; set; }
        public string ActivityName { get; set; }
        public string Categories { get; set; }
        public string CategoriesIDs { get; set; }
        public Activitycategory[] ActivityCategories { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string EventType { get; set; }
        public string SalesEndTime { get; set; }
        public string ReserveEndTime { get; set; }
        public string OrganizerId { get; set; }
        public string Organizer { get; set; }
        public string OrganizerShortName { get; set; }
        public string EventImageSmall { get; set; }
        public string EventImageMedium { get; set; }
        public string EventImageBig { get; set; }
        public string EventImageLarge { get; set; }
        public string ActivityImageSmall { get; set; }
        public string ActivityImageMedium { get; set; }
        public string ActivityImageBig { get; set; }
        public string ActivityImageLarge { get; set; }
        public object[] Images { get; set; }
        public string ActivityDescriptionLong { get; set; }
        public string ActivityDescriptionLongText { get; set; }
        public string EventDescription { get; set; }
        public string EventDescriptionText { get; set; }
        public string ReplaceActivityDescription { get; set; }
        public string HasPNG { get; set; }
        public string HasSVG { get; set; }
        public string SVG { get; set; }
        public string IsCanvas { get; set; }
        public string HasCertificates { get; set; }
        public string ReplaceAvailabeTicketsCount { get; set; }
        public string ReplaceAvailabeTicketsCountWith { get; set; }
        public string IsETicketPassportRequired { get; set; }
        public string IsThermoTicketPassportRequired { get; set; }
        public string ClientInfoRequired { get; set; }
        public string ETicketEnabled { get; set; }
        public string PrintEnabled { get; set; }
        public string Currency { get; set; }
        public string HasProducts { get; set; }
        public Statistic[] Statistic { get; set; }
    }

    public class Activitycategory
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }

    public class Statistic
    {
        public string Price { get; set; }
        public string Quote { get; set; }
        public string Reserved { get; set; }
        public string Free { get; set; }
    }

}
