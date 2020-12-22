using UnityEngine;

namespace VisitaVirtual.Control
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] protected float cameraHeight;

        public virtual void TeleportToPosition(Transform target)
        {
            var targetPosition = target.transform.position;
            var newPosition = new Vector3(targetPosition.x, cameraHeight, targetPosition.z);

            transform.position = newPosition;
        }
    }
}
