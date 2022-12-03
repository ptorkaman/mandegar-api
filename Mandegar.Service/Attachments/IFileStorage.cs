using Mandegar.Models.HelperModels;
using System;

namespace Mandegar.Services.Attachments
{
    public interface IFileStorage
    {
        public bool Add(FileModel file);

        public Guid Add(string name, byte[] data);

        public bool Exists(Guid id);

        public FileModel Find(string name);

        public FileModel Get(Guid id);

        public bool Remove(Guid id);

        public bool Save(Guid id, string path);

        public bool Save(Guid id, string path, string name);

        public int Shrink();
    }
}
