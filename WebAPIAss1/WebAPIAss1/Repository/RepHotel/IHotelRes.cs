using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIAss1.Models;

namespace WebAPIAss1.Repository.RepHotel
{
    public interface IHotelRes
    {
        List<HotelModel> getAll();
        bool PostData(HotelModel newentry);
        bool DeleteData(int reservID);
        bool UpdatedData(HotelModel updateEntry);
    }
}
