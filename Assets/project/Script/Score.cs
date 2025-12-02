using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
   public int score;
    public float speed_lave;
    public float speed_background;
   [SerializeField] public float cooldawn;
    bool can_move;
    bool can_spawn;

    private void Awake()
    {


        cooldawn = 4;
    }

    private void Start()
    {
        speed_background = -1;
        can_move = false;
        score = Mathf.Clamp(score, 0, 100);
        score = 0;
        speed_lave = -2;
    }


    private void Update()
    {
        AfficherScore();
        AugmentationDifficult();
    }

    public void AugmentationScore()
    {
        score++;
    }


    void AfficherScore()
    {
        scoreText.text = "score : " + score;
        
    }

    public void AugmentationDifficult()
    {
        if (score %5 == 0 && !can_move && score != 0 && !can_spawn)
        {
            can_spawn = true;
            can_move = true;
            StartCoroutine(antiSpeed());
        }
    }

    IEnumerator antiSpeed()
    {
        speed_lave -= 1f;
       if(speed_lave >-4) cooldawn -= 1;
        speed_background -= 0.25f;
        yield return new WaitForSeconds(1);
        can_move = false;
        can_spawn = false;
    }





    

}
