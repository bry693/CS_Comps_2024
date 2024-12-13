using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimationPlay : MonoBehaviour
{
    public GameObject LightingHolder;
    public GameObject SceneSpace;
    public Slider scene1;
    public Slider scene2;
    public Slider scene3;
    public Slider scene4;
    public Slider scene5;
    public TMP_Text scene1text;
    public TMP_Text scene2text;
    public TMP_Text scene3text;
    public TMP_Text scene4text;
    public TMP_Text scene5text;
    public Canvas HUDON;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scene1text.SetText("Scene 1 lasts {0} seconds", GetNum(scene1));
        scene2text.SetText("Scene 2 lasts {0} seconds", GetNum(scene2));
        scene3text.SetText("Scene 3 lasts {0} seconds", GetNum(scene3));
        scene4text.SetText("Scene 4 lasts {0} seconds", GetNum(scene4));
        scene5text.SetText("Scene 5 lasts {0} seconds", GetNum(scene5));
    }

    public float GetNum(Slider scene)
    {
        return scene.value;
    }

    public IEnumerator Animation()
    {
        List<Slider> scenenums = new List<Slider>()
        {
            scene1, scene2, scene3, scene4, scene5
        };
        Clear();
        int i = 0;
        while (i < 5)
        {
            LoadProps(i);
            LoadLights(i);
            float number = GetNum(scenenums[i]);
            yield return new WaitForSeconds(number);
            Clear();
            i++;
        }
        EndAni();
    }

    public void startAnimation()
    {
        StartCoroutine(Animation());
    }

    public void Clear()
    {
        int ciel = SceneSpace.transform.childCount - 1;
        while (ciel > -1)
        {
            GameObject obj = SceneSpace.transform.GetChild(ciel).gameObject;
            obj.SetActive(false);
            ciel--;
        }
        ciel = LightingHolder.transform.childCount - 1;
        while (ciel > -1)
        {
            GameObject obj = LightingHolder.transform.GetChild(ciel).gameObject;
            obj.SetActive(false);
            ciel--;
        }
    }

    public void EndAni()
    {
        int ciel = SceneSpace.transform.childCount - 1;
        while (ciel > -1)
        {
            GameObject obj = SceneSpace.transform.GetChild(ciel).gameObject;
            if (obj.gameObject.layer == 11)
            obj.SetActive(true);
            ciel--;
        }
        HUDON.enabled = true;
    }

    public void LoadProps(int value)
    {
        int ciel = SceneSpace.transform.childCount;
        int i = 0;
        while (i < ciel)
        {
            GameObject obj = SceneSpace.transform.GetChild(i).gameObject;
            if (obj.gameObject.layer == value + 21)
            {
                obj.SetActive(true);
            }
            i++;
        }
    }

    public void LoadLights(int value)
    {
        int ciel = LightingHolder.transform.childCount;
        int i = 0;
        while (i < ciel)
        {
            GameObject obj = LightingHolder.transform.GetChild(i).gameObject;
            if (obj.gameObject.layer == value + 26)
            {
                obj.SetActive(true);
            }
            i++;
        }
    }

}
