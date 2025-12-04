using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class power : MonoBehaviour
{
    [SerializeField] GameObject PotionFull, PotionEmpty;
    [SerializeField] GameObject ParticuleSysteme;
    [SerializeField] Slider PotionTime;
    [SerializeField] float PotionSpeed = 5f;
    [SerializeField] float CooldownPotion;
    bool UsePotionSlider = false;
    bool CooldownVerif = false;

    private void Start()
    {
        ParticuleSysteme.SetActive(false);
        PotionFull.SetActive(true);
        PotionEmpty.SetActive(false);
        PotionTime.maxValue = PotionSpeed;
        PotionTime.value = PotionSpeed;
        PotionTime.gameObject.SetActive(false);
    }

    private void Update()
    {
        UsePotion();
    }

    void UsePotion()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !UsePotionSlider && !CooldownVerif && !gameObject.GetComponent<PV>().PanelActive)
        {

            UsePotionSlider = true;
            ParticuleSysteme.SetActive(true);
            PotionTime.gameObject.SetActive(true);
            
        }

        if (gameObject.GetComponent<PV>().PanelActive)
        {
            UsePotionSlider = false;
            EnableAllObstacles();
            ParticuleSysteme.SetActive(false);
            PotionTime.gameObject.SetActive(false);
            PotionTime.value = PotionSpeed;
            PotionFull.SetActive(false);
            PotionEmpty.SetActive(false);
            CooldownVerif = true;
            StartCoroutine(Cooldown());
        }

        else if (UsePotionSlider)
        {
            DisableAllObstacles();
            PotionTime.value -= Time.deltaTime;

            if (PotionTime.value <= 0)
            {
                UsePotionSlider = false;
                EnableAllObstacles();
                ParticuleSysteme.SetActive(false);
                PotionTime.gameObject.SetActive(false);
                PotionTime.value = PotionSpeed;
                PotionFull.SetActive(false);
                PotionEmpty.SetActive(true);
                CooldownVerif = true;
                StartCoroutine(Cooldown());
                
            }
        }
    }



IEnumerator Cooldown()
    {
        if (gameObject.GetComponent<PV>().PanelActive)
        {
            CooldownVerif = false;
            PotionFull.SetActive(false);
            PotionEmpty.SetActive(false);
            yield break;
        }
        
        yield return new WaitForSeconds(CooldownPotion);
        CooldownVerif = false;
        PotionFull.SetActive(true);
        PotionEmpty.SetActive(false);
        
    }

    void DisableAllObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (GameObject obs in obstacles)
        {
            obs.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void EnableAllObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (GameObject obs in obstacles)
        {
            obs.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}