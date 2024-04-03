using UnityEngine;

public class Hand_Tracking : MonoBehaviour
{
    public UDP_Receiver udpReceive;
    public GameObject fHand;
    public GameObject sHand;
    public GameObject[] fHandPoints;
    public GameObject[] sHandPoints;

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
        
        if (data.Length != 0) {
            Hands handData = JsonUtility.FromJson<Hands>(data);

            for (int counter = 0; counter < handData.hands.Count; counter++) {
                if (handData.hands[counter].type == "Left") {
                    fHand.GetComponent<Hand_Tracking_Pos>().handData.lmList = handData.hands[counter].lmList;
                    fHand.GetComponent<Hand_Tracking_Pos>().handData.center = handData.hands[counter].center;
                    fHand.GetComponent<Hand_Tracking_Pos>().handData.distance = handData.hands[counter].distance;
                    fHand.GetComponent<Hand_Tracking_Pos>().handData.fingersUp = handData.hands[counter].fingersUp;
                    fHand.GetComponent<Hand_Tracking_Pos>().handData.type = handData.hands[counter].type;
                    fHand.GetComponent<Hand_Tracking_Pos>().updatePosition();
                } else {
                    sHand.GetComponent<Hand_Tracking_Pos>().handData.lmList = handData.hands[counter].lmList;
                    sHand.GetComponent<Hand_Tracking_Pos>().handData.center = handData.hands[counter].center;
                    sHand.GetComponent<Hand_Tracking_Pos>().handData.distance = handData.hands[counter].distance;
                    sHand.GetComponent<Hand_Tracking_Pos>().handData.fingersUp = handData.hands[counter].fingersUp;
                    sHand.GetComponent<Hand_Tracking_Pos>().handData.type = handData.hands[counter].type;
                    sHand.GetComponent<Hand_Tracking_Pos>().updatePosition();
                }
            }

            // for (int counter = 0; counter < handData.hands.Count; counter++)
            // {
            //     // IMPORTANT: with_distance_version [START HERE]
            //     float distance = handData.hands[counter].distance / 5; // IMPORTANT: May adjust based on preference
            //     float distanceZ = 20 - distance; // IMPORTANT: May adjust based on preference
            //     float scale = distance / 5; // IMPORTANT: May adjust based on preference

            //     if (handData.hands[counter].type == "Left") {
            //         fHand.transform.localPosition = new Vector3(fHand.transform.localPosition.x, fHand.transform.localPosition.y, distanceZ);
            //         fHand.transform.localScale = new Vector3(scale, scale, -1 * scale);
            //     } else {
            //         sHand.transform.localPosition = new Vector3(sHand.transform.localPosition.x, sHand.transform.localPosition.y, distanceZ);
            //         sHand.transform.localScale = new Vector3(scale, scale, -1 * scale);
            //     }
            //     // IMPORTANT: with_distance_version [END HERE]

            //     for (int i = 0; i < 21; i++) {
            //         float x = 8 - (float)handData.hands[counter].lmList[i*3] / 80;
            //         float y = (float)handData.hands[counter].lmList[i*3+1] / 80 - 5;
            //         float z = (float)handData.hands[counter].lmList[i*3+2] / 80;

            //         if (handData.hands[counter].type == "Left") {
            //             fHandPoints[i].transform.localPosition = new Vector3(x, y, z);
            //         } else {
            //             sHandPoints[i].transform.localPosition = new Vector3(x, y, z);
            //         }
            //     }
            // }
        }
    }
}
