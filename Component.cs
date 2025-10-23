using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSharp;
internal class Component {
    public Component() { }

    public void print() => Console.WriteLine(this.GetType().Name);
}
