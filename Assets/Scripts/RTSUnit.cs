using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnit : MonoBehaviour
{
    private float speed = (float)0.1 * 3;
    private GameObject selectedGameObject;
    private Vector3 MovementStart;
    private Vector3 MovementDestination;
    private bool Moving;
    private void Awake()
    {
        selectedGameObject = transform.Find("selected").gameObject;
        SetSelectedVisible(false);
    }
    private void Start()
    {
        MovementDestination = transform.position;
    }
    private void Update()
    {
        if (Moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, MovementDestination, Time.deltaTime*speed);
            if(MovementDestination == transform.position)
            {
                Debug.Log("Done Moving");
                Moving = false;
            }
        }
    }
    public void SetSelectedVisible(bool visible)
    {
        selectedGameObject.SetActive(visible);
    }
    public void PathTo(Vector3 destination)
    {
        MovementStart = transform.position;
        MovementDestination = destination;
        Moving = true;
    }
}
