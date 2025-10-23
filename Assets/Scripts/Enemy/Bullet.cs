using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OllisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if(hitTransform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
        }
    }
}
