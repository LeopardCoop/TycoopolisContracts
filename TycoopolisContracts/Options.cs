using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TycoopolisContracts
{
    public class Options //contains all options
    {
        public String savePath;

        public Options Copy()
        {
            Options copy = new Options();
            copy.savePath = savePath;
            return copy;
        }
    }
}
