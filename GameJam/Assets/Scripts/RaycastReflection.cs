using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

[RequireComponent(typeof(LineRenderer))]
public class RaycastReflection : MonoBehaviour
{
    public int reflections;
    public float maxLength;

    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        float remainingLength = maxLength;

        for(int i = 0; i < reflections; i++)
        {
            int layerMask = 1 << LayerMask.NameToLayer("Mirror");
            if(Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength, layerMask))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

                Vector3 pos1 = lineRenderer.GetPosition(i);
                Vector3 pos2 = lineRenderer.GetPosition(i + 1);

                LineCollider(pos1, pos2, i);

                if (hit.collider.tag != "Mirror")
                {
                    break;
                }
            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);

                Vector3 pos1 = lineRenderer.GetPosition(i);
                Vector3 pos2 = lineRenderer.GetPosition(i + 1);
                LineCollider(pos1, pos2, i);
            }
        }
    }

    public void LineCollider(Vector3 start, Vector3 end, int index)
    {
        GameObject box = transform.GetChild(index).gameObject;
        GameObject light = transform.parent.GetChild(index + 1).gameObject;

        if(Vector3.Distance(start, end) <= 0)
        {
            box.GetComponent<MeshRenderer>().enabled = false;
            box.GetComponent<BoxCollider>().enabled = false;
            light.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            box.GetComponent<MeshRenderer>().enabled = true;
            box.GetComponent<BoxCollider>().enabled = true;
            light.GetComponent<MeshRenderer>().enabled = true;

            box.transform.localScale = new Vector3(1, 1, Vector3.Distance(start, end) / 2 + 0.5f);
            box.transform.position = (start + end) / 2;
            box.transform.LookAt(end);
            box.transform.position += new Vector3(0, -0.5f, 0);

            VolumetricLineStripBehavior lightScript = light.GetComponent<VolumetricLineStripBehavior>();
            lightScript.LineVertices[0] = start - transform.position;
            lightScript.LineVertices[1] = ((start + end) / 2) - transform.position;
            lightScript.LineVertices[2] = end - transform.position;
            lightScript.LineWidth = 1.5f;
        }
    }
}
