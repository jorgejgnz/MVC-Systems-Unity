using JorgeJGnz.MVC.Core;
using UnityEngine;

namespace JorgeJGnz.MVC.System.Simple
{
    // Scene-specific model
    public class SimpleModel : GlobalModel
    {
        [HideInInspector]
        public SimpleView view; // Optional

        public SimpleAsset asset;

        public SimplePersistent persistent = new SimplePersistent();

        public float readonlyValue = 0.0f;
        public float modifiableValue = 0.0f;

        // Only known by Controller
        [Range(1,10)]
        public int apiCallEverySeconds = 2;

        [Header("Updated by Controller")]
        public string myIp;
    }

    // Persistent model: Persistent between scenes and launches
    public class SimplePersistent
    {
        // Private variables for hard coded default values
        string persistentValueKey = "key";
        int defaultValue = 0;

        // Properties
        public int persistentCounter
        {
            get {
                if (!PlayerPrefs.HasKey(persistentValueKey))
                    PlayerPrefs.SetInt(persistentValueKey, defaultValue);

                return PlayerPrefs.GetInt(persistentValueKey);
            }
            set { PlayerPrefs.SetInt(persistentValueKey, value); }
        }

        // ...
    }
}
