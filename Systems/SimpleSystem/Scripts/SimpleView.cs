using JorgeJGnz.MVC.Core;
using JorgeJGnz.MVC.Events;
using UnityEngine;
using UnityEngine.Events;

namespace JorgeJGnz.MVC.System.Simple
{
    // Scene-specific model
    public class SimpleView : GlobalView
    {
        // Singleton
        static SimpleView _singleton;
        public static SimpleView singleton
        {
            get
            {
                if (_singleton == null)
                    _singleton = GameObject.FindObjectOfType<SimpleView>();

                return _singleton;
            }
        }

        // ViewModel
        public sealed class ViewModel
        {
            SimpleModel model;

            // Properties
            public int persistentCounter { get { return model.persistent.persistentCounter; } }
            public int configurationValue { get { return model.asset.configurationValue; } }
            public float readonlyValue { get { return model.readonlyValue; } }
            public float modifiableValue
            {
                get { return model.modifiableValue; }
                set
                {
                    model.modifiableValue = value;
                    model.view.onValueChange.Invoke(value);
                }
            }

            public string myIp { get { return model.myIp; } }

            // Constructor
            public ViewModel(SimpleModel model)
            {
                this.model = model;
            }
        }
        public ViewModel viewModel;

        // Events
        public StringEvent onApiUpdate = new StringEvent();
        public FloatEvent onValueChange = new FloatEvent();
        public UnityEvent onOtherEvent = new UnityEvent();
    }
}