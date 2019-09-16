using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public float transition_time = 2.5f;
    public float move_speed = 1/180f;

    Camera mainCamera;
    Rigidbody cameraRb;

    private Vector3 transformBy;
    private Vector3 exit_velocity;
    private Vector3 destPos;
    private string direction;
    private Vector3 offset;

    private bool moveCam = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraRb = mainCamera.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (moveCam)
        {
            Vector3 v = offset / transition_time;
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, destPos, ref v, transition_time);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject object_collided_with = other.gameObject;


        if (object_collided_with.tag == "Player")
        {
            StartCoroutine(ChangeRoom(object_collided_with));
        }
    }

    IEnumerator ChangeRoom(GameObject playerObject)
    {

        // get rigidbody
        Rigidbody playerRb = playerObject.GetComponent<Rigidbody>();

        exit_velocity = playerRb.velocity;

        // going up
        if (playerRb.velocity.y > 0)
        {
            offset = new Vector3(0, 10.85999999999f, 0);
            destPos = mainCamera.transform.position + offset;
            //cameraRb.velocity = new Vector3(0, 10.85999999999f / transition_time, 0);
            playerObject.transform.position += new Vector3(0, 0.5f, 0);
            direction = "up";
            moveCam = true;
        }
        // going down
        else if (playerRb.velocity.y < 0)
        {
            offset = new Vector3(0, -10.85999999999f, 0);
            destPos = mainCamera.transform.position + offset;
            //cameraRb.velocity = new Vector3(0, -10.85999999999f / transition_time, 0);
            playerObject.transform.position += new Vector3(0, -1, 0);
            direction = "down";
            moveCam = true;
        }
        // going right
        else if (playerRb.velocity.x > 0)
        {
            offset = new Vector3(15.85999999999f, 0, 0);
            destPos = mainCamera.transform.position + offset;
            //cameraRb.velocity = new Vector3(15.8599999999f / transition_time, 0, 0);
            playerObject.transform.position += new Vector3(1, 0, 0);
            direction = "right";
            moveCam = true;
        }
        // going left
        else if (playerRb.velocity.x < 0)
        {
            offset = new Vector3(-15.85999999999f, 0, 0);
            destPos = mainCamera.transform.position + offset;
            //cameraRb.velocity = new Vector3(-15.85999999999f / transition_time, 0, 0);
            playerObject.transform.position += new Vector3(-1, 0, 0);
            direction = "left";
            moveCam = true;
        }

        // start camera transition
        float counter = transition_time;

        // player loses control
        playerRb.constraints = RigidbodyConstraints.FreezePosition;

        yield return StartCoroutine(Count(counter, playerRb));

        // stop camera tarnsition
        //cameraRb.velocity = Vector3.zero;

        // player regains control
        playerRb.constraints = RigidbodyConstraints.None;
        playerRb.constraints = RigidbodyConstraints.FreezePositionZ;
        playerRb.constraints = RigidbodyConstraints.FreezeRotation;
        moveCam = false;

        MoveOutDoor(playerObject);
    }

    IEnumerator Count(float counter, Rigidbody playerRb)
    {
        while (counter > 0)
        {
            counter--;
            yield return new WaitForSeconds(1);
        }
    }

    void MoveOutDoor(GameObject playerObject)
    {
        // player walks out of door
        if (direction == "up")
        {
            playerObject.transform.position += new Vector3(0, 2, 0);
        }
        else if (direction == "down")
        {
            playerObject.transform.position += new Vector3(0, -2, 0);
        }
        else if (direction == "right")
        {
            playerObject.transform.position += new Vector3(1, 0, 0);
                    }
        else if (direction == "left")
        {
            playerObject.transform.position += new Vector3(-1, 0, 0);
        }
    }
}
