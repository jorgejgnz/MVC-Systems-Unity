using JorgeJGnz.MVC.Core;
using UnityEngine;

namespace JorgeJGnz.MVC.System.Modular.Generic
{
    // Controller
    public class GenericController : GlobalController
    {
        public GenericModel model;
        public GenericView view;

        private void Awake()
        {
            // Components connection
            view.viewModel = new GenericView.GenericViewModel(model);

            model.view = view;

            // ...
        }

        private void Start()
        {
            // ...
        }

        // ...
    }
}
