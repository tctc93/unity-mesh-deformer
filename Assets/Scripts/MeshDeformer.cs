using UnityEngine;
using UnityEngine.EventSystems;

public class MeshDeformer : MonoBehaviour
{
    public float deformStrength = 5f;
    public float deformRadius = 3f;
    public bool raiseMode = true;

    private GameObject targetDeformObject;
    private Mesh targetDeformMesh;
    private Vector3[] originalVertices;
    private Vector3[] deformedVertices;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Init starting variables
        var meshFilter = GetComponentInChildren<MeshFilter>();
        targetDeformMesh = meshFilter.mesh;
        targetDeformObject = meshFilter.gameObject;
        originalVertices = targetDeformMesh.vertices;
        deformedVertices = targetDeformMesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        // Detection of left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // If the mouse is over UI, ignore deformation
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                DeformMesh(hit.point);
            }
        }
    }

    public void ResetMesh()
    {
        originalVertices.CopyTo(deformedVertices, 0);
        ApplyMeshToTarget(deformedVertices);
    }

    private void DeformMesh(Vector3 hitPoint)
    {
        for (var i = 0; i < deformedVertices.Length; i++)
        {
            var vertexWorldPos = targetDeformObject.transform.TransformPoint(deformedVertices[i]);
            var distance = Vector3.Distance(hitPoint, vertexWorldPos);

            float deformation = 0f;
            if (distance < deformRadius)
                deformation = ApplyDeformation(distance);

            if (raiseMode)
                deformedVertices[i].y += deformation;
            else
                deformedVertices[i].y -= deformation;
        }

        ApplyMeshToTarget(deformedVertices);
    }

    private float ApplyDeformation(float distance)
    {
        // Smooth deformation from click point across deformation radius
        var falloff = 1 - distance / deformRadius;
        return falloff * deformStrength;
    }

    private void ApplyMeshToTarget(Vector3[] vertices)
    {
        targetDeformMesh.vertices = vertices;
        targetDeformMesh.RecalculateNormals();
        targetDeformMesh.RecalculateBounds();
    }
}
