using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver(){
        gameUI.SetActive(true);
    }

    public void quit(){
        Application.Quit();
    }

    public void restart(){
        SceneManager.LoadScene(0);
    }
}
