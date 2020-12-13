using UnityEngine;
public class MouseLook : MonoBehaviour
{
    private Vector2 rotation = new Vector2(0, 0);
    [SerializeField] private float speed = 3;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += Input.GetAxis("Mouse Y");
            transform.eulerAngles = (Vector2)rotation * speed;
        }
    }
}
