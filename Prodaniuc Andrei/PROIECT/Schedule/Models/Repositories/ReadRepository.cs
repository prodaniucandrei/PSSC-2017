using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO_s;
using Models.DataAccessLayer;

namespace Models.Repositories
{
    public class ReadRepository
    {
        public UserLogged LogareUtilizator(UtilizatorDto utilizatorDto)
        {
            var dal = new Dal();
            return dal.LogareUtilizator(utilizatorDto);
        }
    }
}
