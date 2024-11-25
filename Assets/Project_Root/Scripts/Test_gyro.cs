using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Test_gyro : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion rot;
    [SerializeField] public GameObject camHolder;

    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        /*cameraHolder = new GameObject("CameraHolder");
        cameraHolder.transform.position = transform.position;
        transform.SetParent(cameraHolder.transform);*/
        gyroEnabled = EnableGyro();

    }

    // Update is called once per frame
    void Update()
    {

        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
    }


    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            camHolder.transform.rotation = Quaternion.Euler(90f,90f,0);
            rot = new Quaternion(0, 0, 1, 0);

            return true;

        }
        return false;
    }
}
