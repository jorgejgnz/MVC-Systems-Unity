using JorgeJGnz.MVC.System.Simple;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using JorgeJGnz.Components;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace JorgeJGnz.Components
{
    // Scene-specific component
    public class CustomComponent : MonoBehaviour
    {
        public TextMeshPro tmpro;
        public MeshRenderer mr;

        // Start is called before the first frame update
        void Start()
        {
            SimpleView.singleton.onValueChange.AddListener(OnValuechange);
        }

        // Update is called once per frame
        void Update()
        {
            tmpro.text = "My IP: " + SimpleView.singleton.viewModel.myIp + "\n";
            tmpro.text += "Counter: " + SimpleView.singleton.viewModel.persistentCounter;
        }

        public void ModifyValue()
        {
            SimpleView.singleton.viewModel.modifiableValue = Random.Range(0.0f,1.0f);
        }

        void OnValuechange(float newValue)
        {
            mr.material.color = new Color(newValue, newValue, newValue);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(CustomComponent))]
public class CustomComponent_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CustomComponent myScript = (CustomComponent)target;
        if (GUILayout.Button("Modify Value"))
        {
            myScript.ModifyValue();
        }
    }
}
#endif
