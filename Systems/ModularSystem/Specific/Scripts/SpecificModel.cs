using JorgeJGnz.MVC.Core;
using JorgeJGnz.MVC.System.Modular.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace JorgeJGnz.MVC.System.Modular.Specific
{
    // Scene-specific model
    public class SpecificModel : GlobalModel
    {
        [HideInInspector]
        public SpecificView view; // Optional

        public SpecificAsset asset;

        public SpecificPersistent persistent = new SpecificPersistent();

        // ...

        // If it's connected to another system as a module
        public GenericModel generic;
    }

    // Persistent model: Persistent between scenes and launches
    public class SpecificPersistent
    {
        // ...
    }
}
