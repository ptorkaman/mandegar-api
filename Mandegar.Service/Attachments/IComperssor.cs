namespace Mandegar.Services.Attachments
{
    public interface IComperssor
    {
        public byte[] DeflateCompress(byte[] data);

        public byte[] DeflateDecompress(byte[] data);

        public byte[] GZipCompress(byte[] data);

        public byte[] GZipDecompress(byte[] data);
    }
}
