using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Cast : MonoBehaviour
{
    private float weaponRange = 50f;
    public Camera fps;
    public GameObject gunEnd;
    Vector3 rayOrigin;
    Vector3 line;
    Vector3 linePos;
    public Text magazineText;
    public Text bulletText;
    private new AudioSource audio;
    public AudioClip shoot;
    public AudioClip reload;
    public AudioClip empty;
    public ParticleSystem muzzle; 
    private float fireRate = 15f;
    private float readyToFire = 0f;
    int magazine = 510;
    int bulletInMagazine = 30;
    public bool reloading = false;
    // Start is called before the first frame update
    void Start()
    {
        //fps = GetComponentInParent<Camera>();
        transform.localPosition = new Vector3(-0.4584372f, -0.67483f, -0.2422944f);
        transform.localEulerAngles = new Vector3(-59.647f, 76.55601f, 112.089f);
        audio = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (magazine < 0)
        {
            fireRate = 5f;
            bulletInMagazine = 0;
        }
         else
        */
            bulletText.text = bulletInMagazine.ToString();
        magazineText.text = magazine.ToString("/000");

        if(bulletInMagazine < 0 || bulletInMagazine == 0)
        {
            if(magazine > 0)
            {
                bulletInMagazine = 30;
                Reload();
                
                
            }
                

        }
        if (Input.GetMouseButton(0) && Time.time >= readyToFire)
        {
            Shoot();
            
        }
        
        /*
        
        if(Input.GetMouseButtonDown(1))
        {
            rayOrigin = fps.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

        }
        if (Input.GetMouseButtonUp(1))
        {
            rayOrigin = fps.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 3f));
        }
        
        
        line = fps.ViewportToWorldPoint(new Vector3(0f,0f,0f));
        Debug.DrawRay(line, fps.transform.forward * weaponRange, Color.green);
        */
    }

    void Shoot()
    {
        if (!reloading)
        {
            if (magazine > 0)
            {
                bulletInMagazine--;
                magazine--;
                readyToFire = Time.time + 1f / fireRate;
                audio.PlayOneShot(shoot);
                muzzle.Play();
                //muzzle.Stop();
                rayOrigin = fps.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 2f));

                RaycastHit hit;
                if (Physics.Raycast(rayOrigin, fps.transform.forward, out hit, weaponRange))
                {
                    if (hit.transform.tag == "Killable" && Input.GetMouseButton(0))
                    {
                        //Destroy(hit.transform.gameObject);
                        //print(hit.transform.name);
                        hit.transform.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                        hit.transform.gameObject.GetComponent<Animator>().SetTrigger("died");
                        hit.transform.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                        hit.transform.gameObject.GetComponent<sfxController>().Died();
                       
                    }

                }
            }
            else if (Input.GetMouseButton(0) && Time.time >= readyToFire)
            {
                //print("empty");
                fireRate = 5f;
                bulletInMagazine = 0;
                readyToFire = Time.time + 1f / fireRate;
                audio.PlayOneShot(empty);
            }
        }
        
        
    }
    public void Reload()
    {
        //print("reloading");
        audio.PlayOneShot(reload);
        reloading = true;
    }

    public void ResReload()
    {
        reloading = false;
    }
}
