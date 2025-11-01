using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    private float ySpawn = 0; //coordenada para criar os aneis
    private float ringsDistance = 5f; //distancia entre aneis
    private int numberOfRings = 0; //quantidade de aneis da torre

    // Start is called before the first frame update
    void Start()
    {
        numberOfRings = 5;
        SpawnRing(0); //spawn do anel inicial
        for (int i = 0; i < numberOfRings-1; i++)
        {
            SpawnRing(Random.Range(1, helixRings.Length-1));
        }
        SpawnRing(helixRings.Length - 1);
        //Instantiate(helixRings[helixRings.Length - 1], transform.up * ySpawn, Quaternion.identity);
    }

    private void SpawnRing(int i)
    {
        GameObject go = Instantiate(helixRings[i], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform; //anel pertence a torre
        ySpawn -= ringsDistance; //atualiza a coordenada y para o proximo anel
    }
}
