using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody Robot;
    private float speed = 8f;
    private float jumpForce = 7f;
    private float RotationSpeed = 30f;
    private float coinsColected;
    Vector3 respawnPoint;
    Vector3 respawnpointStage2 = new Vector3(0,2.91f,85);
    private float runingSpeed = 15f;
    private bool run = false;
    private float lives = 3f;
    private float timeToFinish = 90f;


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
        Timer();
    }

    void MovimientoJugador()

    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        Vector3 inputRobot = new Vector3(movX,0,movY);
        transform.Translate(inputRobot * speed * Time.deltaTime);
        //Rotacion
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));
        //Salto
        if(Input.GetButtonDown("Jump"))
        {
          Robot.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        }

        //Correr
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runingSpeed;
            run = true;
        }else
        {
            speed = 8f;
            run = false;
        }
        
    }

    void Respawn()
    {
        transform.position = respawnPoint;
        if(lives == 0f)
        {
            Debug.Log("¡¡¡YOU LOST!!!");
        }
    }

    void RespawnStage2()
    {
        transform.position = respawnpointStage2;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.tag == "Coin")
        {
            coinsColected++;
            Destroy(col.transform.gameObject);
        }
        if(col.transform.gameObject.tag == "Trampas")
        {
            lives--;
            Respawn();
        }
        if(col.transform.gameObject.tag == "Vacio")
        {
            lives--;
            Respawn();
        }
        if(col.transform.gameObject.tag == "Vacio2")
        {
            lives--;
            RespawnStage2();
        }
        if(col.transform.gameObject.tag == "Star")
        {
            Debug.Log("¡¡¡YOU WIN!!!");
            Destroy(col.transform.gameObject);
        }
    }
    void Timer()
    {
        timeToFinish -= Time.deltaTime;
        if(timeToFinish <= 0)
        {
            timeToFinish = 0;
            Debug.Log("¡¡¡YOU LOST!!!");
        }
    }

}
