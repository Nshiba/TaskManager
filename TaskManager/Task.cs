using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TaskManager
{
    [DataContract]
    public class Task
    {
        [DataMember]
        public String deadline { get; set; }
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String tag { get; set; }
        [DataMember]
        public String outline { get; set; }
    }
}
