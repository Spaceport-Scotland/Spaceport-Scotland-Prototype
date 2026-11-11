// pulses the intensity of the item's child lights while the item is being dragged
using UnityEngine;

public class GlowEffect : ItemReactionEffect
{
    // the lowest and highest light intensities during the pulse
    public float minimumIntensity = 0.5f;
    public float maximumIntensity = 100f;

    // controls how quickly the light changes intensity
    public float pulseSpeed = 1f;

    // stores the lights and their original intensities
    private Light[] pointLights;
    private float[] startingIntensities;
    private bool isPulsing;

    private void Awake()
    {
        // find the lights on this item and its children
        pointLights = GetComponentsInChildren<Light>();
        startingIntensities = new float[pointLights.Length];

        // save each light's intensity so it can be restored later
        for (int i = 0; i < pointLights.Length; i++)
        {
            startingIntensities[i] = pointLights[i].intensity;
        }

        if (pointLights.Length == 0)
        {
            Debug.LogError("No active child lights were found for the glow effect.");
        }
    }

    private void Update()
    {
        // do nothing until the item is picked up
        if (!isPulsing)
        {
            return;
        }

        // create a value that moves up and down between 0 and 1
        float pulse = Mathf.PingPong(Time.time * pulseSpeed, 1f);

        // use that value to move the lights between the minimum and maximum intensities
        float intensity = Mathf.Lerp(minimumIntensity, maximumIntensity, pulse);

        // for each light, set its intensity to the calculated value
        for (int i = 0; i < pointLights.Length; i++)
        {
            if (pointLights[i] != null)
            {
                pointLights[i].intensity = intensity;
            }
        }
    }

    public override void OnPickedUp()
    {
        // start changing the light intensity
        isPulsing = true;
    }

    public override void OnReleased()
    {
        // stop the pulse and restore the lights to their original intensities
        isPulsing = false;

        for (int i = 0; i < pointLights.Length; i++)
        {
            if (pointLights[i] != null)
            {
                pointLights[i].intensity = startingIntensities[i];
            }
        }
    }
}
