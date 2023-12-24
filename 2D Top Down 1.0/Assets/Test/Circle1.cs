using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle1 : MonoBehaviour
{
    public Vector3 currentRotation;
    public Vector3 anglesToRotate;
    private void Awake()
    {
        currentRotation = new Vector3(currentRotation.x % 360f, currentRotation.y % 360f, currentRotation.z % 360f);
        //transform.eulerAngles = currentRotation;

       
    }
    private void Update()
    {
        //Transform.position :
        //transform.position += new Vector3(0f, 2.0f, 0f) * Time.deltaTime;
        //transform.localPosition += new Vector3(0f, 2.0f, 0f) * Time.deltaTime;

        //Transform.Translate() :
        //transform.Translate(new Vector3(0f, 2f, 0f) * Time.deltaTime, Space.World);
        //transform.Translate(new Vector3(0f, 2f, 0f) * Time.deltaTime, transform.parent);

        //EulerAngles : Rotation
        //currentRotation += anglesToRotate  * Time.deltaTime;
        //currentRotation = new Vector3(currentRotation.x % 360.0f , currentRotation.y % 360.0f,currentRotation.z % 360.0f);
        //transform.eulerAngles = currentRotation;

        //Quaternion Rotation :
        Quaternion RotationX = Quaternion.AngleAxis(anglesToRotate.x * Time.deltaTime, new Vector3(1f, 0f, 0f));
        Quaternion RotationY = Quaternion.AngleAxis(anglesToRotate.y * Time.deltaTime, new Vector3(0f, 1f, 0f));
        Quaternion RotationZ = Quaternion.AngleAxis(anglesToRotate.z * Time.deltaTime, new Vector3(0f, 0f, 1f));

       
        //Debug.Log(RotationZ);

        transform.rotation *= RotationX * RotationY * RotationZ;

    }
}
