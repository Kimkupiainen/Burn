using UnityEngine;

public class inspectionpointsetter : MonoBehaviour
{
    public Transform objectOne;
    public Transform objectTwo;
    public GameObject mainCamera;

    void Start()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("No virtual camera assigned");
        }

        // Position this GameObject in the middle of objectOne and objectTwo
        transform.position = Vector3.Lerp(objectOne.position, objectTwo.position, 0.5f);
    }

    void Update()
    {

    }
}
