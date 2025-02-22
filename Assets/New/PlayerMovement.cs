using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 1f;
    public int health = 100;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A (-1) / D (+1)
        float v = Input.GetAxis("Vertical");   // W (+1) / S (-1)

        // Set parameters for Blend Tree
        animator.SetFloat("Horizontal", h);
        animator.SetFloat("Vertical", v);

        /// Move character in local space
        Vector3 moveDirection = transform.forward * v + transform.right * h;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    
}
