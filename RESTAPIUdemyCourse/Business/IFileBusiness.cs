using Microsoft.AspNetCore.Http;
using RESTAPIUdemyCourse.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTAPIUdemyCourse.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveManyFilesToDisk(IList<IFormFile> file);
    }
}
