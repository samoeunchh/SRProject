using SRProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRProject.Services
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetBrands();
        Task<Brand> GetBrand(Guid id);
        Task<bool> Save(Brand brand);
        Task<bool> Update(Brand brand);
        Task<bool> Delete(Guid id);
    }
}
