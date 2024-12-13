using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadLightInput : MonoBehaviour
{
    public GameObject parent;
    public Slider red;
    public Slider green;
    public Slider blue;
    public Slider intensity;
    public Slider rotationx;
    public Slider rotationy;
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
        Light temp = parent.transform.GetChild(0).gameObject.GetComponent<Light>();
        if (temp.type == LightType.Directional)
        {
            temp.color = new Color(red.value, green.value, blue.value, 1f);
            temp.intensity = intensity.value;
            temp.transform.eulerAngles = new Vector3(rotationx.value, rotationy.value, 0);
        }
        else
        {
            temp.color = new Color(redp.value, greenp.value, bluep.value);
            temp.intensity = intensityp.value;
            temp.transform.position = new Vector3(posxp.value, posyp.value, poszp.value);
            temp.range = range.value;
        }
        if (parent.transform.childCount < 2)
        {
            parent.transform.GetChild(0).gameObject.GetComponent<Light>().enabled = true;
        }

    }

    public void DeleteLight()
    {
        Light temp = parent.transform.GetChild(1).gameObject.GetComponent<Light>();

        GameObject undo = parent.transform.GetChild(0).gameObject;

        if (temp.type == LightType.Directional)
        {
            Color color = temp.color;
            float intensityvalue = temp.intensity;
            Vector3 rotation = temp.transform.eulerAngles;

            Destroy(undo);

            red.value = color.r;
            green.value = color.g;
            blue.value = color.b;
            intensity.value = intensityvalue;
            rotationx.value = rotation.x;
            rotationy.value = rotation.y;
        }
        else
        {
            Color color = temp.color;
            float intensityvalue = temp.intensity;
            Vector3 position = temp.transform.position;
            float rangevalue = temp.range;

            Destroy(undo);

            redp.value = color.r;
            greenp.value = color.g;
            bluep.value = color.b;
            posxp.value = position.x;
            posyp.value = position.y;
            poszp.value = position.z;
            intensityp.value = intensityvalue;
            range.value = rangevalue;
        }

    }

    public void ResetLighting()
    {
        Light temp = null;
        int ciel = parent.transform.childCount;
        int i = 0;
        while (i < ciel)
        {
            GameObject obj = parent.transform.GetChild(i).gameObject;
            if (obj.gameObject.layer == 13)
            {
                temp = obj.GetComponent<Light>();
                obj.SetActive(true);
            }
            i++;
        }

        Color color = temp.color;
        float intensityvalue = temp.intensity;
        Vector3 rotation = temp.transform.eulerAngles;

        int iter = parent.transform.childCount - 1;
        int floor = -1;
        while (iter > floor)
        {
            GameObject undo = parent.transform.GetChild(iter).gameObject;
            if (undo.layer == 12)
            {
                Destroy(undo);
            }
            iter--;
        }

        red.value = color.r;
        green.value = color.g;
        blue.value = color.b;
        intensity.value = intensityvalue;
        rotationx.value = rotation.x;
        rotationy.value = rotation.y;
        temp.gameObject.SetActive(true);
    }
}
