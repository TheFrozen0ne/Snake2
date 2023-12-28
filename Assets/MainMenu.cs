using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSoundEffect;
    public void PlayGame()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        buttonSoundEffect.Play();
        Application.Quit();
    }

}