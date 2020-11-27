using JorgeJGnz.MVC.Core;
using UnityEngine;

namespace JorgeJGnz.MVC.System.Hierarchical
{
    // Scene-specific model
    public class ParentModel : GlobalModel
    {
        [HideInInspector]
        public ParentView view; // Optional

        public ParentAsset asset;

        public ParentPersistent persistent = new ParentPersistent();

        // ...

        public ChildModel[] children;
    }

    // Persistent model: Persistent between scenes and launches
    public class ParentPersistent
    {
        // ...
    }
}
