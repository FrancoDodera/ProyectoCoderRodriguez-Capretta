using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody Robot;
    public float speed = 1f;
    public float jumpForce = 1f;
    public float RotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Robot = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJugador();
    }

    void MovimientoJugador()

    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        Vector3 inputRobot = new Vector3(movX,0,movY);
        transform.Translate(inputRobot * speed * Time.deltaTime);

        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));

        if(Input.GetKeyDown(KeyCode.Space))
        {
          Robot.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        }
    }


}
