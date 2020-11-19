using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
        public static GameObject textureRender;
        public static Canvas canvas;
        GameObject tempObject;

    void Start()
    {
        tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
        textureRender = GameObject.Find("Textures");
    }
}
