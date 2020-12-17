using System;
using UnityEngine;
using UnityEngine.XR.Management;

namespace VisitaVirtual.Control
{
    public class MouseLook : MonoBehaviour
    {
        // Configuration Options
        [SerializeField] private float mouseSensitivity = 200;
        [SerializeField] private bool InvertMouse = true;

        // Cached References
        [SerializeField] private Transform playerBody;

        private float xRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (!Input.GetKey(KeyCode.Mouse0)) return;
            
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            if (InvertMouse) xRotation += mouseY;
            else xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}