using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float health = 2f;

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
        if (other.gameObject.tag == "sword")
        {
            TakeDamage(1f);

            if (other.gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.tag == "arrow")
        {
            TakeDamage(0.5f);

            if (other.gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                Destroy(other.gameObject);
            }
        }
    }

    void TakeDamage(float amount)
    {
        if (health - amount <= 0)
        {
            Destroy(gameObject);

            return;
        }

        // change color
        GetComponent<SpriteRenderer>().color = Color.red;
        health -= amount;
        StartCoroutine(Count(1));
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
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
