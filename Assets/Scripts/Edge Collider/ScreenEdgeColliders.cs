using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgeColliders : MonoBehaviour
{
    public GameObject leftCollider; 
    public GameObject rightCollider; 

    private void Start()
    {
        Vector3 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        Vector3 leftPosition = new Vector3(screenBottomLeft.x, (screenBottomLeft.y + screenTopRight.y) / 2, 0);
        Vector3 rightPosition = new Vector3(screenTopRight.x, (screenBottomLeft.y + screenTopRight.y) / 2, 0);

        if (leftCollider != null)
        {
            leftCollider.transform.position = leftPosition;

            
        }

        if (rightCollider != null)
        {
            rightCollider.transform.position = rightPosition;

           
        }
    }
}
