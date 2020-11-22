using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnit : MonoBehaviour
{
    private float speed = 0.1f * 3;
    private GameObject selectedGameObject;
    private Vector3 MovementStart;
    private Vector3 MovementDestination;
    private Quaternion RotationDestination;
    private float RotationAngle = 0;
    private bool Moving;
    private bool Rotating;
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
        if (Rotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,RotationDestination, speed*100 * Time.deltaTime);
            if (transform.rotation == RotationDestination)
            {
                Rotating = false;
                Debug.Log("Done Rotating");
            }
        }
        if (Moving && (!Rotating || RotationAngle<40))
        {
            transform.position = Vector3.MoveTowards(transform.position, MovementDestination, speed * Time.deltaTime);
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
        Vector3 targetDirection = MovementDestination - MovementStart;
        RotationDestination = Quaternion.LookRotation(Vector3.forward, targetDirection);
        RotationAngle = Quaternion.Angle(RotationDestination,transform.rotation);
        Debug.Log("Moving");
        Rotating = true;
        Moving = true;
    }
}
