using UnityEngine;

public class background : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject Player;

    private void Start()
    {
        
    }

    private void Update()
    {
        speed = Player.GetComponent<Score>().speed_background;
        ApplyMovement();
    }
    void ApplyMovement()
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed, 0);
        if (gameObject.transform.position.x <= -23) gameObject.transform.position = new Vector3(26, 1.1f, 1);
    }
}
