using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private float mouseSensitivity;

    //REFERENCES
    private Transform parent; 
   
    private void Start()
    {
        parent = transform.parent;//Player is the parent of Main camera
        Cursor.lockState = CursorLockMode.Locked; //Mouse cursor center e lock kore dibe when game is played
    }

    // Update is called once per frame
    private void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        parent.Rotate(Vector3.up, mouseX); 
    }
}
