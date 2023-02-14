using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _blockKey = KeyCode.Space;
    [SerializeField] private KeyCode _shoutKey = KeyCode.F;

    public static event UnityAction RightMouseButtonClicked;
    public static event UnityAction LeftMouseButtonClicked;
    public static event UnityAction ShoutKeyPressed;
    public static event UnityAction<KeyCode> BlockKeyPressed;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            LeftMouseButtonClicked?.Invoke();

        if (Input.GetMouseButton(1))
            RightMouseButtonClicked?.Invoke();

        if (Input.GetKeyDown(_blockKey))
            BlockKeyPressed?.Invoke(_blockKey);
        
        if (Input.GetKeyDown(_shoutKey))
            ShoutKeyPressed?.Invoke();


    }
}
