using UnityEngine;

public class cvorLabirinta : MonoBehaviour
{
    [SerializeField] GameObject[] zidovi;
    [SerializeField] MeshRenderer pod;


    public void micanjeZidova(int zidUkloni)
    {
        zidovi[zidUkloni].gameObject.SetActive(false);
    }

}
