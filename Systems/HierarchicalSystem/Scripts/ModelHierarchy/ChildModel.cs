using JorgeJGnz.MVC.Core;
using UnityEngine;

namespace JorgeJGnz.MVC.System.Hierarchical
{
    // Scene-specific model
    public class ChildModel : GlobalModel
    {
        // Parent reference is set by parent controller
        [HideInInspector]
        public ParentModel parent;

        public int childValue = 0;
    }
}