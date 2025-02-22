using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Text healthText;
    public Text collectedText;
    public GameObject player;
    public GameObject health;
    public int collected = 0;
    public bool gaming = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        
        healthText.text = player.GetComponent<player>().health.ToString();
        collectedText.text = collected.ToString();
        if(player.GetComponent<player>().health < 1 && gaming)
        {

            gaming = false;
            Invoke("CallGameEnd", 3f);
        }

        if(collected == 6)
        {
            //you found a cure for corona animation will be played
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(3);
        }
    }

    void CallGameEnd()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    
        SceneManager.LoadScene(2);
    }
}
