using UnityEngine;

public class YuME_tileGizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "YuME_tileGizmo", true);
    }
}
