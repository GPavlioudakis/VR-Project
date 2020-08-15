using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TargetTracking : MonoBehaviour
{
    public GameObject target;
    Renderer spriteRenderer;

    void Start()
    {
        //Gets the marker renderer and deactivates it
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        if (target.transform.childCount > 0)//Checks if there are any objects loaded
        {
            if (IsTargetVisible(target))//Checks if target is visible
            {
                spriteRenderer.enabled = false;//Deactivates the marker
            }
            else
            {
                spriteRenderer.enabled = true;//Activates the market
                TrackTarget(target);//Tracks the target
            }
        }
    }

    bool IsTargetVisible(GameObject target)
    {
        
        Renderer targetRenderer = target.GetComponentInChildren<Renderer>();
        return targetRenderer.isVisible;
    }

    void TrackTarget(GameObject target)
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 targetPositionFromCamera = targetPosition - Camera.main.transform.position;//Target position relative to camera position

        //Projection of target position (relative to camera) on camera's X and Y axes
        Vector3 camYproj = Vector3.Project(targetPositionFromCamera, Camera.main.transform.up);
        Vector3 camXproj = Vector3.Project(targetPositionFromCamera, Camera.main.transform.right);
        Vector3 targetTracker = camXproj + camYproj;

        transform.LookAt(Camera.main.transform.position, Vector3.up);//Billboard marker sprite

        float angle = Vector3.SignedAngle(-Camera.main.transform.up, targetTracker, transform.forward);//Angle of tracking vector in camera's XY plane

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);//Rotating marker around its local z axis only

        transform.position = Camera.main.transform.position + 0.5f * Camera.main.transform.forward + 0.2f * targetTracker.normalized;//Placing marker in front of camera
    }
}
