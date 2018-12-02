using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MechanicsDAL
{
    interface SqlHelper<qualquerClasse>
    {
        void create(qualquerClasse obj);
        void delete(qualquerClasse obj);
        void update(qualquerClasse obj);
        bool find(qualquerClasse obj);
        List<qualquerClasse> FindAll();
    }
}
