using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSharp;
internal class EntityManager<E, C> where E : Entity where C : Component {
    private readonly Dictionary<E, List<C>> registry = new Dictionary<E, List<C>>();

    public EntityManager() { }

    public void AddComponent<CC>(E e) where CC : C, new() {
        if (!registry.TryGetValue(e, value: out var components)) {
            components = new List<C>(); registry[e] = components;
        }
        components.Add(new CC());
    }

    public CC? getComponent<CC>(E e) where CC : C, new() {
        if (registry.TryGetValue(e, value: out var components)) {
            var corresponding = components.OfType<CC>().FirstOrDefault();
            return corresponding;
        }
        return null;
    }

    public UInt32 countComponents(E e) => (UInt32)registry[e].Count();

    public Boolean hasComponents(E e) => registry[e].Count() is not 0;

    public List<string> getComponentNames(E e) {
        var names = new List<string>();
        registry[e].ForEach(obj => names.Add(obj.GetType().Name));
        return names;
    }
}
