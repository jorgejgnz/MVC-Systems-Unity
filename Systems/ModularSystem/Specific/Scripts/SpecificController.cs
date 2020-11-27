using JorgeJGnz.MVC.Core;
using UnityEngine;

namespace JorgeJGnz.MVC.System.Modular.Specific
{
    // Controller
    public class SpecificController : GlobalController
    {
        public SpecificModel model;
        public SpecificView view;

        private void Awake()
        {
            // Components connection
            view.viewModel = new SpecificView.SpecificViewModel(model);

            model.view = view; // Optional

            // If specific system (module)
            model.generic.registry.Add(view);

            // ...
        }

        private void Start()
        {
            // Listen to events invoked by other systems

            // ...
        }

        // ...
    }
}
