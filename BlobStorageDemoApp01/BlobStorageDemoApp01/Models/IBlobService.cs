using System;
namespace BlobStorageDemoApp01.Models
{
    public interface IBlobService
    {

        //To be implemented to show all blobs
        Task<IEnumerable<string>> AllBlobs(string containerName);

        //To be implemented to get specified blob
        Task<string> GetBlob(string name, string containerName);

        //To be implemented to upload a blob from local computer
        Task<bool> UploadBlob(string name, IFormFile file, string containerName);

        //To be implemented to delete the selected blob
        Task<bool> DeleteBlob(string name, string containerName);
    }
}

