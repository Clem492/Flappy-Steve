using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
   public int score;

    private void Start()
    {
        score = Mathf.Clamp(score, 0, 100);
        score = 0;
    }


    private void Update()
    {
        AfficherScore();
    }

    public void AugmentationScore()
    {
        score++;
    }


    void AfficherScore()
    {
        scoreText.text = "score : " + score;
    }
}
