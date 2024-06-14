using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
        GameController.gc.lives = 3;
        GameController.gc.Star = 0;
        GameController.gc.Rings = 0;
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
