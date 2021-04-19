using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxController : MonoBehaviour
{
    AudioSource audio;
    public AudioClip born;
    public AudioClip died;
    public AudioClip attack;
    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.PlayOneShot(born);
    }

    public void Died()
    {
        audio.PlayOneShot(died);
    }
    public void Attack()
    {
        audio.PlayOneShot(attack);
    }
}
