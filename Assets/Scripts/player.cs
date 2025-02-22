using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Animator anim;
    public CharacterController playerController;
    public GameObject groundCheck;
    public float jumpForce = 10f;
    public float gravity = 10f;
    public float speed = 20f;
    public int health = 100;
    bool living = true;
    bool onceDied = false;
    bool onReload = false;

    void Update()
    {
        //print(gameObject.GetComponentInChildren<Cast>().reloading);
        if (health < 1 && living)
        {
            foreach(GameObject zombie in GameObject.FindGameObjectsWithTag("Killable"))
            {
                zombie.GetComponent<Animator>().enabled = false;
                zombie.GetComponent<NavMeshAgent>().enabled = false;
            }
            onceDied = true;
            health = 0;
            if(onceDied)
            {
                living = false;
                anim.SetTrigger("death");
                anim.SetBool("onceDied", true);
            }
        
        }
        Animations();
        if (living && !gameObject.GetComponentInChildren<Cast>().reloading)
        {
            //Animations();
            Movement();
        }
        if(gameObject.GetComponentInChildren<Cast>().reloading && !onReload)
        {
            anim.SetTrigger("reload");
            onReload = true;
            //anim.ResetTrigger("reload");
        }
    }
    

    void Animations()
    {
        
        if (Input.GetKeyDown("w") )
        {
            anim.SetBool("run", true);
        }
        if (Input.GetKeyDown("s"))
        {
            anim.SetBool("run_back", true);
        }
        if (Input.GetKeyDown("d"))
        {
            anim.SetBool("right", true);
        }
        if (Input.GetKeyDown("a"))
        {
            anim.SetBool("left", true);
        }
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("shoot",true);
        }
        

        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("run", false);
        }
        if (Input.GetKeyUp("s"))
        {
            anim.SetBool("run_back", false);
        }
        if (Input.GetKeyUp("d"))
        {
            anim.SetBool("right", false);
        }
        if (Input.GetKeyUp("a"))
        {
            anim.SetBool("left", false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("shoot",false);
        }

    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right.normalized * horizontal + transform.forward.normalized * vertical;
        playerController.Move(move * speed * Time.deltaTime);
    }

    void resetter()
    {
        Invoke("reseting", 2f);
    }

    void resetting()
    {
        anim.ResetTrigger("death");
    }

    public void ResetReload()
    {
        //print("player reset reload");
        gameObject.GetComponentInChildren<Cast>().ResReload();
        onReload = false;
       
    }
}
