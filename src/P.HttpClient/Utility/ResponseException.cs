using System.Runtime.Serialization;

namespace P.HttpClient.Utility
{
    [DataContract]
    public class ResponseException : Exception
    {
        public ResponseException()
        {

        }

        public ResponseException(Exception ex)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;

            if (ex.InnerException != null)
                InnerException = new ResponseException(ex.InnerException);
        }

        [DataMember]
        public new string Message { get; set; }
        [DataMember]
        public new string StackTrace { get; set; }
        [DataMember]
        public new ResponseException InnerException { get; set; }
    }
}
