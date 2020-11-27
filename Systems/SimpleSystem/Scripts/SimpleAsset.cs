using UnityEngine;

namespace JorgeJGnz.MVC.System.Simple
{
    // Configuration model: Can be shared between models. Cannot be modified in build
    [CreateAssetMenu(menuName = "JorgeJGnz/Simple Asset", order = 1)]
    public class SimpleAsset : ScriptableObject
    {
        // ScriptableObjects should contain at least one variable
        public int configurationValue = 0;

        // ...

        [Header("Only accessible by Controller")]
        public string uri;
        public bool resetCounterOnStart = false;

        // ...
    }
}