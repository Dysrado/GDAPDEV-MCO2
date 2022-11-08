using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] float lookSensitivity = 0.5f;
    Vector3 lookRotation;
    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnDrag += OnDrag;
        lookRotation = new Vector3(0,-90,0);
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnDrag -= OnDrag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrag(object sender, DragEventArgs e)
    {
        //Debug.Log(e.TargetFinger.deltaPosition.x);
        //if (e.TargetFinger.deltaPosition.x > 0)
        //{
        //    lookRotation.y -= lookSensitivity * Time.deltaTime;
        //}
        //else if (e.TargetFinger.deltaPosition.x < 0)
        //{
        //    lookRotation.y += lookSensitivity * Time.deltaTime;
        //}
        
        //if (e.TargetFinger.deltaPosition.y > 0)
        //{
        //    lookRotation.x += lookSensitivity * Time.deltaTime;
        //}
        //else if (e.TargetFinger.deltaPosition.y < 0)
        //{
        //    lookRotation.x -= lookSensitivity * Time.deltaTime;
        //}
        lookRotation += new Vector3(e.TargetFinger.deltaPosition.y * lookSensitivity * Time.deltaTime,
            -e.TargetFinger.deltaPosition.x * lookSensitivity * Time.deltaTime,
            0);
        transform.eulerAngles = lookRotation;
    }
}
