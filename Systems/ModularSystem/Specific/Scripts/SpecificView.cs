using JorgeJGnz.MVC.Core;
using JorgeJGnz.MVC.Events;
using JorgeJGnz.MVC.System.Modular.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JorgeJGnz.MVC.System.Modular.Specific
{
    // Scene-specific model
    public class SpecificView : GlobalView
    {
        // ...

        // ViewModel
        public sealed class SpecificViewModel
        {
            SpecificModel model;

            // ...

            public GenericView generic { get { return model.generic.view; } }

            // Constructor
            public SpecificViewModel(SpecificModel model)
            {
                this.model = model;
            }
        }
        public SpecificViewModel viewModel;

        // ...
    }
}