using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouseDown : MonoBehaviour
{
    public GameObject propCanvas;
    public GameObject floodCanvas;
    public GameObject pointCanvas;
    public Slider PosX;
    public Slider PosY;
    public Slider PosZ;
    public Slider Scale;
    public Slider Rotation;
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
    public GameObject lightHolder;
    private Ray ray;
    private RaycastHit hit;
    private GameObject prev = null;
    private GameObject current = null;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Canvas PropcanvasUI = propCanvas.GetComponent<Canvas>();
        Canvas PointcanvasUI = pointCanvas.GetComponent<Canvas>();
        Canvas FloodcanvasUI = floodCanvas.GetComponent<Canvas>();
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.layer == 11)
            {   
                GameObject cur = hit.collider.gameObject;
                OnMouseProp(cur);
                if (PropcanvasUI.enabled == false)
                {
                    PropcanvasUI.enabled = true;
                    PointcanvasUI.enabled = false;
                    FloodcanvasUI.enabled = false;
                }
            }
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.layer == 12)
            {
                GameObject cur = hit.collider.gameObject;
                OnMousePoint(cur);
                if (PointcanvasUI.enabled == false)
                {
                    PointcanvasUI.enabled = true;
                    PropcanvasUI.enabled = false;
                    FloodcanvasUI.enabled = false;
                }
            }

        }
    }

    private void OnMouseProp(GameObject cur)
    {
        current = cur;
        Debug.Log("click");
        Vector3 position = current.transform.position;
        float rotation = current.transform.localRotation.eulerAngles.y;
        Vector3 scale = current.transform.localScale;

        current.transform.SetAsFirstSibling();

        PosX.value = position.x;
        PosY.value = position.y;
        PosZ.value = position.z;
        Scale.value = scale.x;
        Rotation.value = rotation;
    }

    private void OnMousePoint(GameObject cur)
    {
        Light temp = cur.GetComponent<Light>();

        Color color = temp.color;
        float intensityvalue = temp.intensity;
        Vector3 position = temp.transform.position;
        float rangevalue = temp.range;

        cur.transform.SetAsFirstSibling();

        redp.value = color.r;
        greenp.value = color.g;
        bluep.value = color.b;
        posxp.value = position.x;
        posyp.value = position.y;
        poszp.value = position.z;
        intensityp.value = intensityvalue;
        range.value = rangevalue;
    }

    public void OnMouseFlood(GameObject lightHolder)
    {
        GameObject cur = null;
        int ciel = lightHolder.transform.childCount;
        int iter = 0;
        while (iter < ciel)
        {
            if (lightHolder.transform.GetChild(iter).gameObject.GetComponent<Light>().type == LightType.Directional && lightHolder.transform.GetChild(iter).gameObject.layer == 13)
            {
                cur = lightHolder.transform.GetChild(iter).gameObject;
            }
            iter++;
        }

        Light temp = cur.GetComponent<Light>();

        Color color = temp.color;
        float intensityvalue = temp.intensity;
        Vector3 rotation = temp.transform.eulerAngles;

        cur.transform.SetAsFirstSibling();


        propCanvas.GetComponent<Canvas>().enabled = false;
        pointCanvas.GetComponent<Canvas>().enabled = false;
        floodCanvas.GetComponent<Canvas>().enabled = true;

        red.value = color.r;
        green.value = color.g;
        blue.value = color.b;
        intensity.value = intensityvalue;
        rotationx.value = rotation.x;
        rotationy.value = rotation.y;
    }

    public void CheckDirectional(GameObject AF)
    {
        int number = 0;
        int ciel = lightHolder.transform.childCount;
        int iter = 0;
        while (iter < ciel)
        {
            if (lightHolder.transform.GetChild(iter).gameObject.GetComponent<Light>().type == LightType.Directional)
            {
                number++;
            }
            iter++;
        }
        if (number > 1)
        {
            AF.SetActive(true);
        }
        else
        {
            AF.SetActive(false);
        }
    }

}
