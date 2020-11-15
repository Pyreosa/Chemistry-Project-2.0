using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAppear : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collider)
    {
        Debug.Log ("Hit Ya!");
    }
}

