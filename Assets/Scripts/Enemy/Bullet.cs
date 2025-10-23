using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<PlayerUI>().TakeDamage(10);
        }
        Destroy(this.gameObject);
    }
}
