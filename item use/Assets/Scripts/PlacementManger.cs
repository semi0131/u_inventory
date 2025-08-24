using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManger : MonoBehaviour
{
    public static PlacementManger Instance;

    private GameObject objectToPlace;
    private bool isPlacementMode = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isPlacementMode && Input.GetMouseButtonDown(0))
        {
            PlaceObject();
        }
    }

    public void StartPlacement(GameObject prefab)
    {
        objectToPlace = prefab;
        isPlacementMode = true;
    }

    private void PlaceObject()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        if (objectToPlace != null)
        {
            Instantiate(objectToPlace, mousePosition, Quaternion.identity);
            Debug.Log("블록이 배치되었습니다!");
            EndPlacement();
        }
    }

    private void EndPlacement()
    {
        isPlacementMode = false;
        objectToPlace = null;
        Debug.Log("블록 배치 모드를 종료합니다.");
    }
}
