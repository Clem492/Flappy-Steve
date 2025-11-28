using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PV : MonoBehaviour
{
    [SerializeField] UnityEvent toucher;
    [SerializeField] GameObject coeurs;
    [SerializeField] GameObject coeurGauche;
    [SerializeField] GameObject coeurMillieu;
    [SerializeField] GameObject coeurDroite;

    [SerializeField] GameObject coeurBriser;
    [SerializeField] GameObject blood;
    [SerializeField] List<AudioClip> sound;
    [SerializeField] AudioSource dommageSound;
    [SerializeField] GameObject spawner;

    [SerializeField] RectTransform panel;
    [SerializeField] TextMeshProUGUI scoreGame;
    [SerializeField] TextMeshProUGUI scoreDeath;


    bool coeurGaucheActif;
    bool coeurMillieuActif;
    bool coeurDroiteActif;
    bool death;
    private void Start()
    {
        coeurGaucheActif = true;
        coeurMillieuActif = true;
        coeurDroiteActif = true;
        death = false;
        panel.gameObject.SetActive(false);
    }

    private void Update()
    {
       StartCoroutine(GameOver());
        HorsMap();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("lave"))
        {
            Destroy(collision.gameObject);
            GameReset();
            dommage();
            toucher.Invoke();
        }
    }

    void HorsMap()
    {
        if (gameObject.transform.position.y <= -4.5)
        {
            GameReset();
            gameObject.GetComponent<Animator>().SetTrigger("dommage");
            dommage();
            toucher.Invoke();
        }
        if (gameObject.transform.position.y >= 4.5)
        {
            GameReset();
            gameObject.GetComponent<Animator>().SetTrigger("dommage");
            dommage();
            toucher.Invoke();
        }
    }

    public void dommage()
    {
        if(coeurGaucheActif && coeurMillieuActif &&  coeurDroiteActif)
        {
            coeurDroiteActif = false;
            gameObject.GetComponent<Jump>().dommage = true;
            Instantiate(coeurBriser,new Vector3(-7.32f, 0.460000008f, 0), Quaternion.identity);
            coeurDroite.GetComponent<SpriteRenderer>().enabled = false;
            return;
        }
        if (coeurGaucheActif && coeurMillieuActif && !coeurDroiteActif)
        {
            coeurMillieuActif = false;
            gameObject.GetComponent<Jump>().dommage = true;
            Instantiate(coeurBriser, new Vector3(-7.32f, 0.460000008f, 0), Quaternion.identity);
            coeurMillieu.GetComponent<SpriteRenderer>().enabled = false;
            return;
        }
        if (coeurGaucheActif && !coeurMillieuActif && !coeurDroiteActif)
        {
            coeurGaucheActif = false;
            gameObject.GetComponent<Jump>().dommage = true;
            Instantiate(coeurBriser, new Vector3(-7.32f, 0.460000008f, 0), Quaternion.identity);
            coeurGauche.GetComponent<SpriteRenderer>().enabled = false;
            death = true;
            return;
        }
    }

    void GameReset()
    {
        
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().linearVelocityX = 0;
        gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
        gameObject.transform.position = new Vector3(-2.82999992f, 0.411622256f, 0);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); 
        StartCoroutine(VisuelPlayer());
    }

    IEnumerator VisuelPlayer()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Jump>().dommage = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        
    }

    IEnumerator GameOver()
    {
        if (!coeurGaucheActif && !coeurMillieuActif && !coeurDroiteActif)
        {
            if (death)
            {
                gameObject.GetComponent<Jump>().dommage = true;
                dommageSound.resource = sound[0];
                dommageSound.Play();
                //mise a jour du rigidbody pour ne pas que le joueur bouge
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                gameObject.GetComponent<Rigidbody2D>().linearVelocityX = 0;
                gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;

                //ici on détruit toutes les laves présent sur la scène
                Destroy(GameObject.FindWithTag("lave"));
                //désactive le spawner poour ne pas que de la lave réaparait
                spawner.gameObject.GetComponent<SpawnerObstacle>().restartScreen = true;

                //instantie le sange jour l'animation de mort 
                yield return new WaitForSeconds(1);
                gameObject.GetComponent<Animator>().SetTrigger("death");
                yield return new WaitForSeconds(0.5f);
                Instantiate(blood, gameObject.transform);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                scoreGame.gameObject.SetActive(false);
                death = false;
                yield return new WaitForSeconds(1);
                panel.gameObject.SetActive(true);
                
                scoreDeath.text = gameObject.GetComponent<Score>().scoreText.text;
            }
        }
        yield break;
    }

    public void Restart()
    {
        coeurGaucheActif = true;
        coeurMillieuActif = true;
        coeurDroiteActif = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        spawner.gameObject.GetComponent<SpawnerObstacle>().restartScreen = false;
        coeurDroite.GetComponent<SpriteRenderer>().enabled = true;
        coeurMillieu.GetComponent<SpriteRenderer>().enabled = true;
        coeurGauche.GetComponent<SpriteRenderer>().enabled = true;
        scoreGame.gameObject.SetActive(true);
        gameObject.GetComponent<Jump>().dommage = true;
        panel.gameObject.SetActive(false);
        StartCoroutine(relancerJeu());



    }
    IEnumerator relancerJeu()
    {
        gameObject.transform.position = new Vector3(-2.82999992f, 0.411622256f, 0);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.GetComponent<Score>().score = 0;
        yield return new WaitForSeconds(2);
        dommageSound.resource = sound[1];
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        gameObject.GetComponent<Jump>().dommage = false;
    }

    public void QuitterApplication()
    {
        Application.Quit();
    }

   

    
}
