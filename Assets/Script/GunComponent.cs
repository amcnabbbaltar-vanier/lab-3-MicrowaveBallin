using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 10000.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

    void Update()
    {
        //TODO logic to track player holding input
        if (Input.GetButton("Fire1"))
        {
            isCharging = true;
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0.0f, maxChargeTime);
            Debug.Log("Charging: " + chargeTime);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Released");
            ShootBullet(chargeTime);
            isCharging = false;
            chargeTime = 0.0f;
        }
    }

    void ShootBullet(float currentCharge)
    {
        // Instantiate bullet at spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        //TODO change quation to add impulse that follows charge time
        float bulletImpulse = (currentCharge / maxChargeTime) * bulletMaxImpulse;

        //an impulse is a force applied at a single instant
        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);

    }

}



