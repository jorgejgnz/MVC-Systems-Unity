using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace JorgeJGnz.Helpers
{
    public static class NetworkHelper
    {
        public static IEnumerator Get<T>(string uri, T defaultErrorResponse, UnityAction<T> onResponse)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError)
                {
                    Debug.LogError("Network Error: " + webRequest.error);
                    onResponse.Invoke(defaultErrorResponse);
                }
                else
                {
                    string jsonResponse = webRequest.downloadHandler.text;
                    onResponse.Invoke(JsonUtility.FromJson<T>(jsonResponse));
                }
            }
        }
    }
}
