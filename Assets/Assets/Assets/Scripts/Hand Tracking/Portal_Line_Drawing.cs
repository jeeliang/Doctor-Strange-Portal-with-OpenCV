using UnityEngine;

public class Portal_Line_Drawing : MonoBehaviour
{
    private Hand_Tracking_Pos handTrackPos;
    private Camera mainCam;
    private Vector3 forwardVector;
    public GameObject portalPrefab;
    public GameObject generatedPortal;

    private Vector3 targetPosition;
    private Vector3 centerPosition;

    public float radiusThreshold = 0.2f;
    public float radius;
    public float angle = 0.0f;
    public bool isMovingInCircle = false;
    public float startingAngle = 0.0f;
    public bool hasCompletedCircle = false;


    // Start is called before the first frame update
    void Awake()
    {
        handTrackPos = GetComponent<Hand_Tracking_Pos>();
        mainCam = Camera.main;
    }

    void Update() {
        forwardVector = mainCam.transform.forward;
    }

    public void drawPortal(float centerX, float centerY, float centerZ) {
        if (!generatedPortal) {
            centerPosition = mainCam.transform.position + forwardVector * 10f;
            targetPosition = new Vector3(centerX, centerY, centerZ) + forwardVector * 10f;
            radius = Vector3.Distance(centerPosition, targetPosition);
            startingAngle = Mathf.Atan2(targetPosition.y - centerPosition.y, targetPosition.x - centerPosition.x);
        } else {
            
        }
    }

    public void checkAngle(Vector3 dest) {
        
    }

    public void stopPortal() {
    }

    private void resetPortalDrawing() {
    }
}