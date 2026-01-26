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
        if (Time.timeScale != 1f)
        { Time.timeScale = 1f; }
        
        transform.Translate(Vector3.up * Time.deltaTime * _bulletSpeed);
    }
}
