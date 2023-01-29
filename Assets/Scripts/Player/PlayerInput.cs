using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _blockKey = KeyCode.Space;

    public static event UnityAction RightMouseButtonClicked;
    public static event UnityAction LeftMouseButtonClicked;
    public static event UnityAction<KeyCode> BlockKeyPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LeftMouseButtonClicked?.Invoke();

        if (Input.GetMouseButtonDown(1))
            RightMouseButtonClicked?.Invoke();

        if (Input.GetKeyDown(_blockKey))
            BlockKeyPressed?.Invoke(_blockKey);
    }
}
