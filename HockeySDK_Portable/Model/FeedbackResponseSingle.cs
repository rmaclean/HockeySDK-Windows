using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HockeyApp.Model
{
    [DataContract]
    public class FeedbackResponseSingle
    {
        private static ILog _log = HockeyLogManager.GetLog(typeof(FeedbackResponseSingle));
        public static FeedbackResponseSingle FromJson(Stream jsonStream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(FeedbackResponseSingle));
            return serializer.ReadObject(jsonStream) as FeedbackResponseSingle;
        }

        [DataMember(Name="feedback")]
        public FeedbackThread Feedback { get; private set; }

        [DataMember(Name="token")]
        public string FeedbackToken { get; private set; }
        
        [DataMember(Name="status")]
        public string Status { get; private set; }
       
    }

}
