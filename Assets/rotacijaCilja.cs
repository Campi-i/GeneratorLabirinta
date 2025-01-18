using UnityEngine;

public class rotacijaCilja : MonoBehaviour
{
    public float brzinaRotacije = 50f;

    void Update()
    {
        transform.Rotate(Vector3.up * brzinaRotacije * Time.deltaTime, Space.World);    
    }
}
