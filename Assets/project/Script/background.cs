using UnityEngine;

public class background : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        ApplyMovement();
    }
    void ApplyMovement()
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed, 0);
        if (gameObject.transform.position.x <= -23) gameObject.transform.position = new Vector3(28.15f, 1.1f, 0);
    }
}
