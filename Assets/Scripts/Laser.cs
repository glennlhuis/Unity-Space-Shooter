using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{    
    [SerializeField]
    private float _speed = 15.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
        DestroyLaser();        
    }

    void ShootLaser()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
    void DestroyLaser()
    {
        if(transform.position.y > 8)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
   
}
