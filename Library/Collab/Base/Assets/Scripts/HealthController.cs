using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    float health_count = 3.0f;
    float max_health = 3.0f;

    public static bool god_mode = false;
    public static bool invinvcible = false;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            god_mode = true;
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (god_mode)
        {
            // sparking
            if (spriteRenderer.enabled == true)
            {
                spriteRenderer.enabled = false;
            }
            else
            {
                spriteRenderer.enabled = true;
            }
        }
        else
        {
            spriteRenderer.enabled = true;
        }

        // check if game over
        if (System.Math.Abs(health_count) < 0.001)
        {
            // Game Over
            gameManager.SetGameOver();
            gameManager.EndGame();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject object_collided_with = other.gameObject;

        if (!god_mode)
        {
            if (object_collided_with.tag == "enemy")
            {
                UseHealth(0.5f);

                GetComponent<SpriteRenderer>().color = Color.red;

                // pushed back
                float dist = 2.0f;
                if (ArrowKeyMovement.direction == "up")
                {
                    dist = check_direction(Vector3.down);
                    Vector3 destPos = transform.position + new Vector3(0, -dist, 0);
                    transform.position = Vector3.MoveTowards(transform.position, destPos, 2);
                }
                else if (ArrowKeyMovement.direction == "down")
                {
                    dist = check_direction(Vector3.up);
                    Vector3 destPos = transform.position + new Vector3(0, dist, 0);
                    transform.position = Vector3.MoveTowards(transform.position, destPos, 2);
                }
                else if (ArrowKeyMovement.direction == "right")
                {
                    dist = check_direction(Vector3.left);
                    Vector3 destPos = transform.position + new Vector3(-dist, 0, 0);
                    transform.position = Vector3.MoveTowards(transform.position, destPos, 2);
                }
                else if (ArrowKeyMovement.direction == "left")
                {
                    dist = check_direction(Vector3.right);
                    Vector3 destPos = transform.position + new Vector3(dist, 0, 0);
                    transform.position = Vector3.MoveTowards(transform.position, destPos, 2);
                }

                // invincibility period
                god_mode = true;
                StartCoroutine(Count(3));
            }
        }

        else if (object_collided_with.tag == "health")
        {
            AddHealth(1);
        }
    }

    IEnumerator Count(int num)
    {
        while (num > 0)
        {
            num--;
            yield return new WaitForSeconds(1);
        }

        if (num == 0)
        {
            god_mode = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void AddHealth(float add_amount)
    {
        if (health_count < max_health)
        {
            if (health_count + add_amount >= max_health)
            {
                health_count = max_health;
            }
            else
            {
                health_count += add_amount;
            }
        }
    }

    public void UseHealth(float use_amount)
    {
        health_count -= use_amount;
    }

    public float GetHealth()
    {
        return health_count;
    }

    public bool IsFullHealth()
    {
        return System.Math.Abs(health_count - max_health) < 0.5f;
    }

    private float check_direction(Vector3 dir){
        float ret = 2.0f;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, dir, 2f);
        foreach(RaycastHit hit in hits){
            
            if(hit.collider.gameObject.name == "Tile_WALL"){
                if(ret > hit.distance){
                    ret = hit.distance - 0.25f;
                }
            }
        }
        Debug.Log(ret.ToString());
        return ret;
    }
}
