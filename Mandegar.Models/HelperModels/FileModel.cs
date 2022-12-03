using System;

namespace Mandegar.Models.HelperModels
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public byte[] Data { get; set; }
        public long Size { get; set; }

        #region explicit

        public static explicit operator FileTableModel(FileModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new FileTableModel
            {
                Cached_File_Size = model.Size,
                File_Stream = model.Data,
                Name = model.Name,
                Stream_Id = model.Id
            };
        }

        public static explicit operator FileModel(FileTableModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new FileModel
            {
                Size = model.Cached_File_Size,
                Data = model.File_Stream,
                Name = model.Name,
                Id = model.Stream_Id
            };
        }

        #endregion
    }
}
