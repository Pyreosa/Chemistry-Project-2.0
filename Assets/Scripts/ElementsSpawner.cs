using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementsSpawner : MonoBehaviour
{
    public GameObject spawnChloride;
    public GameObject spawnSodium;
    public GameObject spawnHydrogen;

    private GameObject spawnChlorideMolecule;
    private GameObject spawnSodiumMolecule;
    private GameObject spawnHydrogenMolecule;

    public void spawnChlorideToHand ()
    {
         spawnChlorideMolecule = Instantiate(spawnChloride, new Vector3(10, 10), Quaternion.identity);
         spawnChlorideMolecule.transform.SetParent(Utils.cardSpawner.transform);
    }
    
    public void spawnSodiumToHand ()
    {
         spawnSodiumMolecule = Instantiate(spawnSodium, new Vector3(10, 10), Quaternion.identity);
         spawnSodiumMolecule.transform.SetParent(Utils.cardSpawner.transform);
    }

    public void spawnHydrogenToHand ()
    {
         spawnHydrogenMolecule = Instantiate(spawnHydrogen, new Vector3(10, 10), Quaternion.identity);
         spawnHydrogenMolecule.transform.SetParent(Utils.cardSpawner.transform);
    }

}
