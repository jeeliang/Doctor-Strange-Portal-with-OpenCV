using System.Collections;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    private Vector3 originalScale;
    public Vector3 initialScale;
    public Vector3 enlargeScale;
    private Vector3 previousScale;
    public AnimationCurve animationCurve = new AnimationCurve(
                                            new Keyframe(0, 0),
                                            new Keyframe(1, 1)
                                            );
    public GameObject parent;
    public bool activated;
    private bool partialOpened = false;

    void Start() {
        if (!activated)
            StartCoroutine(activate(0.5f));
        else
            this.transform.localScale=initialScale+enlargeScale;
    }

    public void portalDestruct() {
        StartCoroutine(deactivate(0.5f));
    }

    public void portalFullyActivate() {
        // StartCoroutine(activate(false, 1.0f));
        activated = true;
    }

    private IEnumerator activate(float duration) {
        previousScale = new Vector3(0.0f, 0.0f, 0.0f);
        originalScale = initialScale;

        float journey = 0f;
        while (journey <= duration) {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);
            float curvePercent = animationCurve.Evaluate(percent);

            this.transform.localScale = Vector3.LerpUnclamped(previousScale, originalScale, curvePercent);

            yield return null;
        }

        partialOpened = true;
    }

    private IEnumerator deactivate(float duration) {
        previousScale = new Vector3(0.0f, 0.0f, 0.0f);
        originalScale = this.transform.localScale;

        float journey = 0f;
        while (journey <= duration) {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);
            float curvePercent = animationCurve.Evaluate(percent);

            this.transform.localScale = Vector3.LerpUnclamped(originalScale, previousScale, curvePercent);

            yield return null;
        }

        Destroy(parent);
    }

    public void Enlarge(float progress) {
        if (!activated) {
            if (partialOpened) {
                previousScale = initialScale;
                originalScale = previousScale + enlargeScale;

                float percent = Mathf.Clamp01(Mathf.Abs(progress) / 360f);

                this.transform.localScale = Vector3.LerpUnclamped(previousScale, originalScale, percent);
            }
        }
    }
}
