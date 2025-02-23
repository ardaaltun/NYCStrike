using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shoot : MonoBehaviour
{
    public float gunRange;
    public int gunDamage;
    private float fireRate = 15f;
    private float readyToFire = 0f;
    int magazine = 510;
    int bulletInMagazine = 30;
    public bool reloading = false;
    public Transform rayOrigin;
    Animator animator;


    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private void Update() {

        if (Input.GetMouseButton(0) && Time.time >= readyToFire)
        {
            ShootGun();
            animator.SetTrigger("Fire");
        }
    }

    void ShootGun()
    {
        if (!reloading)
        {
            if (magazine > 0)
            {
                bulletInMagazine--;
                magazine--;
                readyToFire = Time.time + 1f / fireRate;
                RaycastHit hit;
                if (Physics.Raycast(rayOrigin.position, Camera.main.transform.forward, out hit, gunRange))
                {
                Debug.Log(hit.transform.name);

                    if (hit.transform.tag == "Killable")
                    {
                        Debug.Log("aaa");
                        hit.transform.GetComponent<ZombieController>().TakeDamage(gunDamage);
                    }
                        
                }
            }
            else if (Input.GetMouseButton(0) && Time.time >= readyToFire)
            {
                fireRate = 5f;
                bulletInMagazine = 0;
                readyToFire = Time.time + 1f / fireRate;
                // audio.PlayOneShot(empty);
            }
        }
    }

    // public void Reload()
    // {
    //     //print("reloading");
    //     GetComponent<AudioSource>().PlayOneShot(reload);
    //     reloading = true;
    // }

    // public void ResReload()
    // {
    //     reloading = false;
    // }
}
