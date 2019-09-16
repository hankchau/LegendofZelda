using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepStalfos : MonoBehaviour
{
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
        if (other.gameObject.tag == "enemy")
        {
            Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
            otherRb.velocity = otherRb.velocity * -1f;
        }
    }
}
