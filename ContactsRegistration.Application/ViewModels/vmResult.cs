using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ContactsRegistration.Application.ViewModels
{
    public class vmResult
    {
        [DataMember]
        public object Data { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string FriendlyErrorMessage { get; set; }
        [DataMember]
        public string StackTrace { get; set; }

    }
}
