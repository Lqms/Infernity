using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class PlayerInteractHandler : MonoBehaviour
{
    private IInteractable _closestInteractableObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactableObject))
        {
            _closestInteractableObject = interactableObject;
            PlayerInput.InteractKeyPressed += OnInteractKeyPressed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactableObject))
        {
            _closestInteractableObject = null;
            PlayerInput.InteractKeyPressed -= OnInteractKeyPressed;
        }
    }

    private void OnInteractKeyPressed()
    {
        if (_closestInteractableObject != null)
            _closestInteractableObject.Use();
    }
}
