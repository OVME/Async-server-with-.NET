using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ThreadPoolService.Model
{
    [DataContract]
    public class Request
    {
        public int Id { get; set; }
        private int n;
        private string result;
        private string addedTime;
        private string handledTime;
        [DataMember]
        public int N { get { return n; } set { n = value; } }
        [DataMember]
        public string Result { get { return result; } set { result = value; } }
        [DataMember]
        public string AddedTime { get { return addedTime; } set { addedTime = value; } }
        [DataMember]
        public string HandledTime { get { return handledTime; } set { handledTime = value; } }


    }
}