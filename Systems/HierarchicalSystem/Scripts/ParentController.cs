using JorgeJGnz.MVC.Core;

namespace JorgeJGnz.MVC.System.Hierarchical
{
    // Controller
    public class ParentController : GlobalController
    {
        public ParentModel model;
        public ParentView view;

        private void Awake()
        {
            // Components connection
            view.viewModel = new ParentView.ParentViewModel(model);

            // Model hierarchy
            for (int i = 0; i < model.children.Length; i++)
            {
                model.children[i].parent = model;
            }

            model.view = view; // Optional

            // ...
        }

        private void Start()
        {
            // ...
        }

        // ...
    }
}
