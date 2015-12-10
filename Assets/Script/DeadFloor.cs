using UnityEngine;
using System.Collections;

public class DeadFloor : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }
}
