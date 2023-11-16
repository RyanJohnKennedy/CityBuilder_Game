using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject placingObject;

    [SerializeField] private Material[] materials;

    private Vector3 pos;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    public float rotateAmount;

    public float gridSize;
    bool gridOn;
    public bool canPlace;
    [SerializeField] private Toggle gridToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(placingObject != null)
        {
            UpdateMaterials();
            
            if (gridOn)
            {
                placingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z));
            }
            else placingObject.transform.position = pos; 

            if (Input.GetMouseButtonDown(0) && canPlace)
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
        placingObject = Instantiate(objects[index], pos, transform.rotation);
    }

    void UpdateMaterials()
    {
        if (canPlace)
        {
            placingObject.GetComponent<MeshRenderer>().material = materials[0];
        }
        if (!canPlace)
        {
            placingObject.GetComponent<MeshRenderer>().material = materials[1];
        }
    }

    public void PlaceObject()
    {
        placingObject.GetComponent<MeshRenderer>().material = materials[2];
        placingObject = null;
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
        placingObject.transform.Rotate(Vector3.up, rotateAmount * Time.deltaTime);
    }
}
