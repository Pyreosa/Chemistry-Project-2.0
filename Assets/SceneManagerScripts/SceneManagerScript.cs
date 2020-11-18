using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // public Text ValueTxt;

    // private void OnStart()
    // {
    //     ValueTxt.text = PersistentCanvasManager.Instance.Value.ToString();
    //     Debug.Log(PersistentCanvasManager.Instance.Value);
    // }

       public void GoToActualGame()
    {
        SceneManager.LoadScene("Scenes/TableTop");
         PersistentCanvasManager.Instance.Value ++;
         Debug.Log(PersistentCanvasManager.Instance.Value);
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
        PersistentCanvasManager.Instance.Value ++;
        Debug.Log(PersistentCanvasManager.Instance.Value);
    }

    
 
}
