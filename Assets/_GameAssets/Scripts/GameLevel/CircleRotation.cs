using DG.Tweening;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            gameObject.transform.DORotate(transform.eulerAngles + 
                Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);
        }
    }
}
