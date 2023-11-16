using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public GameObject selectedObject;
    public Text objNameText;
    private BuildingManager buildingManager;
    public GameObject objectUI;

    // Start is called before the first frame update
    void Start()
    {
        buildingManager = GetComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("Object"))
                    Select(hit.collider.gameObject);                    
            }
        }

        if(selectedObject != null && (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape)))
            Deselect();
    }

    private void Select(GameObject obj)
    {
        if (obj == selectedObject) return;
        if (selectedObject != null)
            Deselect();

        //Outline 
        Outline outline = obj.GetComponent<Outline>();
        if(outline == null)
            obj.AddComponent<Outline>();
        else
            outline.enabled = true;
        selectedObject = obj;
        //*

        objNameText.text = obj.name;
        objectUI.SetActive(true);
    }

    private void Deselect()
    {
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
        objectUI.SetActive(false);
    }

    public void Move()
    {
        buildingManager.placingObject = selectedObject;
    }

    public void Delete()
    {
        GameObject objToDestroy = selectedObject;
        Deselect();
        Destroy(objToDestroy);
    }
}
