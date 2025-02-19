using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WebSocketManager : MonoBehaviour
{
    private string webSocketUrl = "ws://10.76.79.220";
    private UnityWebRequest webSocketRequest;

    private void Start()
    {
        StartCoroutine(ConnectToServer());
    }

    private IEnumerator ConnectToServer()
    {
        webSocketRequest = new UnityWebRequest(webSocketUrl, "GET");
        webSocketRequest.downloadHandler = new DownloadHandlerBuffer();
        webSocketRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webSocketRequest.SendWebRequest();

        if (webSocketRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("WebSocket connection established.");
            // Start receiving messages from the server
            StartCoroutine(ReceiveMessages());
        }
        else
        {
            Debug.Log("WebSocket connection failed: " + webSocketRequest.error);
        }
    }

    private IEnumerator ReceiveMessages()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (webSocketRequest != null && webSocketRequest.downloadHandler != null)
            {
                string message = webSocketRequest.downloadHandler.text;
                if (!string.IsNullOrEmpty(message))
                {
                    Debug.Log("Received message from server: " + message);
                    // Process the received message here
                }
            }
        }
    }

    public IEnumerator SendMessageToServer(string message)
    {
        if (webSocketRequest != null && webSocketRequest.uploadHandler != null)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            webSocketRequest.uploadHandler = new UploadHandlerRaw(data);
            yield return webSocketRequest.SendWebRequest();
        }
    }

    private void OnDestroy()
    {
        if (webSocketRequest != null)
        {
            webSocketRequest.Abort();
            webSocketRequest.Dispose();
        }
    }
}