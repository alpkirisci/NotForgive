using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManualPlayerScript : MonoBehaviour
{
    AudioManager manager;
    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            manager.PlayMusic(manager.medusaTheme);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            manager.PlayMusic(manager.minotaurTheme);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            manager.PlayMusic(manager.goblinBossTheme);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            manager.PlayMusic(manager.snakeTheme);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            manager.PlayMusic(manager.goblinTheme);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
           manager.PlayMusic(manager.chillax);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            manager.PlayMusic(manager.menu);
        }
    }
}
