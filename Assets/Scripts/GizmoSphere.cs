using UnityEngine;

public class GizmoSphere : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
