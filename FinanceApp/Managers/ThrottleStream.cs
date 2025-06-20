using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceApp.Managers
{
    internal class ThrottleStream : Stream
    {
        private readonly Stream baseStream;
        private readonly long maxBytesPerSecond;
        private long bytesReadThisSecond = 0;
        private DateTime lastReset = DateTime.Now;

        public ThrottleStream(Stream baseStream, long maxBytesPerSecond)
        {
            this.baseStream = baseStream;
            this.maxBytesPerSecond = maxBytesPerSecond;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            CheckThrottle();
            int bytesToRead = (int)Math.Min(count, maxBytesPerSecond - bytesReadThisSecond);
            if (bytesToRead <= 0)
            {
                await Task.Delay(1000 - (int)(DateTime.Now - lastReset).TotalMilliseconds);
                CheckThrottle();
                bytesToRead = (int)Math.Min(count, maxBytesPerSecond);
            }
            int bytesRead = await baseStream.ReadAsync(buffer, offset, bytesToRead, cancellationToken);
            bytesReadThisSecond += bytesRead;
            return bytesRead;
        }

        private void CheckThrottle()
        {
            if ((DateTime.Now - lastReset).TotalSeconds >= 1)
            {
                bytesReadThisSecond = 0;
                lastReset = DateTime.Now;
            }
        }

        public override bool CanRead => baseStream.CanRead;

        public override bool CanSeek => throw new NotImplementedException();

        public override bool CanWrite => throw new NotImplementedException();

        public override long Length => throw new NotImplementedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}