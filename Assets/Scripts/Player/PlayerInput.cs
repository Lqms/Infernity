using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public static event UnityAction RightMouseButtonClicked;
    public static event UnityAction LeftMouseButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LeftMouseButtonClicked?.Invoke();

        if (Input.GetMouseButtonDown(1))
            RightMouseButtonClicked?.Invoke();
    }
}
