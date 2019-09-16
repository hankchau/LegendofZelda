using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{
    Rigidbody rb;

    public float movement_speed = 4;
    public static string direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (! AttackMovement.isAttacking) { 
            Vector2 current_input = GetInput();
            CheckOffset(current_input);
        }
    }

    Vector2 GetInput()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontal_input) > 0.0f)
        {
            vertical_input = 0.0f;
        }

        if (vertical_input > 0)
        {
            direction = "up";
        }
        else if (vertical_input < 0)
        {
            direction = "down";
        }
        else if (horizontal_input > 0)
        {
            direction = "right";
        }
        else if (horizontal_input < 0)
        {
            direction = "left";
        }

        return new Vector2(horizontal_input, vertical_input);
    }

    void CheckOffset(Vector2 current_input)
    {
        //if moving vertically
        //check if horizontal position aligns to half step grid
        //if it doesn't move horizontally first to align to grid - closest direction

        if ((transform.position.x % 0.5f) != 0 && current_input.y != 0)
        {
            //trying to move up at not aligned to grid

            float offset = transform.position.x % 0.5f;

            if (offset <= 0.1f)
            {
                Vector3 new_vec = transform.position;
                new_vec.x -= offset;
                transform.position = new_vec;
                //transform.position.x -= offset;
            }
            else if (offset >= 0.4f)
            {
                Vector3 new_vec = transform.position;
                new_vec.x += 0.5f - offset;
                transform.position = new_vec;
                //transform.position.x += 0.5f - offset;
            }
            else
            {
                if (offset < 0.25f)
                {
                    current_input.x = -1f;

                }
                else if (offset >= 0.25f)
                {
                    current_input.x = 1f;
                }
            }
            current_input.y = 0;
        }
        else if ((transform.position.y % 0.5f) != 0 && current_input.x != 0)
        {
            //trying to move up at not aligned to grid

            float offset = transform.position.y % 0.5f;

            if (offset <= 0.1f)
            {
                Vector3 new_vec = transform.position;
                new_vec.y -= offset;
                transform.position = new_vec;
                //transform.position.x -= offset;
            }
            else if (offset >= 0.4f)
            {
                Vector3 new_vec = transform.position;
                new_vec.y += 0.5f - offset;
                transform.position = new_vec;
                //transform.position.x += 0.5f - offset;
            }
            else
            {
                if (offset < 0.25f)
                {
                    current_input.y = -1f;

                }
                else if (offset >= 0.25f)
                {
                    current_input.y = 1f;
                }
            }
            current_input.x = 0;
        }

        rb.velocity = current_input * movement_speed;
        //Debug.Log((transform.position.x%0.5f).ToString());
    }
}
