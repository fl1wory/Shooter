using UnityEngine;

public class AssignMaterialScript : MonoBehaviour
{
    public Material targetMaterial;

    void Start()
    {
        MeshRenderer[] renderers = FindObjectsOfType<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material = targetMaterial;
        }
    }
}
