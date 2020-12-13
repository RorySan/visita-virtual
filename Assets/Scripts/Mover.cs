using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    [SerializeField] private float cameraHeight;
    [SerializeField] private UnityEvent onMovement;
    

    public void MoveToPosition(Transform target)
    {
        var targetPosition = target.transform.position;
        var newPosition = new Vector3(targetPosition.x, cameraHeight, targetPosition.z);

        transform.position = newPosition;
        onMovement.Invoke();
    }


}
