using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AttackMovement.isAttacking)
        {
                animator.SetFloat("horizontal_input", Input.GetAxisRaw("Horizontal"));
            if(Input.GetAxisRaw("Horizontal") == 0){
            animator.SetFloat("vertical_input", Input.GetAxisRaw("Vertical"));
            }else{
                animator.SetFloat("vertical_input", 0);
            }

            if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0){
                animator.speed = 0.0f;
            }else{
                animator.speed = 1.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z))
        {
            animator.speed = 1.0f;
        }
    }

    IEnumerator Count(int num)
    {
        yield return new WaitForSeconds(num);
    }
}
