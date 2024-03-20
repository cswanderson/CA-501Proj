using UnityEngine;

public class SnapPlayerToTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    private void Start()
    {
        PlayerTracker.Instance.gameObject.transform.position = target.position;
    }
}
