using UnityEngine;
using System.Collections;

public class Trigger_Chapter2 : MonoBehaviour
{
    bool used = false;

    public void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            GlobalEvents.Instance.Cap2();
            Destroy(gameObject);
            used = true;
        }
    }
}
