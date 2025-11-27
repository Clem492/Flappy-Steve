using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class XP : MonoBehaviour
{
    [SerializeField] UnityEvent xp;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("je suis bien passer par le passage a xp");
            xp.Invoke();

            collision.GetComponent<Score>().AugmentationScore();
            collision.GetComponent<Animator>().SetTrigger("xp");
        }
    }




}
