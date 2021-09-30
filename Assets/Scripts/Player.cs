using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]
    private float _speed = 10.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _playerLives = 3;

    private SpawnManager _spawnManager;

    [SerializeField]
    private GameObject _triplelaserPrefab;
    [SerializeField]
    private bool isTripleShotActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = new Vector3(0,0,0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {   
        CalculateMovement();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // new Vector 3(1,0,0) * 5 * real time
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        //optimal way
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if(transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11,transform.position.y,0);
        }
        else if(transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11,transform.position.y,0);
        }

    }
    void FireLaser()
    {
        Vector3 offset = new Vector3 (0,1.05f,0);
        _canFire = Time.time + _fireRate;
        
            
        if (isTripleShotActive == true) 
        {
            Instantiate(_triplelaserPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);
        }
        
    }

    public void DamagePlayer()
    {
        _playerLives--;

        

        if(_playerLives == 0)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            
        }
    }

    public void TripleShotEnabled()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDown());
    }

    IEnumerator TripleShotPowerDown()
    {
        while(isTripleShotActive == true)
        {
            
            yield return new WaitForSeconds(5.0f);
            isTripleShotActive = false;
            
        }    
    }

   

}
