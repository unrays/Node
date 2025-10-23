// Copyright (c) October 2025 Félix-Olivier Dumas. All rights reserved.
// Licensed under the terms described in the LICENSE file

using ECSharp;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

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