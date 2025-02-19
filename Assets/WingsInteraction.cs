using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class WingsInteraction : MonoBehaviour
{
    public GameObject wingsInfoObject;
    private WebSocketManager webSocketManager;
    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        webSocketManager = FindObjectOfType<WebSocketManager>();
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        if (trackedImageManager != null)
        {
            trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }
    }

    private void OnDisable()
    {
        if (trackedImageManager != null)
        {
            trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            // Activate the wings information when the target image is detected
            wingsInfoObject.SetActive(true);

            // Send wings information to the engineer dashboard via WebSocket
            string message = "Wings maintenance information: " + wingsInfoObject.GetComponent<WingsInfo>().maintenanceInfo;
            StartCoroutine(webSocketManager.SendMessageToServer(message));
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            // Update the wings information based on the tracked image
            // ...
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            // Deactivate the wings information when the target image is lost
            wingsInfoObject.SetActive(false);
        }
    }
}