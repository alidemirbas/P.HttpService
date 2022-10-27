using System.Runtime.Serialization;

namespace P.HttpClient.Utility
{
    [DataContract]
    public class ResponseException : Exception
    {
        [DataMember]
        public new string Message { get; set; }
        [DataMember]
        public new string StackTrace { get; set; }
        [DataMember]
        public new ResponseException InnerException { get; set; }
    }
}
