using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Mandegar.Services.Attachments
{
    public class Comperssor : IComperssor
    {
        public byte[] DeflateCompress(byte[] data)
        {
            using (MemoryStream input = new MemoryStream(data))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (DeflateStream deflate = new DeflateStream(stream, CompressionLevel.Optimal))
                    {
                        input.CopyTo(deflate);

                        deflate.Close();

                        data = stream.ToArray();
                    }
                }
            }

            return data;
        }

        public byte[] DeflateDecompress(byte[] data)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (MemoryStream stream = new MemoryStream(data))
                {
                    stream.Position = 0;

                    using (DeflateStream deflate = new DeflateStream(stream, CompressionMode.Decompress))
                    {
                        deflate.CopyTo(output);

                        deflate.Close();

                        data = output.ToArray();
                    }
                }
            }

            return data;
        }

        public byte[] GZipCompress(byte[] data)
        {
            using (MemoryStream input = new MemoryStream(data))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (GZipStream deflate = new GZipStream(stream, CompressionLevel.Optimal))
                    {
                        input.CopyTo(deflate);

                        deflate.Close();

                        data = stream.ToArray();
                    }
                }
            }

            return data;
        }

        public byte[] GZipDecompress(byte[] data)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (MemoryStream stream = new MemoryStream(data))
                {
                    stream.Position = 0;

                    using (GZipStream deflate = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        deflate.CopyTo(output);

                        deflate.Close();

                        data = output.ToArray();
                    }
                }
            }

            return data;
        }
    }
}
