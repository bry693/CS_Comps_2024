using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public GameObject viewParent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnToView()
    {
        DeletePreviousSpawns();
        Instantiate(objToSpawn, viewParent.transform);
    }

    public void DeletePreviousSpawns()
    {
        if (viewParent.transform.childCount > 0)
        {
            Destroy(viewParent.transform.GetChild(0).gameObject);
        }
    }
}
