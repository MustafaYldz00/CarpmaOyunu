using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _bulletSpeed = 15f;
    void Start()
    {
        if (this.gameObject != null)
        {
            Destroy(this.gameObject, 1.8f);
        }
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _bulletSpeed);    
    }
}
