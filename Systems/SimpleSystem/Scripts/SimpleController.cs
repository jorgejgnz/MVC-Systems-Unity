using JorgeJGnz.Helpers;
using JorgeJGnz.MVC.Core;
using UnityEngine;

namespace JorgeJGnz.MVC.System.Simple
{
    // Controller
    public class SimpleController : GlobalController
    {
        public SimpleModel model;
        public SimpleView view;

        bool waitingFlag = false;
        float timeSinceLastResponse = 0.0f;

        private void Awake()
        {
            // Components connection
            view.viewModel = new SimpleView.ViewModel(model);

            model.view = view; // Optional

            // Prevention of common errors
            if (!model) GetComponent<SimpleModel>();
            if (!view) GetComponent<SimpleView>();
        }

        private void Start()
        {
            // Listen to events invoked by this or other systemsz
            // ...

            // Update counter
            if (model.asset.resetCounterOnStart)
                model.persistent.persistentCounter = 0;
            else
                model.persistent.persistentCounter++;

            // API call in the first frame
            timeSinceLastResponse = model.apiCallEverySeconds;
        }

        private void Update()
        {
            if (!waitingFlag)
            {
                timeSinceLastResponse += Time.deltaTime;

                if (timeSinceLastResponse >= model.apiCallEverySeconds)
                {
                    waitingFlag = true;
                    UpdateMyIp();
                }
            }

            // ...
        }

        void UpdateMyIp()
        {
            StartCoroutine( 
                NetworkHelper.Get(model.asset.uri, new ApiResponse(), (response) => { OnResponse(response); })
            );
        }

        void OnResponse(ApiResponse response)
        {
            model.myIp = response.ip;

            Debug.Log("New API response: " + response.ip);
            view.onApiUpdate.Invoke(response.ip);

            timeSinceLastResponse = 0.0f;
            waitingFlag = false;
        }
    }
}
