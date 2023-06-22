using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MainModel
{
    public interface IModelElement
    {
        Dictionary<string, string> GetProperties();
    }
}
