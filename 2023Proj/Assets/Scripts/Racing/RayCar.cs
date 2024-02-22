using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCar : MonoBehaviour
{
    [Range(0, 50)]
    public float distance = 10.0f;
    private RaycastHit rayHit, rayHitLeft, rayHitRight;
    private Ray ray, rayLeft, rayRight;
    
    void Start()
    {
        //ray 에 대한 설정
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        rayRight = new Ray();
        rayRight.origin = this.transform.position;
        rayRight.direction = Quaternion.Euler(0, 45, 0) * this.transform.forward; 

        rayLeft = new Ray();
        rayLeft.origin = this.transform.position;
        rayLeft.direction = Quaternion.Euler(0, -45, 0) * this.transform.forward;
    }

    void Update()
    {
        Ray();
    }

    void Ray()
    {
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
        rayRight.origin = this.transform.position;
        rayRight.direction = Quaternion.Euler(0, -45, 0) * this.transform.forward;
        rayLeft.origin = this.transform.position;
        rayLeft.direction = Quaternion.Euler(0, 45, 0) * this.transform.forward;

        Physics.Raycast(ray.origin, ray.direction, out rayHit, distance);
        Physics.Raycast(rayLeft.origin, rayLeft.direction, out rayHitLeft, distance);
        Physics.Raycast(rayRight.origin, rayRight.direction, out rayHitRight, distance);

        if ((rayHit.collider.gameObject.layer == LayerMask.NameToLayer("Wall")))
        {
            if (rayHitRight.distance < rayHitLeft.distance)
            {
                transform.Rotate(Vector3.up * 50 * Time.deltaTime);
            }
            else if (rayHitRight.distance > rayHitLeft.distance)
            {
                transform.Rotate(Vector3.up * -50 * Time.deltaTime);
            }
        }

        if (rayHitRight.distance < rayHitLeft.distance)
        {
            transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        }
        else if(rayHitRight.distance > rayHitLeft.distance)
        {
            transform.Rotate(Vector3.up * -50 * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(ray.origin, ray.direction * distance + ray.origin);
        Gizmos.DrawLine(rayLeft.origin, rayLeft.direction * distance + rayLeft.origin);
        Gizmos.DrawLine(rayRight.origin, rayRight.direction * distance + rayRight.origin);

        // : Collision Point 
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.rayHit.point, 0.1f);
        Gizmos.DrawSphere(this.rayHitLeft.point, 0.1f);
        Gizmos.DrawSphere(this.rayHitRight.point, 0.1f);
    }
}