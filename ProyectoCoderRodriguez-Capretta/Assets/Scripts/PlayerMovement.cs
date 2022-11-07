using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody Robot;
    public float speed = 8f;
    public float jumpForce = 1f;
    public float RotationSpeed = 1.0f;
    public float monedasRecolectadas;
    Vector3 respawnPoint;
    Vector3 respawnpointStage2 = new Vector3(0,2.91f,85);
    public float runingSpeed = 15f;
    public bool correr = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Robot = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
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
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runingSpeed;
            correr = true;
        }else
        {
            speed = 8f;
            correr = false;
        }
        
    }

    void Respawn()
    {
        transform.position = respawnPoint;
    }

    void RespawnStage2()
    {
        transform.position = respawnpointStage2;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.tag == "Coin")
        {
            monedasRecolectadas++;
            Destroy(col.transform.gameObject);
        }
        if(col.transform.gameObject.tag == "Trampas")
        {
            Respawn();
        }
        if(col.transform.gameObject.tag == "Vacio")
        {
            Respawn();
        }
        if(col.transform.gameObject.tag == "Vacio2")
        {
            RespawnStage2();
        }
    }
}
