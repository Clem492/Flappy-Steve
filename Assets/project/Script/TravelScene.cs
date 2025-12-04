
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelScene : MonoBehaviour
{
    [SerializeField] float waitTime;
    float timer;
    private void Start()
    {
        timer = waitTime;
    }

    private void Update()
    {
        Travel();
    }

    void Travel()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
