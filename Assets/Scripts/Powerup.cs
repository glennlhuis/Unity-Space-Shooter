using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -7f)
        {
            Destroy(this.gameObject);
        }
        //move down at the speed of 3f
        //when we leave the screen destroy object
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if(player != null)
            {
                player.TripleShotEnabled();
            }
            

            Destroy(this.gameObject);
        }
    }

    //on trigger collision
    //Use tags 
    //on collected destroy
}
