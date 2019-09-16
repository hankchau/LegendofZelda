using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public HealthController healthController;
    Text text_component;

    // Start is called before the first frame update
    void Start()
    {
        text_component = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthController != null && text_component != null)
        {
            text_component.text = "Health: " + healthController.GetHealth().ToString();
        }
    }
}
