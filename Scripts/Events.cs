using System;
using UnityEngine.Events;

namespace JorgeJGnz.MVC.Events
{
    // Custom events

    [Serializable]
    public class FloatEvent : UnityEvent<float> { }

    [Serializable]
    public class StringEvent : UnityEvent<string> { }

    // ...
}
