using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnLight : MonoBehaviour
{
    public GameObject PobjToSpawn;
    public GameObject FobjToSpawn;
    public GameObject sceneParent;
    public Slider redf;
    public Slider greenf;
    public Slider bluef;
    public Slider intensityf;
    public Slider rotationxf;
    public Slider rotationyf;
    public Slider redp;
    public Slider greenp;
    public Slider bluep;
    public Slider intensityp;
    public Slider posxp;
    public Slider posyp;
    public Slider poszp;
    public Slider range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnPLight()
    {
        Instantiate(PobjToSpawn, sceneParent.transform);

        Light temp = PobjToSpawn.GetComponent<Light>();

        Color color = temp.color;
        float intensityvalue = temp.intensity;
        Vector3 position = temp.transform.position;
        float rangevalue = temp.range;

        GameObject lastChild = sceneParent.transform.GetChild(sceneParent.transform.childCount - 1).gameObject;

        lastChild.transform.SetAsFirstSibling();

        redp.value = color.r;
        greenp.value = color.g;
        bluep.value = color.b;
        posxp.value = position.x;
        posyp.value = position.y;
        poszp.value = position.z;
        intensityp.value = intensityvalue;
        range.value = rangevalue;
    }

    public void spawnFLight()
    {
        Instantiate(FobjToSpawn, sceneParent.transform);

        Light temp = FobjToSpawn.GetComponent<Light>();

        Color color = temp.color;
        float intensityvalue = temp.intensity;
        Vector3 rotation = temp.transform.eulerAngles;

        GameObject lastChild = sceneParent.transform.GetChild(sceneParent.transform.childCount - 1).gameObject;

        lastChild.transform.SetAsFirstSibling();

        redf.value = color.r;
        greenf.value = color.g;
        bluef.value = color.b;
        intensityf.value = intensityvalue;
        rotationxf.value = rotation.x;
        rotationyf.value = rotation.y;
    }

}
