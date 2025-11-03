using UnityEngine;

public class MoveMe : MonoBehaviour
{

    // Identify the target

    //   public GameObject targetSphere; //Target 1
    //   public GameObject targetCylinder; //Target 2
    //   public GameObject targetCapsule; //Target 3
    //   public GameObject targetQuad; //Target 4

    [SerializeField] string point1Tag = "Point1"; //Tag for position 1
    [SerializeField] string point2Tag = "Point2"; //Tag for position 2
    [SerializeField] string point3Tag = "Point3"; //Tag for position 3
    [SerializeField] string point4Tag = "Point4"; //Tag for position 4


    // Create a fourth position
    private GameObject nextPosition;

    // Identify the speed

    public float moveSpeed;

    // Create renderer containers

    private Renderer cubeRenderer;
    private Renderer sphereRenderer;
    private Renderer cylinderRenderer;
    private Renderer capsuleRenderer;
    private Renderer quadRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject targetSphere = GameObject.FindWithTag(point1Tag);
        GameObject targetCylinder = GameObject.FindWithTag(point2Tag);
        GameObject targetCapsule = GameObject.FindWithTag(point3Tag);
        GameObject targetQuad = GameObject.FindWithTag(point4Tag);

        // Fill the renderer containers

        cubeRenderer = gameObject.GetComponent<Renderer>();
        sphereRenderer = targetSphere.GetComponent<Renderer>();
        cylinderRenderer = targetCylinder.GetComponent<Renderer>();
        capsuleRenderer = targetCapsule.GetComponent<Renderer>();
        quadRenderer = targetQuad.GetComponent<Renderer>();

        // Get the colors

        //Color cubeColor = cubeRenderer.material.color;
        //Color sphereColor = sphereRenderer.material.color;

        // 
        nextPosition = targetSphere;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject targetSphere = GameObject.FindWithTag(point1Tag);
        GameObject targetCylinder = GameObject.FindWithTag(point2Tag);
        GameObject targetCapsule = GameObject.FindWithTag(point3Tag);
        GameObject targetQuad = GameObject.FindWithTag(point4Tag);

        // Move the cube

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPosition.transform.position, moveSpeed * Time.deltaTime);

        // Swap the colors
        if (gameObject.transform.position == targetSphere.transform.position)
        {
            cubeRenderer.material.color = sphereRenderer.material.color;
            nextPosition = targetCylinder;
        }

        else if (gameObject.transform.position == targetCylinder.transform.position)
        {
            cubeRenderer.material.color = cylinderRenderer.material.color;
            nextPosition = targetCapsule;
        }

        else if (gameObject.transform.position == targetCapsule.transform.position)
        {
            cubeRenderer.material.color = capsuleRenderer.material.color;
            nextPosition = targetQuad;
        }
        else if (gameObject.transform.position == targetQuad.transform.position)
        {
            cubeRenderer.material.color = quadRenderer.material.color;
            nextPosition = targetSphere;
        }
    }
}
