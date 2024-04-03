using UnityEngine;

public class MoveInCircle : MonoBehaviour
{
    public Transform centerPoint; // Assign center point in the inspector
    public Transform movingObject; // Assign moving object in the inspector

    private float radius; // Store the radius of the circular path
    private float angle = 0f; // Store the angle of the moving object relative to the center point
    private bool isMovingInCircle = false; // Flag to indicate if the moving object is moving in a circle
    private float startingAngle = 0f; // Store the starting angle of the moving object relative to the center point
    private bool hasCompletedCircle = false; // Flag to indicate if the moving object has completed a full circle

    void Start()
    {
        // Calculate the radius of the circular path
        radius = Vector3.Distance(centerPoint.position, movingObject.position);
        startingAngle = Mathf.Atan2(movingObject.position.y - centerPoint.position.y, movingObject.position.x - centerPoint.position.x);
    }

    void Update()
    {
        // Calculate the new position of the moving object
        float x = centerPoint.position.x + radius * Mathf.Cos(angle);
        float y = centerPoint.position.y + radius * Mathf.Sin(angle);
        float z = movingObject.position.z;
        movingObject.position = new Vector3(x, y, z);

        // Update the angle of the moving object
        angle += 2 * Mathf.PI / 360 * Time.deltaTime * 5; // Increment angle by one degree (or one radian) per frame

        // Check if the moving object is moving in a circle
        if (!isMovingInCircle)
        {
            float distanceToCenter = Vector3.Distance(movingObject.position, centerPoint.position);
            if (Mathf.Abs(distanceToCenter - radius) < 0.1f) // Tolerance value of 0.1f
            {
                isMovingInCircle = true;
            }
        }
        else
        {
            // Check if the moving object has completed a full circle
            float currentAngle = Mathf.Atan2(movingObject.position.y - centerPoint.position.y, movingObject.position.x - centerPoint.position.x);
            if (currentAngle < startingAngle)
            {
                currentAngle += 2 * Mathf.PI;
            }
            if (currentAngle - startingAngle >= 2 * Mathf.PI)
            {
                hasCompletedCircle = true;
            }
        }

        // Print the status of the moving object
        if (isMovingInCircle && !hasCompletedCircle)
        {
            Debug.Log("The moving object is moving in a circle.");
        }
        if (hasCompletedCircle)
        {
            Debug.Log("The moving object has completed a full circle.");
        }
    }
}
