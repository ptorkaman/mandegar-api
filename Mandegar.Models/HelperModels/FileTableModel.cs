using System;

namespace Mandegar.Models.HelperModels
{
    public class FileTableModel
    {
        public Guid Stream_Id { get; set; }
        public byte[] File_Stream { get; set; }
        public string Name { get; set; }
        public long Cached_File_Size { get; set; }
    }
}
