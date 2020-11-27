using JorgeJGnz.MVC.Core;
using JorgeJGnz.MVC.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JorgeJGnz.MVC.System.Modular.Generic
{
    // Scene-specific model
    public class GenericView : GlobalView
    {
        // ...

        // ViewModel
        public sealed class GenericViewModel
        {
            GenericModel model;

            // ...

            public GlobalView[] registry { get { return model.registry.ToArray(); } }

            // Constructor
            public GenericViewModel(GenericModel model)
            {
                this.model = model;
            }

            // ...
        }
        public GenericViewModel viewModel;

        // ...
    }
}