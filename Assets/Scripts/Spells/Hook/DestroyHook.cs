using UnityEngine;

public class DestroyHook : MonoBehaviour
{
    public void RemoveHook()
    {
        Destroy(gameObject);
    }
}
