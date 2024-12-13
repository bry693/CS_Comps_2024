using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewProp : MonoBehaviour
{
    public GameObject sceneParent;
    public Slider PosX;
    public Slider PosY;
    public Slider PosZ;
    public Slider Scale;
    public Slider Rotation;
    public GameObject holdingSpace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteProp()
    {
        if (holdingSpace.transform.childCount > 0)
        {
            Destroy(holdingSpace.transform.GetChild(0).gameObject);
        }
        if (sceneParent.transform.childCount > 1)
        {
            GameObject temp = sceneParent.transform.GetChild(1).gameObject;
        
            GameObject undo = sceneParent.transform.GetChild(0).gameObject;

            Vector3 position = temp.transform.position;
            float rotation = temp.transform.localRotation.eulerAngles.y;
            Vector3 scale = temp.transform.localScale;

            Instantiate(undo, holdingSpace.transform);
            Destroy(undo);
            
            PosX.value = position.x;
            PosY.value = position.y;
            PosZ.value = position.z;
            Scale.value = scale.x;
            Rotation.value = rotation;
        }
        else
        {
            GameObject undo = sceneParent.transform.GetChild(0).gameObject;

            Instantiate(undo, holdingSpace.transform);
            Destroy(undo);

            PosX.value = 0;
            PosY.value = 0;
            PosZ.value = 0;
            Scale.value = 1;
            Rotation.value = 0;

        }
    }

    public void UndoDelete()
    {
        if (holdingSpace.transform.childCount > 0)
        {
            if (sceneParent.transform.childCount == 0)
            {
                GameObject temp = holdingSpace.transform.GetChild(0).gameObject;

                float rotation = temp.transform.localRotation.eulerAngles.y;
                Vector3 scale = temp.transform.localScale;

                Instantiate(temp, sceneParent.transform);
                Destroy(temp);

                PosX.value = sceneParent.transform.position.x;
                PosY.value = sceneParent.transform.position.y;
                PosZ.value = sceneParent.transform.position.z;
                Scale.value = scale.x;
                Rotation.value = rotation;
            }
            else
            {
                Instantiate(holdingSpace.transform.GetChild(0).gameObject, sceneParent.transform);
                Destroy(holdingSpace.transform.GetChild(0).gameObject);
            }
        }

    }
}
