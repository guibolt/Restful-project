using RestApp.Data.VO;
using RestApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Business
{
    public interface IFileBusiness
    {
        byte [] GetPDFFile();
    }
}
