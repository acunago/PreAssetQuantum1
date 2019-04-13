using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;

    [SerializeField]
    private float compensationOffset = 0.2f;
    private Vector3[] viewFrustum;

    // Use this for initialization
    void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {



    }

    //private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
    //{
    //    // Compensate for walls between camera
    //    RaycastHit wallHit = new RaycastHit();
    //    if (Physics.Linecast(fromObject, toTarget, out wallHit))
    //    {
    //        Debug.DrawRay(wallHit.point, wallHit.normal, Color.red);
    //        toTarget = wallHit.point;
    //    }

    //    // Compensate for geometry intersecting with near clip plane
    //    Vector3 camPosCache = transform.position;
    //     transform.position = toTarget;


    //    for (int i = 0; i < (viewFrustum.Length / 2); i++)
    //    {
    //        RaycastHit cWHit = new RaycastHit();
    //        RaycastHit cCWHit = new RaycastHit();

    //        // Cast lines in both directions around near clipping plane bounds
    //        while (Physics.Linecast(viewFrustum[i], viewFrustum[(i + 1) % (viewFrustum.Length / 2)], out cWHit) ||
    //               Physics.Linecast(viewFrustum[(i + 1) % (viewFrustum.Length / 2)], viewFrustum[i], out cCWHit))
    //        {
    //            Vector3 normal = wallHit.normal;
    //            if (wallHit.normal == Vector3.zero)
    //            {
    //                // If there's no available wallHit, use normal of geometry intersected by LineCasts instead
    //                if (cWHit.normal == Vector3.zero)
    //                {
    //                    if (cCWHit.normal == Vector3.zero)
    //                    {
    //                        Debug.LogError("No available geometry normal from near clip plane LineCasts. Something must be amuck.", this);
    //                    }
    //                    else
    //                    {
    //                        normal = cCWHit.normal;
    //                    }
    //                }
    //                else
    //                {
    //                    normal = cWHit.normal;
    //                }
    //            }

    //            toTarget += (compensationOffset * normal);
    //            transform.position += toTarget;

    //            // Recalculate positions of near clip plane

    //        }
    //    }

    //    transform.position = camPosCache;

    //}
}
