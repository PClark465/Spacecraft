using UnityEngine;

// Inherits from Shooter class
public class ShooterBullet : Shooter
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;     // Bullet prefab
    
    public override void Shoot()
    {
        if(bulletSpawnPoint != null && bulletPrefab != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        } 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
