using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAction : MonoBehaviour
{
    void Start()
    {
        AudioListener.volume = PlayerPrefs.HasKey("volume") ? PlayerPrefs.GetFloat("volume") : 1f;
    }

    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("level1");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
