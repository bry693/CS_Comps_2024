using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public GameObject parent;
    public Slider PosX;
    public Slider PosY;
    public Slider PosZ;
    public Slider Scale;
    public Slider rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.transform.childCount > 0) {
            GameObject temp = parent.transform.GetChild(0).gameObject;
            temp.transform.position = new Vector3(PosX.value, PosY.value, PosZ.value);
            temp.transform.localScale = new Vector3(Scale.value, Scale.value, Scale.value);
            temp.transform.rotation = Quaternion.AngleAxis(rotation.value, Vector3.up);
        }
    }

}
