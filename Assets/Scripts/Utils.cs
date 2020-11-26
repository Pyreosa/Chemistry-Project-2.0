using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Utils : MonoBehaviour
{
        public static GameObject tabletop;
        public static Canvas canvas;
        public static GameObject cardSpawner;
        GameObject tempObject;

    void Start()
    {
        tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
        tabletop = GameObject.Find("TableTop");
        cardSpawner = GameObject.Find("Hand");
    }
}