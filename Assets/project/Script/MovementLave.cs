using UnityEngine;

public class MovementLave : MonoBehaviour
{
     float speed;

    private void Update()
    {
        speed = GameObject.FindWithTag("Player").GetComponent<Score>().speed_lave;
        ApplyMovement();
    }
    void ApplyMovement()
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed, 0);
        if (gameObject.transform.position.x <= -13) Destroy(gameObject);
        
    }
}
