//https://answers.unity.com/questions/1189946/click-and-drag-to-rotate-camera-like-a-pan.html

using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour
{
    public float speed = 3.5f;
    private float X;
    private float Y;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
    }
}