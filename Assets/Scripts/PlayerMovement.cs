using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 1f;
    private void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A (-1) / D (+1)
        float v = Input.GetAxis("Vertical");   // W (+1) / S (-1)

        // Set parameters for Blend Tree
        animator.SetFloat("Horizontal", h, 0.2f, Time.deltaTime);
        animator.SetFloat("Vertical", v, 0.2f, Time.deltaTime);

        /// Move character in local space
        Vector3 moveDirection = transform.forward * v + transform.right * h;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    
}
