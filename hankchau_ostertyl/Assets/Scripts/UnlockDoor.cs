using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public Sprite new_one_sprite;
    public Sprite new_left_sprite;
    public Sprite new_right_sprite;

    GameObject object_collided_with;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        object_collided_with = other.gameObject;

        if (other.tag == "Player")
        {
            inventory = object_collided_with.GetComponent<Inventory>();

            if (inventory.GetKeys() > 0)
            {
                // unlock door
                // Horizontal Door
                if (gameObject.tag == "Horizontal")
                {
                    GameObject doorObj = (transform.Find("DoorWall")).gameObject;

                    //disable box colliders
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    doorObj.GetComponent<BoxCollider>().enabled = false;

                    SpriteRenderer doorSpriteRenderer = doorObj.GetComponent<SpriteRenderer>();
                    doorSpriteRenderer.sprite = new_one_sprite;
                    doorSpriteRenderer.sortingOrder = 0;
                }
                // Vertical Door
                else if (gameObject.tag == "Vertical")
                {
                    GameObject leftDoorObj = (transform.Find("DoorWall(Left)")).gameObject;
                    GameObject rightDoorObj = (transform.Find("DoorWall(Right)")).gameObject;

                    // disable box colliders
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    leftDoorObj.GetComponent<BoxCollider>().enabled = false;
                    rightDoorObj.GetComponent<BoxCollider>().enabled = false;

                    // load new sprites
                    SpriteRenderer leftDoorSpriteRenderer = leftDoorObj.GetComponent<SpriteRenderer>();
                    SpriteRenderer rightDoorSpriteRenderer = rightDoorObj.GetComponent<SpriteRenderer>();
                    leftDoorSpriteRenderer.sprite = new_left_sprite;
                    leftDoorSpriteRenderer.sortingOrder = 0;
                    rightDoorSpriteRenderer.sprite = new_right_sprite;
                    rightDoorSpriteRenderer.sortingOrder = 0;
                }

                inventory.UseKeys();
            }
        }
    }
}
