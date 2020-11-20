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

    private void Awake()
    {
        selectedRTSUnitList = new List<RTSUnit>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Left mouse Button press
            startPosition = UtilsClass.GetMouseWorldPosition();
        }
        if (Input.GetMouseButtonUp(0))
        {
            //left Mouse Button Released
         
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, UtilsClass.GetMouseWorldPosition());
          
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
        if (Input.GetMouseButtonDown(1))
        {
            nextPositionLeft = UtilsClass.GetMouseWorldPosition();
            
        }
        if (Input.GetMouseButtonUp(1))
        {
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
}
