using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform _gun;
    [SerializeField] private GameObject [] _bulletPrefab;
    [SerializeField] private Transform _bulletTransform;
 
    float _angle;
    float _speed = 5f;
    float _fireDelay = 1f;
    float _lastFireTime;

    void Update()
    {
        if (InputBlocker.IsUIBlockingInput)
            return;
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
            RotateChange();
        }
        else
            RotateChange ();
    }

    public void RotateChange()
    {
        
        Vector3 mousePos = Input.mousePosition;
        if (float.IsInfinity(mousePos.x) || 
            float.IsNaN(mousePos.x) || 
            float.IsInfinity(mousePos.y) || 
            float.IsNaN(mousePos.y)) return;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);

        Vector2 direction = Camera.main.ScreenToWorldPoint(mousePos) - _gun.position;
        _angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if(_angle<40 && _angle > -40)
        {
            Quaternion rotation = Quaternion.AngleAxis(_angle, Vector3.forward);

            _gun.rotation = Quaternion.Slerp(_gun.rotation, rotation, _speed * Time.deltaTime);

        
            if (Input.GetMouseButtonUp(0) 
                && !IsInDeadZone()
                && Time.time > _lastFireTime + _fireDelay)
            {
                
                _gun.rotation = rotation;
                if (PlayerPrefs.GetInt("sesDurumu") == 1)
                {
                    AudioManager.Instance.Play(SoundType.FireSound);
                }
                fireBullet();
                _lastFireTime = Time.time;
            }
        }
    }
    bool IsInDeadZone()
    {
        return Input.mousePosition.y > Screen.height * 0.675f;
    }

    public void fireBullet()
    {
        if (!InputBlocker.IsUIBlockingInput)
        {
            GameObject bullet = Instantiate(_bulletPrefab[Random.Range(0, _bulletPrefab.Length)], _bulletTransform.position, _bulletTransform.rotation) as GameObject;
        }
    }
   
    
}
