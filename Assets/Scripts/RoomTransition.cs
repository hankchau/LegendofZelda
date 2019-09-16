using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public float transition_time = 2.5f;

    Camera camera;
    float height;
    float width;

    private Vector3 transformBy;
    private Vector3 exit_velocity;
    private Vector3 destPos;
    private string direction;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        height = camera.orthographicSize * 2f;
        width = height * camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {

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

        // get rigidbody to determine velocity
        Rigidbody playerRb = playerObject.GetComponent<Rigidbody>();
        Rigidbody cameraRb = camera.GetComponent<Rigidbody>();

        exit_velocity = playerRb.velocity;

        // going up
        if (playerRb.velocity.y > 0)
        {
            destPos = camera.transform.position + new Vector3(0, 10.85999999999f, 0);
            cameraRb.velocity = new Vector3(0, 10.85999999999f / transition_time, 0);
            playerObject.transform.position += new Vector3(0, 0.5f, 0);
            direction = "up";
        }
        // going down
        else if (playerRb.velocity.y < 0)
        {
            destPos = camera.transform.position + new Vector3(0, -10.85999999999f, 0);
            cameraRb.velocity = new Vector3(0, -10.85999999999f / transition_time, 0);
            playerObject.transform.position += new Vector3(0, -1, 0);
            direction = "down";
        }
        // going right
        else if (playerRb.velocity.x > 0)
        {
            destPos = camera.transform.position + new Vector3(15.85999999999f, 0, 0);
            cameraRb.velocity = new Vector3(15.8599999999f / transition_time, 0, 0);
            playerObject.transform.position += new Vector3(1, 0, 0);
            direction = "right";
        }
        // going left
        else if (playerRb.velocity.x < 0)
        {
            destPos = camera.transform.position + new Vector3(-15.85999999999f, 0, 0);
            cameraRb.velocity = new Vector3(-15.85999999999f / transition_time, 0, 0);
            playerObject.transform.position += new Vector3(-1, 0, 0);
            direction = "left";
        }

        // start camera transition
        float counter = transition_time;

        // player loses control
        playerRb.constraints = RigidbodyConstraints.FreezePosition;

        yield return StartCoroutine(Count(counter, playerRb));

        // stop camera tarnsition
        cameraRb.velocity = Vector3.zero;

        // player regains control
        playerRb.constraints = RigidbodyConstraints.None;
        playerRb.constraints = RigidbodyConstraints.FreezePositionZ;
        playerRb.constraints = RigidbodyConstraints.FreezeRotation;

        MoveOutDoor(playerObject);
    }

    IEnumerator Count(float counter, Rigidbody playerRb)
    {
        while (counter > 0)
        {
            counter--;
            yield return new WaitForSeconds(1);
        }

        // recalibrate camera
        if (counter == 0){

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
