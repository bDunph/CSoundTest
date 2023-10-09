using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeData : MonoBehaviour
{
    CsoundUnity csound;

    void Start()
    {
        csound = GetComponent<CsoundUnity>();
    }

    void Update()
    {
        if (!csound.IsInitialized) return;

        //Debug.Log("Csound active: " + csound.IsInitialized);
        Vector3 mouse = Input.mousePosition;
        //Debug.Log(mouse.x + ", " + mouse.y + ", " + mouse.z);
        //float mouseVal = mouse.y / mouse.x;
        float mouseVal = mouse.y;
        //Debug.Log("Mouse val: " + mouseVal);
        float mappedMouseVal = Map(mouseVal, -374.0f, 525.0f, 5.0f, 50.0f);
        Debug.Log("Mapped mouse: " + mappedMouseVal);
        csound.SetChannel("modFreq", mappedMouseVal);
    }

    public float Map(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        // Ensure the value is within the source range
        value = Mathf.Clamp(value, fromMin, fromMax);

        // Calculate the normalized position of the value within the source range
        float normalizedValue = (value - fromMin) / (fromMax - fromMin);

        // Map the normalized value to the target range
        float mappedValue = Mathf.Lerp(toMin, toMax, normalizedValue);

        return mappedValue;
    }


}
