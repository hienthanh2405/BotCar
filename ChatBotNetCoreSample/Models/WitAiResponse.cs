using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotNetCoreSample.Models
{
    public class WitAiResponse
    {
        public Entities Entities { get; set; }
    }
    public class Entity
    {
        public string Confidence { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class Entities
    {
        public List<Entity> Service { get; set; }

        public List<Entity> Intent { get; set; }

    }
}
