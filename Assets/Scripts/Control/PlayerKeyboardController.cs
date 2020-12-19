using UnityEngine;

namespace VisitaVirtual.Control
{
    public class PlayerKeyboardController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 15;
        [SerializeField] private float rotationSpeed = 100;

        private void Update()
        {
            float rotation = Input.GetAxis("Horizontal");
            float translation = Input.GetAxis("Vertical");
            
            //transform.Rotate(Vector3.up * (rotation * rotationSpeed * Time.deltaTime));
            transform.Translate(Vector3.forward * (translation * movementSpeed * Time.deltaTime));
            transform.Translate(Vector3.right*(rotation*movementSpeed*Time.deltaTime));
        }        
    }
}