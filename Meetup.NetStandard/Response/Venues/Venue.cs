using System;
using Newtonsoft.Json;

namespace Meetup.NetStandard.Response.Venues
{
    public class Venue:MeetupVenue
    {
        [JsonProperty("visibility")]
        public VenueVisibility Visibility { get; set; }

        [JsonProperty("taglist")]
        public string[] Tags { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("rating_count")]
        public int RatingCount { get; set; }

    }
}
