using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{
        public static GameObject tabletop;
        public static Canvas canvas;
        public static GameObject cardSpawner;
        public static int currentSceneIndex;
        public static int sceneToContinue;

        GameObject tempObject;

    void Start()
    {
        tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
        tabletop = GameObject.Find("TableTop");
        cardSpawner = GameObject.Find("Hand");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneToContinue = PlayerPrefs.GetInt("SavedScenes");
    }
}