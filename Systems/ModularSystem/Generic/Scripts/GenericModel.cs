using JorgeJGnz.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace JorgeJGnz.MVC.System.Modular.Generic
{
    // Scene-specific model
    public class GenericModel : GlobalModel
    {
        [HideInInspector]
        public GenericView view; // Returned by SpecificViewModel

        public GenericAsset asset;

        public GenericPersistent persistent = new GenericPersistent();

        // ...

        // If other systems can be connected as modules
        public List<GlobalView> registry = new List<GlobalView>();
    }

    // Persistent model: Persistent between scenes and launches
    public class GenericPersistent
    {
        // ...
    }
}
