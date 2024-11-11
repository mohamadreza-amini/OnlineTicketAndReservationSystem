using Infrastructure.RepositoryInterfaces;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses;

public class BlobService: IBlobService
{
    private readonly IBaseRepository<Blob, int> baseRepository;

    public BlobService(IBaseRepository<Blob, int> baseRepository)
    {
        this.baseRepository = baseRepository;
    }

    public async Task<bool> Create(Blob blob)
    {
        if (blob.FileAddress != null && blob.MimeType != null && blob.FileSize > 0)
        {
            await baseRepository.CreateDataAsync(blob);
            return true;
        }
        return false;
    }
}
