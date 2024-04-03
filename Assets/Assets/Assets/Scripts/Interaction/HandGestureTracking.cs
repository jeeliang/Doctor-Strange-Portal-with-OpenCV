using System.Collections.Generic;
using UnityEngine;

public class HandGestureTracking : MonoBehaviour
{
    private Hand_Tracking_Pos handInfo;
    private string gestureCode = "";
    // Start is called before the first frame update
    void Start()
    {
        handInfo = GetComponent<Hand_Tracking_Pos>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int counter = 0; counter < handInfo.handData.fingersUp.Count; counter++) {
            if (counter == 0)
                gestureCode = "";

            gestureCode += handInfo.handData.fingersUp[counter].ToString();
        }

        // if (gestureCode != "") {
        //     string firstSplitString = gestureCode.Substring(1);
        //     string[] splitString = firstSplitString.Split('1');

        //     numOf0 = 0;

        //     for (int counter = 0; counter < splitString.Length; counter++) {
        //         numOf0 += splitString[counter].Length;
        //     }

        //     if (gestureCode.StartsWith("0") || numOf0 > 0) {
        //         if (interactPoints[0].getInteracted()) {
        //             for (int counter = 1; counter < interactPoints.Length; counter++) {
        //                 if (interactPoints[counter].getInteracted()) {
        //                     interactIndex = counter;
        //                 }
        //             }

        //             Vector3 firstPosition = Camera.main.WorldToScreenPoint(interactPoints[0].transform.position);
        //             Vector3 lastPosition = Camera.main.WorldToScreenPoint(interactPoints[interactIndex].transform.position);
        //             Vector3 centerPosition = Camera.main.WorldToScreenPoint(point0.transform.position);
        //             Vector3 middlePosition = new Vector3((firstPosition.x + lastPosition.x) / 2,
        //                                                  (firstPosition.y + lastPosition.y) / 2,
        //                                                  (firstPosition.z + lastPosition.z) / 2);
                    
        //             angle = Vector3.Angle(centerPosition + Vector3.right, middlePosition - centerPosition);
        //         }
        //     }
        // }
    }

    public string getGestureCode() {
        return gestureCode;
    }
}
