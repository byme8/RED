using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RED.Entities
{
    public class Point : Entity
    {
        public bool Taken;

        public void Take()
        {
            this.Taken = true;
            this.StartCoroutine(this.Hide());
        }
    }
}
