using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Animator animator = other.GetComponent<Animator>();

            animator.SetInteger("IndexOfTransparent", 0);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Animator animator = other.GetComponent<Animator>();

            animator.SetInteger("IndexOfTransparent", 1);
        }
    }


}
