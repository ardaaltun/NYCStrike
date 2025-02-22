using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    public GameObject canvas;
    public GameObject video;
    public GameObject gameStart;

    AsyncOperation asyncOperation;
    // Start is called before the first frame update
    public void Play()
    {
        asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;
        video.SetActive(true);
        canvas.SetActive(false);
        Invoke("Activate", 5f);
    }


    public void Menu()
    {
        SceneManager.LoadScene(0);
    }    

    public void Quit()
    {
        Application.Quit();
    }

    public void Activate()
    {
        gameStart.SetActive(true);
    }

    public void LoadGame()
    {
        asyncOperation.allowSceneActivation = true;
        gameStart.SetActive(false);
    }
}
