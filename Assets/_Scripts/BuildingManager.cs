using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject selectedObject;

    private Vector3 pos;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    public float rotateAmount;

    public float gridSize;
    bool gridOn;
    [SerializeField] private Toggle gridToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedObject != null)
        {
            if (gridOn)
            {
                selectedObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z));
            }
            else selectedObject.transform.position = pos; 

            if (Input.GetMouseButtonDown(0))
                PlaceObject();
            if (Input.GetKey(KeyCode.R))
                RotateObject();
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
            pos = hit.point;

    }

    public void SelectObject(int index)
    {
        selectedObject = Instantiate(objects[index], pos, transform.rotation);
    }

    public void PlaceObject()
    {
        selectedObject = null;
    }

    public void ToggleGrid()
    {
        if (gridToggle.isOn)
            gridOn = true;
        else 
            gridOn = false;
    }

    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
            pos += gridSize;

        return pos;
    }

    public void RotateObject()
    {
        selectedObject.transform.Rotate(Vector3.up, rotateAmount * Time.deltaTime);
    }
}
