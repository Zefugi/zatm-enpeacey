using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Zefugi
{
    public class WebAPI
    {
        [System.Serializable]
        public class RequestData
        {
            public string param1;
            public int param2;
        }

        [System.Serializable]
        public class ResponseData
        {
            public string result;
            public int status;
        }

        public string URL { get; set; }
        public string ApiKey { get;  set; }

        public IEnumerator CO_Get<U>(System.Action<U> callback) where U : new()
        {
            UnityWebRequest www = UnityWebRequest.Get(URL);
            www.SetRequestHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(ApiKey))
                www.SetRequestHeader("X-API-Key", ApiKey);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                U responseData = JsonUtility.FromJson<U>(www.downloadHandler.text);
                callback(responseData);
            }
        }

        public IEnumerator CO_Get(Type responseType, System.Action<object> callback)
        {
            UnityWebRequest www = UnityWebRequest.Get(URL);
            www.SetRequestHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(ApiKey))
                www.SetRequestHeader("X-API-Key", ApiKey);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                object responseData = JsonUtility.FromJson(www.downloadHandler.text, responseType);
                callback(responseData);
            }
        }

        public IEnumerator CO_Post<T, U>(T requestData, System.Action<U> callback) where U : new()
        {
            string json = JsonUtility.ToJson(requestData);
            UnityWebRequest www = UnityWebRequest.Put(URL, json);
            www.method = UnityWebRequest.kHttpVerbPOST;
            www.SetRequestHeader("Content-Type", "application/json");
            if(!string.IsNullOrEmpty(ApiKey))
                www.SetRequestHeader("X-API-Key", ApiKey);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                U responseData = JsonUtility.FromJson<U>(www.downloadHandler.text);
                callback(responseData);
            }
        }

        public IEnumerator CO_Post(object requestData, Type responseType, System.Action<object> callback)
        {
            string json = JsonUtility.ToJson(requestData);
            UnityWebRequest www = UnityWebRequest.Put(URL, json);
            www.method = UnityWebRequest.kHttpVerbPOST;
            www.SetRequestHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(ApiKey))
                www.SetRequestHeader("X-API-Key", ApiKey);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                object responseData = JsonUtility.FromJson(www.downloadHandler.text, responseType);
                callback(responseData);
            }
        }
    }
}
