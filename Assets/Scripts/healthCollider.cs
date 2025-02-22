using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCollider : MonoBehaviour
{
    public GameObject zombie;

    private void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), zombie.GetComponent<CapsuleCollider>());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject settings = GameObject.FindGameObjectWithTag("GameController");
            settings.GetComponent<GameSettings>().collected++;

            Destroy(gameObject);
        }
    }
}
