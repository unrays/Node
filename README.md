# Node
A lightweight, modular ECS for fast prototyping in C#.

I think you're starting to understand that I have a little obsession with ECS systems :) Sorry to have to tell you this but this is certainly not my last project on this subject. This project is much more about the architectural approach than the syntax and tryhard logic as I have already done in c++ before. The syntax and the very satisfying nature of C# made it easier and better the effort made, imagine that I coded this in about 1 hour without encountering a single compilation error, it's at least 5x less than in c++, without even talking about errors and syntax! Well, I think I've talked enough, you get the point, I really like ecs and now that I'm starting to tame it properly, I think I'll be able to start experimenting on patterns and alternative architectures to this one in order to explore a little what this modularity can offer me.

```csharp
// Copyright (c) October 2025 Félix-Olivier Dumas. All rights reserved.
// Licensed under the terms described in the LICENSE file

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

class Entity {
    private static UInt32 nextId;
    private readonly UInt32 id;

    public Entity() => this.id = nextId++;
    public UInt32 getId() => id;
}

class Component {
    public Component() { }

    public void print() => Console.WriteLine(this.GetType().Name);
}

class Movement : Component {
    public float SpeedX { get; set; }
    public float SpeedY { get; set; }
    public (float X, float Y) Direction { get; set; } = (0, 0);

    public void SetDirection(float x, float y) {
        var length = MathF.Sqrt(x * x + y * y);
        Direction = length == 0 ? (0, 0) : (x / length, y / length);
    }
}

class Name : Component {
    public string? name { get; set; }
}

class EntityManager<E, C> where E : Entity where C : Component {
    private readonly Dictionary<E, List<C>> registry = new Dictionary<E, List<C>>();

    public EntityManager() { }

    public void AddComponent<CC>(E e) where CC : C, new() {
        if (!registry.TryGetValue(e, value: out var components)) {
            components = new List<C>(); registry[e] = components;
        } components.Add(new CC());
    }

    public CC? getComponent<CC>(E e) where CC : C, new() {
        if (registry.TryGetValue(e, value: out var components)) {
            var corresponding = components.OfType<CC>().FirstOrDefault();
            return corresponding;
        } return null;
    }

    public UInt32 countComponents(E e) => (UInt32)registry[e].Count();

    public Boolean hasComponents(E e) => registry[e].Count() is not 0;

    public List<string> getComponentNames(E e) {
        var names = new List<string>();
        registry[e].ForEach(obj => names.Add(obj.GetType().Name));
        return names;
    }
}

class Program {
    static void Main(string[] args) {
        var em = new EntityManager<Entity, Component>();
        var cat = new Entity();

        em.AddComponent<Movement>(cat);
        em.AddComponent<Name>(cat);

        var name = em.getComponent<Name>(cat);
        name!.name = "Garfield";

        var movement = em.getComponent<Movement>(cat);

        em.getComponentNames(cat).ForEach(c => Console.WriteLine("Component: " + c));
        Console.WriteLine("Name: " + name.name);

        var dog = new Entity();
    }
}
```
