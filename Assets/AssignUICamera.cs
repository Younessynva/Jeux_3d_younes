using UnityEngine;

public class AssignUICamera : MonoBehaviour
{
    public Camera uiCamera; // La cam�ra UI que tu veux assigner

    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas != null && uiCamera != null)
        {
            canvas.worldCamera = uiCamera; // Assigner la cam�ra UI au Canvas
        }
    }
}