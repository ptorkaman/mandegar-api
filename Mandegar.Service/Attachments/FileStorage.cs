using LiteDB;
using Mandegar.Models.HelperModels;
using System;
using System.IO;
using System.Linq;

namespace Mandegar.Services.Attachments
{
    public class FileStorage : IFileStorage, IDisposable
    {
        private readonly IComperssor compressor;
        private readonly LiteDatabase lite;
        private readonly ILiteStorage<string> storage;

        public FileStorage(
            IComperssor compressor
        )
        {
            this.compressor = compressor;

            BsonMapper.Global.EmptyStringToNull = false;

            string file = $"{nameof(FileStorage)}.LiteDb";

            string connection = $"Cache Size=8192;Flush=True;Initial Size=8KB;Journal=True;Mode=Exclusive;Timeout=00:00:08;Filename={file}";

            this.lite = new LiteDatabase(connection);

            this.storage = this.lite.FileStorage;
        }

        public bool Add(FileModel file)
        {
            file.Data = this.compressor.DeflateCompress(file.Data);

            using (MemoryStream stream = new MemoryStream(file.Data))
            {
                this.storage.Upload(file.Id.ToString(), file.Name, stream);
            }

            return true;
        }

        public Guid Add(string name, byte[] data)
        {
            Guid id = Guid.NewGuid();

            this.Add(new FileModel()
            {
                Id = id,
                Data = data,
                Name = name
            });

            return id;
        }

        public bool Exists(Guid id)
        {
            return this.storage.Exists(id.ToString());
        }

        public FileModel Find(string name)
        {
            LiteFileInfo<string> info = this
                .storage
                .Find(name)
                .FirstOrDefault();

            if (info == default) return default;

            return this.Get(Guid.Parse(info.Id));
        }

        public FileModel Get(Guid id)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (storage.Exists(id.ToString()))
                {

                    LiteFileInfo<string> info = this.storage.Download(id.ToString(), stream);

                    byte[] data = stream.ToArray();

                    data = this.compressor.DeflateDecompress(data);

                    return new FileModel()
                    {
                        Id = id,
                        Name = info.Filename,
                        Time = info.UploadDate,
                        Data = data
                    };
                }
                return null;
            }
        }

        public bool Remove(Guid id)
        {
            return this.storage.Delete(id.ToString());
        }

        public bool Save(Guid id, string path)
        {
            FileModel file = this.Get(id);

            File.WriteAllBytes(Path.Combine(path, file.Name), file.Data);

            return true;
        }

        public bool Save(Guid id, string path, string name)
        {
            FileModel file = this.Get(id);

            File.WriteAllBytes(Path.Combine(path, name), file.Data);

            return true;
        }

        public int Shrink()
        {
            return (int)this.lite.Rebuild();
        }

        public void Dispose()
        {
            this.lite.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
