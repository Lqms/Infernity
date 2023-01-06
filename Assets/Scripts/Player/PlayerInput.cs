using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction RightMouseButtonClicked;
    public event UnityAction LeftMouseButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LeftMouseButtonClicked?.Invoke();

        if (Input.GetMouseButtonDown(1))
            RightMouseButtonClicked?.Invoke();
    }
}
