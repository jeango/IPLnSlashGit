using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour
{
    [SerializeField]
    bool destroySelf;
    [SerializeField]
    bool destroyOther;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyOther)
            Pooling.Release(collision.attachedRigidbody.gameObject);
        //            Destroy(collision.attachedRigidbody.gameObject);
        if (destroySelf)
            Pooling.Release(gameObject);
//            Destroy(gameObject);
    }
}
