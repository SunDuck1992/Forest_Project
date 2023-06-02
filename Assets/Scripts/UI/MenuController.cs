using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("Camp");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void MainMenuPressed()
    {
        DontDestroy obj = FindObjectOfType<Sound>().GetComponent<DontDestroy>();
        obj.DestroyObject();
        SceneManager.LoadScene("Menu");
    }

    public void OpenMenu(GameObject image)
    {
        image.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu(GameObject image)
    {
        image.SetActive(false);
        Time.timeScale = 1;
    }

    public void Reset()
    {
        SceneManager.LoadScene("Menu");
    }
}
