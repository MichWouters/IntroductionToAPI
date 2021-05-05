using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.MakingAPoint
{
    public class MainClass: IMainClass
    {
        private IRequiredClassA _a;
        private IRequiredClassB _b;

        public MainClass(IRequiredClassA a, IRequiredClassB b)
        {
            _a = a;
            _b = b;
        }
    }

    public interface IMainClass
    {

    }
}
