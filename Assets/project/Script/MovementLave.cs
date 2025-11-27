using UnityEngine;

public class MovementLave : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        
        ApplyMovement();
    }
    void ApplyMovement()
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed, 0);
        if (gameObject.transform.position.x <= -13) Destroy(gameObject);
        
    }
}
