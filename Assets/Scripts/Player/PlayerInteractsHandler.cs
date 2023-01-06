using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractsHandler : MonoBehaviour
{
    private IInteractable _currentInteractableObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactableObject))
        {
            if (interactableObject == _currentInteractableObject)
            {
                _currentInteractableObject.Use();
            }
        }
    }

    public void SetNewInteractableObject(IInteractable interactableObject)
    {
        _currentInteractableObject = interactableObject;
    }
}
