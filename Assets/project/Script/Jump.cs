using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Jump : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRgigidBody2D;
    [SerializeField] float jumpHight;
    [SerializeField] UnityEvent jump;

    public bool dommage;
    private void Update()
    {
        AppllyJump();
        HandleRotation();
    }

    void AppllyJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!dommage)
            {
                playerRgigidBody2D.AddForce(new Vector2(0, jumpHight));
                playerRgigidBody2D.linearVelocityY = 0;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 20);
                if (playerRgigidBody2D.linearVelocityY < 0) gameObject.transform.rotation = Quaternion.Euler(0, 0, -20);
                jump.Invoke();
            }
           
        }
        
    }
    void HandleRotation()
    {
        float ySpeed = playerRgigidBody2D.linearVelocityY;

        if (ySpeed > 0)
        {
           
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }
        else if (ySpeed < 0)
        {
            
            transform.rotation = Quaternion.Euler(0, 0, -20);
        }
        else
        {
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}