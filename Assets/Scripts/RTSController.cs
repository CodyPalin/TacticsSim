using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class RTSController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 nextPositionLeft;
    private Vector3 nextPositionRight;
    private List<RTSUnit> selectedRTSUnitList;
    private GameObject SelectionBox;
    private bool mousedown;

    private void Awake()
    {
        selectedRTSUnitList = new List<RTSUnit>();
        SelectionBox = GameObject.Find("SelectionBox");
        SelectionBox.SetActive(false);
    }
    private void Update()
    {
        Vector3 currentPosition = UtilsClass.GetMouseWorldPosition();
        //LMB
        if (Input.GetMouseButtonDown(0))
        {
            //Left mouse Button press
            startPosition = UtilsClass.GetMouseWorldPosition();
            mousedown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //left Mouse Button Released
            mousedown = false;
            //make selection box disappear
            SelectionBox.SetActive(false);
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, currentPosition);
            foreach(RTSUnit RTSunit in selectedRTSUnitList)
            {
                RTSunit.SetSelectedVisible(false);
            }
            selectedRTSUnitList.Clear();


            foreach(Collider2D collider2D in collider2DArray)
            {
                RTSUnit RTSunit = collider2D.GetComponent<RTSUnit>();
                if (RTSunit != null)
                {
                    RTSunit.SetSelectedVisible(true);
                    selectedRTSUnitList.Add(RTSunit);
                }
            }
            Debug.Log(selectedRTSUnitList.Count);
        }
        //if lmb held down
        if (mousedown && startPosition != currentPosition)
        {
            DrawSelectionBox(startPosition, currentPosition);
        }

        //RMB
        if (Input.GetMouseButtonDown(1))
        {
            //right Mouse Button press
            nextPositionLeft = UtilsClass.GetMouseWorldPosition();
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            //right Mouse Button Released
            nextPositionRight = UtilsClass.GetMouseWorldPosition();
            if (selectedRTSUnitList.Count == 1)
            {
                selectedRTSUnitList[0].PathTo(nextPositionLeft);
            }
            if (selectedRTSUnitList.Count > 1)
            {
                
            }
        }
    }
    private void DrawSelectionBox(Vector3 boxStart, Vector3 boxEnd)
    {
        Debug.Log("Selecting");
        SelectionBox.SetActive(true);
        Vector3 middle = (boxStart + boxEnd) / 2f;
        float sizeX = Mathf.Abs(boxEnd.x - boxStart.x);
        float sizeY = Mathf.Abs(boxEnd.y - boxStart.y);
        SelectionBox.GetComponent<RectTransform>().position = middle;
        SelectionBox.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX, sizeY);
    }
}
