using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _blockKey = KeyCode.Space;

    public static event UnityAction RightMouseButtonClicking;
    public static event UnityAction LeftMouseButtonClicking;
    public static event UnityAction<KeyCode> BlockKeyPressed;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            LeftMouseButtonClicking?.Invoke();

        if (Input.GetMouseButton(1))
            RightMouseButtonClicking?.Invoke();

        if (Input.GetKeyDown(_blockKey))
            BlockKeyPressed?.Invoke(_blockKey);
    }
}
