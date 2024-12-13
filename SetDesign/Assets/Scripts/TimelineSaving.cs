using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimelineSaving : MonoBehaviour
{
    public GameObject LightingHolder;
    public GameObject SceneSpace;
    public Slider sceneNum;
    public TMP_Text save;
    public TMP_Text load;
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
        save.SetText("Save Scene {0}", GetNum());
        load.SetText("Load Scene {0}", GetNum());
    }

     public float GetNum()
    {
        return sceneNum.value;
    }

    public void SaveScene()
    {
        if (CheckIfEmpty())
        {
            SaveProps();
            SaveLights();
        }
        else
        {
            int num = (int)GetNum();
            int ciel = SceneSpace.transform.childCount - 1;
            while (ciel > -1)
            {
                GameObject obj = SceneSpace.transform.GetChild(ciel).gameObject;
                if (obj.gameObject.layer == num + 20)
                {
                    if (obj == SceneSpace.transform.GetChild(0).gameObject)
                    {
                        GameObject temp = SceneSpace.transform.GetChild(1).gameObject;

                        GameObject undo = SceneSpace.transform.GetChild(0).gameObject;

                        Vector3 position = temp.transform.position;
                        float rotation = temp.transform.localRotation.eulerAngles.y;
                        Vector3 scale = temp.transform.localScale;

                        Destroy(undo);

                        PosX.value = position.x;
                        PosY.value = position.y;
                        PosZ.value = position.z;
                        Scale.value = scale.x;
                        Rotation.value = rotation;
                    }
                    else
                    {
                        Destroy(obj);
                    }
                }
                ciel--;
            }
        }
    }

    public void SaveProps()
    {
        int num = (int)GetNum();
        int ciel = SceneSpace.transform.childCount - 1;
        while (ciel > -1)
        {
            GameObject obj = SceneSpace.transform.GetChild(ciel).gameObject;
            if (obj.gameObject.layer == num + 20)
            {
                if (obj == SceneSpace.transform.GetChild(0).gameObject)
                {
                    GameObject temp = SceneSpace.transform.GetChild(1).gameObject;

                    GameObject undo = SceneSpace.transform.GetChild(0).gameObject;

                    Vector3 position = temp.transform.position;
                    float rotation = temp.transform.localRotation.eulerAngles.y;
                    Vector3 scale = temp.transform.localScale;

                    Destroy(undo);

                    PosX.value = position.x;
                    PosY.value = position.y;
                    PosZ.value = position.z;
                    Scale.value = scale.x;
                    Rotation.value = rotation;
                }
                else
                {
                    Destroy(obj);
                }
            }
            ciel--;
        }

        ciel = SceneSpace.transform.childCount;
        int i = 0;
        while (i < ciel)
        {
            GameObject obj = SceneSpace.transform.GetChild(i).gameObject;
            if (obj.gameObject.layer == 11)
            {
                GameObject newobj = Instantiate(obj, SceneSpace.transform);
                newobj.layer = num + 20;
                newobj.SetActive(false);
            }
            i++;
        }
    }

    public void SaveLights()
    {
        int num = (int)GetNum();
        int ciel = LightingHolder.transform.childCount - 1;
        while (ciel > -1)
        {
            GameObject obj = LightingHolder.transform.GetChild(ciel).gameObject;
            if (obj.gameObject.layer == num + 25)
            {
                Destroy(obj);
            }
            ciel--;
        }

        ciel = LightingHolder.transform.childCount;
        int i = 0;
        while (i < ciel)
        {
            GameObject obj = LightingHolder.transform.GetChild(i).gameObject;
            if (obj.gameObject.layer == 12)
            {
                GameObject newobj = Instantiate(obj, LightingHolder.transform);
                newobj.layer = num + 25;
                newobj.SetActive(false);
            }
            i++;
        }
    }

    public void LoadScene()
    {
        if (CheckIfProps())
        {
            LoadProps();
            LoadLights();
        }
    }

    public void LoadProps()
    {
        int num = (int)GetNum();
        int ciel = SceneSpace.transform.childCount - 1;
        while (ciel > -1)
        {
            GameObject obj = SceneSpace.transform.GetChild(ciel).gameObject;
            if (obj.gameObject.layer == 11)
            {
                if (obj == SceneSpace.transform.GetChild(0).gameObject)
                {
                    GameObject temp = SceneSpace.transform.GetChild(1).gameObject;

                    GameObject undo = SceneSpace.transform.GetChild(0).gameObject;

                    Vector3 position = temp.transform.position;
                    float rotation = temp.transform.localRotation.eulerAngles.y;
                    Vector3 scale = temp.transform.localScale;

                    Destroy(undo);

                    PosX.value = position.x;
                    PosY.value = position.y;
                    PosZ.value = position.z;
                    Scale.value = scale.x;
                    Rotation.value = rotation;
                }
                else
                {
                    Destroy(obj);
                }
            }
            ciel--;
        }

        ciel = SceneSpace.transform.childCount;
        int i = 0;
        while (i < ciel)
        {
            GameObject obj = SceneSpace.transform.GetChild(i).gameObject;
            if (obj.gameObject.layer == num + 20)
            {
                GameObject newobj = Instantiate(obj, SceneSpace.transform);
                newobj.layer = 11;
                newobj.SetActive(true);
            }
            i++;
        }
    }

    public void LoadLights()
    {
        int num = (int)GetNum();
        int ciel = LightingHolder.transform.childCount - 1;
        while (ciel > -1)
        {
            GameObject obj = LightingHolder.transform.GetChild(ciel).gameObject;
            if (obj.gameObject.layer == 12)
            {
                Destroy(obj);
            }
            ciel--;
        }

        ciel = LightingHolder.transform.childCount;
        int i = 0;
        while (i < ciel)
        {
            GameObject obj = LightingHolder.transform.GetChild(i).gameObject;
            if (obj.gameObject.layer == num + 25)
            {
                GameObject newobj = Instantiate(obj, LightingHolder.transform);
                newobj.layer = 12;
                newobj.SetActive(true);
            }
            if (obj.gameObject.layer == 13)
            {
                obj.SetActive(false);
            }
            i++;
        }
    }

    public bool CheckIfProps()
    {
        int num = (int)GetNum();
        int ciel = SceneSpace.transform.childCount;
        int i = 0;
        while (i < ciel)
        {
            GameObject obj = SceneSpace.transform.GetChild(i).gameObject;
            if (obj.gameObject.layer == num + 20)
            {
                return true;
            }
            i++;
        }
        return false;
    }

    public bool CheckIfEmpty()
    {
        int ciel = SceneSpace.transform.childCount;
        int i = 0;
        while (i < ciel)
        {
            GameObject obj = SceneSpace.transform.GetChild(i).gameObject;
            if (obj.gameObject.layer == 11)
            {
                return true;
            }
            i++;
        }
        return false;
    }
}