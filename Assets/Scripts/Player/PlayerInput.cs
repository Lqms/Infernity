using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _blockKey = KeyCode.Space;

    public static event UnityAction RightMouseButtonClick���;
    public static event UnityAction LeftMouseButtonClicked;
    public static event UnityAction<KeyCode> BlockKeyPressed;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            LeftMouseButtonClicked?.Invoke();

        if (Input.GetMouseButton(1))
            RightMouseButtonClick���?.Invoke();

        if (Input.GetKeyDown(_blockKey))
            BlockKeyPressed?.Invoke(_blockKey);
    }
}
