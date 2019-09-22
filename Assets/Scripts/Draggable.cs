using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public const float SPEED = 0.2f;
    public const float ANGLE_FACTOR = 1f;
    public const float TILL_HEIGHT = 11f;
    public static Draggable dragged;

    public float currency;

    public Vector2 targetPosition;
    private Vector3 velocity;
    public float angle;
    private float angleVelocity;


    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (dragged == this)
            {
                dragged = null;
                if (currency > 0f && targetPosition.y <= -TILL_HEIGHT)
                {
                    Destroy(gameObject);
                }
            }
        }
        if (dragged == this)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector3 oldPos = transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SPEED);

        if (dragged == this)
        {
            angle = (oldPos.x - transform.position.x) / ANGLE_FACTOR / Time.deltaTime;
        }
        
        float z = Mathf.SmoothDampAngle(transform.eulerAngles.z, angle, ref angleVelocity, SPEED);
        transform.eulerAngles = new Vector3(0f, 0f, z);
    }

    private void OnMouseDown()
    {
        dragged = this;
    }


}
