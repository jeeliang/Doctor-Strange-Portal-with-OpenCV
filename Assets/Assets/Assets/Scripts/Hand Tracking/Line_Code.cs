using UnityEngine;

public class Line_Code : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform origin;
    public Transform dest;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
    }

    void Update()
    {
        lineRenderer.SetPosition(0, origin.localPosition);
        lineRenderer.SetPosition(1, dest.localPosition);
    }
}
