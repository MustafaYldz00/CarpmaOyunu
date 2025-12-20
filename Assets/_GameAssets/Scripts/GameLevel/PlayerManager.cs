using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform _gun;

    float _angle;
    float _speed = 5f;

    void Update()
    {
       RotateChange();
    }

    public void RotateChange()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _gun.transform.position;
            _angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        }


        Quaternion rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        _gun.transform.rotation = Quaternion.Slerp(_gun.transform.rotation, rotation, _speed*Time.deltaTime);
    }
}
