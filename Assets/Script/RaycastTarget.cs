using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTarget : MonoBehaviour
{
    public LayerMask layerMask;
    private RaycastHit hit;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*20, Color.green);
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, layerMask))
        {
            hit.collider.gameObject.GetComponent<Enemy>().Hit();
        }
    }
}
