using UnityEngine;

public enum NodeState
{ 
    Available,
    Current,
    Completed
}


public class cvorLabirinta : MonoBehaviour
{
    [SerializeField] GameObject[] zidovi;
    [SerializeField] MeshRenderer pod;

    public bool jeZid = true;
    public void micanjeZidova(int zidUkloni)
    {
        zidovi[zidUkloni].gameObject.SetActive(false);

        jeZid = false;
    }

    public void SetState(NodeState state)
    {
        switch (state)
        {
            case NodeState.Available:
                pod.material.color = Color.white;
                break;
            case NodeState.Current:
                pod.material.color = Color.yellow;
                break;
            case NodeState.Completed:
                pod.material.color = Color.blue;
                break;
        }
    }

}
