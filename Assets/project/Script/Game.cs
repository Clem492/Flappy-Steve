using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("tuto");
    }

    public void exit()
    {
        Application.Quit();
    }
}
