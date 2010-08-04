using System;
using System.ServiceModel;
using System.IO;

namespace Server.Service
{
    [MessageContract]
    public class FileUploadMessage
    {
        [MessageHeader(MustUnderstand = true)]
        public MyFile file { get; set; }
        
        [MessageHeader(MustUnderstand = true)]
        public string userEmail;

        [MessageHeader(MustUnderstand = true)]
        public string userPass;

        [MessageBodyMember(Order = 1)]
        public Stream sourceStream { get; set; }

        public void Dispose()
        {
            // close stream when the contract instance is disposed. this ensures that stream is closed when file download is complete, since download procedure is handled by the client and the stream must be closed on server.
            // thanks Bhuddhike! http://blogs.thinktecture.com/buddhike/archive/2007/09/06/414936.aspx
            if (sourceStream != null)
            {
                sourceStream.Close();
                sourceStream = null;
            }
        }


    }
}
