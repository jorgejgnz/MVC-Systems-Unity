using JorgeJGnz.MVC.Core;
using System.Collections.Generic;

namespace JorgeJGnz.MVC.System.Hierarchical
{
    // Scene-specific model
    public class ParentView : GlobalView
    {
        // ...

        // ViewModel
        public sealed class ParentViewModel
        {
            ParentModel model;

            // ...

            ChildViewModel _firstChild;
            public ChildViewModel firstChild
            {
                get
                {
                    if (_firstChild == null && model.children.Length > 0) _firstChild = new ChildViewModel(model.children[0]);
                    return _firstChild;
                }
            }

            ChildViewModel[] _children;
            public ChildViewModel[] children
            {
                get
                {
                    if (_children == null) _children = GetChildViewModelsArray();
                    return _children;
                }
            }

            // Constructor
            public ParentViewModel(ParentModel model)
            {
                this.model = model;
            }

            // ChildViewModel instantiations
            ChildViewModel[] GetChildViewModelsArray()
            {
                List<ChildViewModel> childrenViewModelsList = new List<ChildViewModel>();

                for (int i = 0; i < model.children.Length; i++)
                {
                    // Child view models that are already referenced in the view model shouldn't be created again
                    if (model.children[i] == model.children[0])
                        childrenViewModelsList.Add(firstChild);

                    // Child view models that only accessible thorugh the array of children are should be instantiated here
                    else if (model.children[i] != null)
                        childrenViewModelsList.Add(new ChildViewModel(model.children[i]));
                }

                return childrenViewModelsList.ToArray();
            }
        }
        public ParentViewModel viewModel;

        public sealed class ChildViewModel
        {
            ChildModel model;

            // Properties
            public int childValue { get { return model.childValue; } }

            // Constructor
            public ChildViewModel(ChildModel model)
            {
                this.model = model;
            }
        }

        // ...
    }
}