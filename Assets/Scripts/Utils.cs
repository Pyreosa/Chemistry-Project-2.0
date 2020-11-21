using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
        public static GameObject tabletop;
        public static Canvas canvas;
        GameObject tempObject;

    void Start()
    {
        tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
        tabletop= GameObject.Find("TableTop");
    }
}