using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float cameraHeight;

    public void MoveToPosition(Transform target)
    {
        var targetPosition = target.transform.position;
        var newPosition = new Vector3(targetPosition.x, cameraHeight, targetPosition.z);

        transform.position = newPosition;
    }


}
