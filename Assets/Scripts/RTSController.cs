using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class RTSController : MonoBehaviour
{
    private Vector3 startPosition;
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
    }
}
