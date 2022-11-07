using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionJugador : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("caminando", true);
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("caminando", false);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("caminando", true);
        }

        if(Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("caminando", false);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("caminando", true);
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("caminando", false);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("caminando", true);
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("caminando", false);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("corriendo", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("corriendo", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("saltar", true);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("saltar", false);
        }
    }


}
