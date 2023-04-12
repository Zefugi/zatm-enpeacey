using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zefugi;

public class ApiTest : MonoBehaviour
{
    private WebAPI _api;

    public void Start()
    {
        _api = new WebAPI()
        {
            ApiKey = "This is not an API key.",
            URL = "https://localhost:7296/api/Debug/Auth"
        };

        StartCoroutine(_api.CO_Get<Response>((r) =>
        {
            Debug.Log($"Received: {r.message}");
        }));
    }
}

public class Response
{
    public string message;
}
