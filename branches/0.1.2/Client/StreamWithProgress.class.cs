
using System;
using System.IO;
using System.Threading;

namespace Client
{
    [SerializableAttribute]
    public class StreamWithProgress : Stream
    {
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
        
        private long bytesRead;

        private Stream file;
        private readonly long length;

        //--------------------------------------------------------------------------------
        public class ProgressChangedEventArgs : EventArgs
        {
            public long BytesRead;
            public long Length;

            public ProgressChangedEventArgs(long BytesRead, long Length)
            {
                this.BytesRead = BytesRead;
                this.Length = Length;
            }
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public StreamWithProgress(Stream file)
        {
            this.file = file;
            try
            {
                length = file.Length;
            }
            catch(Exception){  }
            bytesRead = 0;
            if (ProgressChanged != null) ProgressChanged(this, new ProgressChangedEventArgs(bytesRead, length));
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public double GetProgress()
        {
            return ((double)bytesRead) / file.Length;
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public override bool CanRead
        {
            get { return true; }
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public override bool CanSeek
        {
            get { return false; }
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public override bool CanWrite
        {
            get { return true; }
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public override void Flush() { }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public override long Position
        {
            get { return bytesRead; }
            set { throw new Exception("The method or operation is not implemented."); }
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public override int Read(byte[] buffer, int offset, int count)
        {
            //Thread.Sleep(150);
            int result = file.Read(buffer, offset, count);
            bytesRead += result;
            if (ProgressChanged != null) ProgressChanged(this, new ProgressChangedEventArgs(bytesRead, length));
            return result;
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public override void Write(byte[] buffer, int offset, int count)
        {
            //Thread.Sleep(150);
            file.Write(buffer, offset, count);
            bytesRead += count;
            if (ProgressChanged != null) ProgressChanged(this, new ProgressChangedEventArgs(bytesRead, length));
        }
        //--------------------------------------------------------------------------------


        #region not implemented
        //--------------------------------------------------------------------------------
        public override long Length
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public override void SetLength(long value)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        //--------------------------------------------------------------------------------
        #endregion

        /*void IDisposable.Dispose()
        {
            file = null;
            file.Close();
            file.Dispose();
        }*/
    }
}
