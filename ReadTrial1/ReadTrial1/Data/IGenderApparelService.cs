using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadTrial1.Data
{
    public interface IGenderApparelService
    {
        Task<GenderApparel[]> GetProductByGenderId();
    }
}
