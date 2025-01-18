using UnityEngine;

public class playerColider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cilj"))
        {
            Debug.Log("Pobijedio si");
        }
    }
}
