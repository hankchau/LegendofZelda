using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public AudioClip rupee_collection_sound_clip;
    public AudioClip key_collection_sound_clip;
    public AudioClip bomb_collection_sound_clip;
    public AudioClip health_collection_sound_clip;

    public Inventory inventory;
    public HealthController healthController;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogWarning("WARNING: Gameobject with a collector has no inventory to store things in!");
        }
        healthController = GetComponent<HealthController>();
        if (healthController == null)
        {
            Debug.LogWarning("WARNING: Gameobject with a collector has no health controller!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory.AddRupees(99);
            inventory.AddKeys(99);
            inventory.AddBomb(99);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;

        if (object_collided_with.tag == "rupee")
        {
            if (inventory != null)
            {
                inventory.AddRupees(1);
            }
            Destroy(object_collided_with);

            // add sound effect
            AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
        }

        else if (object_collided_with.tag == "key")
        {
            if (inventory != null)
            {
                inventory.AddKeys(1);
            }
            Destroy(object_collided_with);
            AudioSource.PlayClipAtPoint(key_collection_sound_clip, Camera.main.transform.position);
        }

        else if (object_collided_with.tag == "bomb")
        {
            if (inventory != null)
            {
                inventory.AddBomb(1);
            }
            Destroy(object_collided_with);
            AudioSource.PlayClipAtPoint(bomb_collection_sound_clip, Camera.main.transform.position);
        }

        else if (object_collided_with.tag == "heart")
        {
            if (healthController != null)
            {
                healthController.AddHealth(1f);
            }
            Destroy(object_collided_with);
            AudioSource.PlayClipAtPoint(health_collection_sound_clip, Camera.main.transform.position);
        }
    }
}
