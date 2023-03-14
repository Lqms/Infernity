using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reflecto_PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _rotateLeftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode _rotateRightKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode _rotateUpKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode _rotateDownKey = KeyCode.DownArrow;

    private Vector3 _rotateUp;
    private Vector3 _rotateRight;
    private Vector3 _rotateDown;
    private Vector3 _rotateLeft;

    public event UnityAction<Vector3> RotateKeyPressed;

    private const float RotateUpDirectionY = 0;
    private const float RotateRightDirectionY = 90;
    private const float RotateDownDirectionY = 180;
    private const float RotateLeftDirectionY = 270;

    private void Start()
    {
         _rotateUp = new Vector3(0, RotateUpDirectionY, 0);
         _rotateRight = new Vector3(0, RotateRightDirectionY, 0);
         _rotateDown = new Vector3(0, RotateDownDirectionY, 0);
         _rotateLeft = new Vector3(0, RotateLeftDirectionY, 0);
    }   

    private void Update()
    {
        if (Input.GetKeyDown(_rotateUpKey))
            RotateKeyPressed?.Invoke(_rotateUp);

        if (Input.GetKeyDown(_rotateRightKey))
            RotateKeyPressed?.Invoke(_rotateRight);

        if (Input.GetKeyDown(_rotateDownKey))
            RotateKeyPressed?.Invoke(_rotateDown);

        if (Input.GetKeyDown(_rotateLeftKey))
            RotateKeyPressed?.Invoke(_rotateLeft);
    }
}
