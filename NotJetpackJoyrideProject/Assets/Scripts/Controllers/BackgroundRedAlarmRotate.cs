using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BackgroundRedAlarmRotate : MonoBehaviour
{
    [SerializeField] private Light2D lightReflectTop = default;
    [SerializeField] private Light2D lightReflectBot = default;

    private const float changeSpeed = 20.0f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 150.0f);

        Debug.Log(transform.localRotation.eulerAngles.z);

        if (transform.localRotation.eulerAngles.z > 315.0f && transform.localRotation.eulerAngles.z <= 360)
        {// Top Right
            lightReflectTop.intensity += Time.deltaTime * changeSpeed;
            lightReflectTop.intensity = Mathf.Clamp(lightReflectTop.intensity, 0.0f, 10.0f);
        }
        else if (transform.localRotation.eulerAngles.z > 35.0f)
        {// Top Left
            lightReflectTop.intensity -= Time.deltaTime * changeSpeed;
            lightReflectTop.intensity = Mathf.Clamp(lightReflectTop.intensity, 0.0f, 10.0f);
        }

        if (transform.localRotation.eulerAngles.z > 135 && transform.localRotation.eulerAngles.z <= 180.0f)
        {// Bot Right
            lightReflectBot.intensity += Time.deltaTime * changeSpeed;
            lightReflectBot.intensity = Mathf.Clamp(lightReflectBot.intensity, 0.0f, 10.0f);
        }
        else if (transform.localRotation.eulerAngles.z > 215.0f)
        {// Bot Left
            lightReflectBot.intensity -= Time.deltaTime * changeSpeed;
            lightReflectBot.intensity = Mathf.Clamp(lightReflectBot.intensity, 0.0f, 10.0f);
        }
    }
}