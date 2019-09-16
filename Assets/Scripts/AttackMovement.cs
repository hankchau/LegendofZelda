using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMovement : MonoBehaviour
{
    public static bool isAttacking;

    public Inventory inventory;

    GameObject swordUp;
    // GameObject bowRight;
    GameObject arrowRight;
    GameObject weaponClone;
    GameObject arrowClone;
    HealthController healthController;

    Animator animator;

    private string mode;

    // Start is called before the first frame update
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
        healthController = gameObject.GetComponent<HealthController>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (!isAttacking && Input.GetKeyDown(KeyCode.X))
        {
            mode = "sword";
            AttackMovement.isAttacking = true;
            animator.SetBool("attack", true);
            swordUp = Resources.Load<GameObject>("Prefabs/SwordUp");
            StartCoroutine(Attack());
        }
        else if (!isAttacking && Input.GetKeyDown(KeyCode.Z))
        {
            // check if rupees available
            if (inventory.GetRupees() > 0)
            {
                inventory.UseRupees();
                mode = "bow";
                AttackMovement.isAttacking = true;
                animator.SetBool("attack", true);
                // bowRight = Resources.Load<GameObject>("Prefabs/BowRight");
                arrowRight = Resources.Load<GameObject>("Prefabs/ArrowRight");
                StartCoroutine(Attack());
            }
        }
    }
    
    public IEnumerator Attack()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        if (ArrowKeyMovement.direction == "up")
        {
            if (mode == "sword")
            {
                swordUp.transform.eulerAngles = new Vector3(0, 0, 0);
                swordUp.transform.position = gameObject.transform.position + new Vector3(0, 0.8f, 0);
                weaponClone = Object.Instantiate(swordUp, swordUp.transform);
                yield return new WaitForSeconds(0.3f);

                if (healthController.IsFullHealth())
                {
                    // shoot sword
                    weaponClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 0);
                }
                else
                {
                    Destroy(weaponClone);
                }
            }
            else if (mode == "bow")
            {
                // bowRight.transform.eulerAngles = new Vector3(0, 0, 90);
                // bowRight.transform.position = gameObject.transform.position + new Vector3(0, 0.8f, 0);
                // weaponClone = Object.Instantiate(bowRight, bowRight.transform);

                arrowRight.transform.eulerAngles = new Vector3(0, 0, 90);
                arrowRight.transform.position = gameObject.transform.position + new Vector3(0, 0.8f, 0);
                arrowClone = Object.Instantiate(arrowRight, arrowRight.transform);
                yield return new WaitForSeconds(0.3f);
                arrowClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 8, 0);
                Destroy(weaponClone);
            }
        }

        else if (ArrowKeyMovement.direction == "down")
        {
            if (mode == "sword")
            {
                swordUp.transform.eulerAngles = new Vector3(0, 0, 180);
                swordUp.transform.position = gameObject.transform.position + new Vector3(0, -0.8f, 0);
                weaponClone = Object.Instantiate(swordUp, swordUp.transform);
                yield return new WaitForSeconds(0.3f);

                if (healthController.IsFullHealth())
                {
                    // shoot sword
                    weaponClone.GetComponent<Rigidbody>().velocity = new Vector3(0, -6, 0);
                }
                else
                {
                    Destroy(weaponClone);
                }
            }
            else if (mode == "bow")
            {
                // bowRight.transform.eulerAngles = new Vector3(0, 0, -90);
                // bowRight.transform.position = gameObject.transform.position + new Vector3(0, -0.8f, 0);
                // weaponClone = Object.Instantiate(bowRight, bowRight.transform);

                arrowRight.transform.eulerAngles = new Vector3(0, 0, 90);
                arrowRight.transform.position = gameObject.transform.position + new Vector3(0, -0.8f, 0);
                arrowClone = Object.Instantiate(arrowRight, arrowRight.transform);
                yield return new WaitForSeconds(0.3f);
                arrowClone.GetComponent<Rigidbody>().velocity = new Vector3(0, -8, 0);
                Destroy(weaponClone);
            }
        }

        else if (ArrowKeyMovement.direction == "right")
        {
            if (mode == "sword")
            {
                swordUp.transform.eulerAngles = new Vector3(0, 0, -90);
                swordUp.transform.position = gameObject.transform.position + new Vector3(0.8f, 0, 0);
                weaponClone = Object.Instantiate(swordUp, swordUp.transform);
                yield return new WaitForSeconds(0.3f);

                if (healthController.IsFullHealth())
                {
                    // shoot sword
                    weaponClone.GetComponent<Rigidbody>().velocity = new Vector3(6, 0, 0);
                }
                else
                {
                    Destroy(weaponClone);
                }
            }
            else if (mode == "bow")
            {
                // bowRight.transform.eulerAngles = new Vector3(0, 0, 0);
                // bowRight.transform.position = gameObject.transform.position + new Vector3(0.8f, 0, 0);
                // weaponClone = Object.Instantiate(bowRight, bowRight.transform);

                arrowRight.transform.eulerAngles = new Vector3(0, 0, 0);
                arrowRight.transform.position = gameObject.transform.position + new Vector3(0.8f, 0, 0);
                arrowClone = Object.Instantiate(arrowRight, arrowRight.transform);
                yield return new WaitForSeconds(0.3f);
                arrowClone.GetComponent<Rigidbody>().velocity = new Vector3(8, 0, 0);
                Destroy(weaponClone);
            }
        }
        else if (ArrowKeyMovement.direction == "left")
        {
            if (mode == "sword")
            {
                swordUp.transform.eulerAngles = new Vector3(0, 0, 90);
                swordUp.transform.position = gameObject.transform.position + new Vector3(-0.8f, 0, 0);
                weaponClone = Object.Instantiate(swordUp, swordUp.transform);
                yield return new WaitForSeconds(0.3f);

                if (healthController.IsFullHealth())
                {
                    // shoot sword
                    weaponClone.GetComponent<Rigidbody>().velocity = new Vector3(-6, 0, 0);
                }
                else
                {
                    Destroy(weaponClone);
                }
            }
            else if (mode == "bow")
            {
                // bowRight.transform.eulerAngles = new Vector3(0, 0, 180);
                // bowRight.transform.position = gameObject.transform.position + new Vector3(-0.8f, 0, 0);
                // weaponClone = Object.Instantiate(bowRight, bowRight.transform);

                arrowRight.transform.eulerAngles = new Vector3(0, 0, 180);
                arrowRight.transform.position = gameObject.transform.position + new Vector3(-0.8f, 0, 0);
                arrowClone = Object.Instantiate(arrowRight, arrowRight.transform);
                yield return new WaitForSeconds(0.3f);
                arrowClone.GetComponent<Rigidbody>().velocity = new Vector3(-8, 0, 0);
                Destroy(weaponClone);
            }
        }

        yield return new WaitForSeconds(0.2f);

        animator.SetBool("attack", false);
        AttackMovement.isAttacking = false;
    }
}
