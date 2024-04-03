using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldtoScreen : MonoBehaviour
{
    public Transform cube0;
    public Transform cube1;
    public Transform cube2;
    public Vector3 screenSpaceCube0;
    public Vector3 screenSpaceCube1;
    public Vector3 screenSpaceCube2;
    public Vector3 previousSpaceCube1 = Vector3.zero;
    public float distanceSpace;
    public float distanceToCenterPoint;
    public float angle;
    public float testAngl;
    public float totalAngle;
    // Update is called once per frame
    void Update()
    {
        screenSpaceCube0 = Camera.main.WorldToScreenPoint(cube0.position);
        screenSpaceCube1 = Camera.main.WorldToScreenPoint(cube1.position);
        screenSpaceCube2 = Camera.main.WorldToScreenPoint(cube2.position);
        
        if (previousSpaceCube1 == Vector3.zero)
            previousSpaceCube1 = screenSpaceCube1;
        
        distanceSpace = Vector3.Distance(previousSpaceCube1 - screenSpaceCube0, screenSpaceCube1 - screenSpaceCube0);

        if (distanceSpace > 0.1f) {
            angle = Vector2.SignedAngle(previousSpaceCube1 - screenSpaceCube0, screenSpaceCube1 - screenSpaceCube0);
            testAngl += angle;
            previousSpaceCube1 = screenSpaceCube1;
        }
        distanceToCenterPoint = Vector3.Distance(screenSpaceCube1, screenSpaceCube0);
        
        totalAngle = Vector2.SignedAngle(screenSpaceCube2 - screenSpaceCube0, screenSpaceCube1 - screenSpaceCube0);
    }
}
