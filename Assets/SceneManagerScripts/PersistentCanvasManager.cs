using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PersistentCanvasManager : MonoBehaviour
{
    public static PersistentCanvasManager Instance { get; private set; }

    public int Value;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log(PersistentCanvasManager.Instance.Value);
        }else{
            Destroy(gameObject);
            Debug.Log(PersistentCanvasManager.Instance.Value);
        }
    }
}
