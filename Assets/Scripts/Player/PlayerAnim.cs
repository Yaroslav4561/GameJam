using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator is missing on the GameObject!");
        }
    }

    void Update()
    {
        bool isWalking = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D); 
        animator.SetBool("IsWalk", isWalking);  

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsJump", true); 
        }
        else
        {
            animator.SetBool("IsJump", false);
        }
    }
}
