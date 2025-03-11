using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoApiCalls.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Layouts
    {
        single, pip1, pip2, pip3, pip4, pip5, pip6, pip7, pip8, pbp, quad1, quad2, quad3, quad4, quad5, quad6, quad7, quad8, quad9
    }
}
