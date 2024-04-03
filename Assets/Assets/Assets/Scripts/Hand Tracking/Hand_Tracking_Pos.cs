using UnityEngine;

public class Hand_Tracking_Pos : MonoBehaviour
{
    public Hand handData;
    public GameObject[] HandPoints;
    public int adjustX = 12;
    public int adjustY = 5;

    // Update is called once per frame
    public void updatePosition()
    {
        // IMPORTANT: with_distance_version [START HERE]
        float distance = handData.distance / 5; // IMPORTANT: May adjust based on preference
        float distanceZ = 20 - distance; // IMPORTANT: May adjust based on preference
        float scale = distance / 5; // IMPORTANT: May adjust based on preference

        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, distanceZ);
        this.transform.localScale = new Vector3(scale, scale, -1 * scale);
        // IMPORTANT: with_distance_version [END HERE]

        for (int i = 0; i < 21; i++) {
            float x = adjustX - (float)handData.lmList[i*3] / 80;
            float y = (float)handData.lmList[i*3+1] / 80 - adjustY;
            float z = (float)handData.lmList[i*3+2] / 80;

            HandPoints[i].transform.localPosition = new Vector3(x, y, z);
        }

        float centerX = adjustX - (float)handData.center[0] / 80;
        float centerY = (float)handData.center[1] / 80 - adjustY;

        HandPoints[21].transform.localPosition = new Vector3(centerX, centerY, HandPoints[7].transform.localPosition.z);

        // string fingersUpString = "";

        // for (int counter = 0; counter < handData.fingersUp.Count; counter++) {
        //     fingersUpString += handData.fingersUp[counter].ToString();
        // }   

        // if (portalDraw) {
        //     if (fingersUpString == "11001" || fingersUpString == "01001" || fingersUpString == "11111") {
        //         portalLineDraw.drawPortal(handData.center[0], handData.center[1], HandPoints[7].transform.position.z);
        //     }
        //     else {
        //         portalLineDraw.stopPortal();
        //     }
        // }
    }
}

