using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandAction : MonoBehaviour
{
    private Hand_Tracking_Pos handInfo;
    private string gestureCode;

    public float portalDistance = 10.0f;
    public float portalRadius = 2.0f;
    public float radiusThreshold = 10.0f;
    public float deltaDistanceThreshold = 0.1f;
    public float deltaAngleThreshold = 20.0f;
    public OpenPortalManager portalManager;

    private Vector3 mainCameraForwardVector;
    private Vector3 portalCenterVector;
    public GameObject portalPrefab;
    private GameObject previousGeneratedPortal;
    private GameObject previousLinkedPortal;
    private GameObject generatedPortal;
    private ScoreScript score;
    private lifeScript life;

    private Vector3 previousVector;
    public Vector3 currentVector;
    public Vector3 centerVector;
    private float deltaAngle;
    private float totalAngle;

    public RayCastTracking rayCast;
    public GameObject targetObject;
    public bool grabbingObject = false;
    public float forceMultiplier = 100;
    public float vectorUp = 10;
    public AnimationCurve animationCurve = new AnimationCurve(
                                            new Keyframe(0, 0),
                                            new Keyframe(1, 1)
                                            );

    // Start is called before the first frame update
    void Start()
    {
        handInfo = GetComponent<Hand_Tracking_Pos>();
        rayCast = FindObjectOfType<RayCastTracking>();
        score = FindObjectOfType<ScoreScript>();
        life = FindObjectOfType<lifeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gestureCode = GetComponent<HandGestureTracking>().getGestureCode();

        if (gestureCode == "11100") {
            if (portalManager.openedPortals.Count < 2) {
                trackPortalLine();
            }
        }
        else {
            if (generatedPortal) {
                print("Portal Failed Because Hand Gesture Different");
                resetPortalActivation();
            }

            if (gestureCode == "00111") {
                portalManager.destroyAllPortals();
            }

            if (gestureCode == "11111"){
                score.resetScore();
                life.resetLives();
            }
        }
    }

    private void trackPortalLine() {
        // Get Center Point
        float x = handInfo.HandPoints[21].transform.position.x;
        float y = handInfo.HandPoints[21].transform.position.y;
        float z = handInfo.HandPoints[21].transform.position.z;

        if (!generatedPortal) {
            // Find center target
            mainCameraForwardVector = Camera.main.transform.forward;
            portalCenterVector = Camera.main.transform.position + mainCameraForwardVector * portalDistance;
            centerVector = Camera.main.WorldToScreenPoint(portalCenterVector);

            // Find starting vector
            previousVector = Camera.main.WorldToScreenPoint(new Vector3(x, y, z) + mainCameraForwardVector * portalDistance);
            portalRadius = Vector3.Distance(previousVector, centerVector);

            generatedPortal = Instantiate(portalPrefab, portalCenterVector, Quaternion.identity);
            generatedPortal.transform.LookAt(Camera.main.transform);
            generatedPortal.transform.rotation = Quaternion.Euler(0.0f, generatedPortal.transform.rotation.eulerAngles.y, 0.0f);
        } else {
            currentVector = Camera.main.WorldToScreenPoint(new Vector3(x, y, z) + mainCameraForwardVector * portalDistance);
            float deltaDistance = Vector2.Distance(previousVector - centerVector, currentVector - centerVector);

            if (deltaDistance > deltaDistanceThreshold) {                 
                deltaAngle = Vector2.SignedAngle(previousVector - centerVector, currentVector - centerVector);
               
                if (deltaAngle < deltaAngleThreshold) {
                    totalAngle += deltaAngle;
                    float currentDistanceToCenter = Vector2.Distance(currentVector, centerVector);

                    if (Mathf.Abs(currentDistanceToCenter - portalRadius) < radiusThreshold) {
                        if (Mathf.Abs(totalAngle) < 360f) {
                            previousVector = currentVector;
                            generatedPortal.GetComponentInChildren<PortalBehaviour>().Enlarge(totalAngle);
                        } else {
                            print("Portal Completed");
                            portalCenterVector = Vector3.zero;
                            centerVector = Vector3.zero;
                            previousVector = Vector3.zero;
                            portalRadius = 0.0f;
                            deltaAngle = 0.0f;
                            totalAngle = 0.0f;
                            generatedPortal.GetComponentInChildren<PortalBehaviour>().portalFullyActivate();

                            portalManager.addPortalToList(generatedPortal);

                            generatedPortal = null;
                        }
                    } else {
                        print("Portal Failed Because Not Moving in Circle");
                        resetPortalActivation();
                    }
                } else {
                    print("Portal Failed Because Delta Angle Above Threshold");
                    resetPortalActivation();
                }
            }
        }
    }

    private void resetPortalActivation() {
        portalCenterVector = Vector3.zero;
        centerVector = Vector3.zero;
        previousVector = Vector3.zero;
        portalRadius = 0.0f;
        deltaAngle = 0.0f;
        totalAngle = 0.0f;
        generatedPortal.GetComponentInChildren<PortalBehaviour>().portalDestruct();
    }
}
