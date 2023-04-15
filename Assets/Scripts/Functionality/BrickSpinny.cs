using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpinny : MonoBehaviour
{
    // Rotation
    public float rotationSpeed = 120;
    public float rotationDirection = 1;

    // Scale
    Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatable;
    public float scaleSpeed = 2f;
    public float scaleDuration = 5f;

    // This will be called once
    IEnumerator Start()
    {
        minScale = transform.localScale;

        while (repeatable)
        {
            // Lerp up scale
            yield return RepeatLerp(minScale, maxScale, scaleDuration);

            // Lerp down scale
            yield return RepeatLerp(maxScale, minScale, scaleDuration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed * rotationDirection);

        // Scale
        transform.localScale = Vector3.one * Time.deltaTime * scaleSpeed * rotationDirection;

    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * scaleSpeed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
 
}
