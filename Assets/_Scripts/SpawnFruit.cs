using System;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public GameObject setSpawn(GameObject prefeb)
    {
        GameObject fruitStay = Instantiate(prefeb, gameObject.transform.position, Quaternion.identity);
        return fruitStay;
    }

}
