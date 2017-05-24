using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RED.Utils
{
    public class Singletone<TValue>
        where TValue : new()
    {
        public readonly static TValue Instance;

        static Singletone()
        {
            Instance = new TValue();
        }
    }
}
