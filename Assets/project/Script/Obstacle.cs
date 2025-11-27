using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AudioSource))]
public class Obstacle : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("dommage");
            
        }
        
    }
}
