using UnityEngine;

public class MaterialSwap : MonoBehaviour
{

    // Identify the cube and sphere

    public GameObject cubeSwap;
    public GameObject sphereSwap;
    public GameObject cylinderSwap;
    public GameObject capsuleSwap;

    // Variable in the shape of Renderers

    private Renderer cubeRenderer;
    private Renderer sphereRenderer;
    private Renderer cylinderRenderer;
    private Renderer capsuleRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Fill the renderer containers

        cubeRenderer = cubeSwap.GetComponent<Renderer>();
        sphereRenderer = sphereSwap.GetComponent<Renderer>();
        cylinderRenderer = cylinderSwap.GetComponent<Renderer>();
        capsuleRenderer = capsuleSwap.GetComponent<Renderer>();

        // Get the colors

        Color cubeColor = cubeRenderer.material.color;
        Color sphereColor = sphereRenderer.material.color;
        Color cylinderColor = cylinderRenderer.material.color;
        Color capsuleColor = capsuleRenderer.material.color;

        // Swap the colors

        cubeRenderer.material.color = sphereColor;
        sphereRenderer.material.color = cubeColor;
        cylinderRenderer.material.color = cylinderColor;
        capsuleRenderer.material.color = capsuleColor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
