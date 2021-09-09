using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaitScript : MonoBehaviour
{
    public Text text;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        text.enabled = true;
    }
}
