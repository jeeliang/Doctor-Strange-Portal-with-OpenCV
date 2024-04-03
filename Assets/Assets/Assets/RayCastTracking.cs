using UnityEngine;

public class RayCastTracking : MonoBehaviour
{
    private Camera mainCam;
    public int layerBit;
    public GameObject currPointedObj;
    public float rayCastDistance = 10f;

    void Start() {
        mainCam = Camera.main;
    }

    void FixedUpdate()
    {
        int layerMask = 1 << layerBit;

        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, rayCastDistance, layerMask)) {
            if (hit.collider.gameObject.CompareTag("Ball")) {
                currPointedObj = hit.collider.gameObject;
            } else {
                currPointedObj = null;
            }
        }
    }

    public GameObject getCurrPointedObject() {
        return currPointedObj;
    }
}
