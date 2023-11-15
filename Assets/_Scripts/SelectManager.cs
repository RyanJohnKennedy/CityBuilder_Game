using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
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


    }

    private void Deselect()
    {
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }
}
