using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public interface ISubScriber
    {
        void Notify(string message);
    }
}
