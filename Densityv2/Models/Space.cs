using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Densityv2.Models;
using Newtonsoft.Json;

namespace Densityv2
{
    public class Space
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("space_type")]
        public string SpaceType { get; set; }

        [JsonProperty("function")]
        public string Function { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("technologies")]
        public List<string> Technologies { get; set; }

        [JsonProperty("current_count")]
        public long CurrentCount { get; set; }

        [JsonProperty("capacity")]
        public long? Capacity { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("ancestry", NullValueHandling = NullValueHandling.Ignore)]
        public List<Ancestry> Ancestry { get; set; }
    }
}
