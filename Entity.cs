using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSharp;
internal class Entity {
    private static UInt32 nextId;
    private readonly UInt32 id;

    public Entity() => this.id = nextId++;
    public UInt32 getId() => id;
}
