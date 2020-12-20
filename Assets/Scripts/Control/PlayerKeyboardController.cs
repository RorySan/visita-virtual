using UnityEngine;

namespace VisitaVirtual.Control
{
    public class PlayerKeyboardController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 15;
        [SerializeField] private float rotationSpeed = 100;
        [SerializeField] private bool useMouseView;

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            transform.Translate(Vector3.forward * (vertical * movementSpeed * Time.deltaTime));
            if (useMouseView)  
                transform.Translate(Vector3.right*(horizontal * movementSpeed*Time.deltaTime));
            else 
                transform.Rotate(Vector3.up * (horizontal * rotationSpeed * Time.deltaTime));
        }        
    }
}