using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnToScene : MonoBehaviour
{
    public GameObject viewParent;
    public GameObject sceneParent;
    public Slider PosX;
    public Slider PosY;
    public Slider PosZ;
    public Slider Scale;
    public Slider Rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {

        if (sceneParent.transform.childCount == 0)
        {
            GameObject temp = viewParent.transform.GetChild(0).gameObject;

            float rotation = temp.transform.localRotation.eulerAngles.y;
            Vector3 scale = temp.transform.localScale;

            Instantiate(viewParent.transform.GetChild(0), sceneParent.transform);

            PosX.value = sceneParent.transform.position.x;
            PosY.value = sceneParent.transform.position.y;
            PosZ.value = sceneParent.transform.position.z;
            Scale.value = scale.x;
            Rotation.value = rotation;
        }
        else
        {
            Instantiate(viewParent.transform.GetChild(0), sceneParent.transform);
        }
    }
}
