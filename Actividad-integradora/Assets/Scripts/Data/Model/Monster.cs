using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Remove the bulletPrefab and bulletSpawnPoint variables
    // public GameObject bulletPrefab;
    // public Transform bulletSpawnPoint;
    public int numberOfBullets = 10;
    private void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    private void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
        StartCoroutine(CircleBullets());
        StartCoroutine(SpinBullets());
        StartCoroutine(FlowerBullets());
    }

    private IEnumerator CircleBullets()
    {
        float radius = 2f;
        // Spawn bullets for the specified time range (e.g., minutes 0 to 10)
        while (TimeManager.Minute >= 0 && TimeManager.Minute < 10){
            for (int i = 0; i < numberOfBullets; i++){
                 // Use the object pool to get a bullet
                GameObject bullet = BulletPool.Instance.GetBullet();

                // Calculate position in a circle in the XZ plane
                float angle = i * (360f / numberOfBullets);
                float radians = Mathf.Deg2Rad * angle;
                Vector3 direction = new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians));

                // Set the bullet's position and direction
                bullet.transform.position = transform.position + direction * radius; 
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    bulletScript.SetMovementDirection(new Vector3(direction.x, direction.y, direction.z));
                }

                // Activate the bullet
                bullet.SetActive(true);
            }

            // Introduce a delay before spawning the next set of bullets
            yield return new WaitForSeconds(.5f); // Adjust the delay as needed
        }
    }

    private IEnumerator SpinBullets()
    {
        float radius = 2f;
        float rotationSpeed = 30f;
        // Spawn bullets for the specified time range (e.g., minutes 0 to 10)
        while (TimeManager.Minute >= 10 && TimeManager.Minute < 20){
            for (int i = 0; i < numberOfBullets; i++){
                 // Use the object pool to get a bullet
                GameObject bullet = BulletPool.Instance.GetBullet();
                
                // Calculate position in a circle in the XZ plane
                float angle = i * (360f / numberOfBullets);
                float radians = Mathf.Deg2Rad * angle;
                Vector3 direction = Quaternion.Euler(0, rotationSpeed * Time.time, 0) * new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians));

                // Set the bullet's position and direction
                bullet.transform.position = transform.position + direction * radius; 
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    bulletScript.SetMovementDirection(direction.normalized);
                }

                // Activate the bullet
                bullet.SetActive(true);
            }

            // Introduce a delay before spawning the next set of bullets
            yield return new WaitForSeconds(.3f); // Adjust the delay as needed
        }
    }

    private IEnumerator FlowerBullets()
{
    float radius = 2f;
    int petals = 6; // Number of petals in the flower
    float rotationSpeed = 30f; // Adjust the rotation speed as needed

    // Spawn bullets for the specified time range (e.g., minutes 0 to 10)
    while (TimeManager.Minute >= 20 && TimeManager.Minute < 30)
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            // Use the object pool to get a bullet
            GameObject bullet = BulletPool.Instance.GetBullet();

            // Calculate position in a flower pattern in the XZ plane
            float petalAngle = i * (360f / numberOfBullets);
            float radians = Mathf.Deg2Rad * petalAngle;

            // Introduce rotation in the radial pattern
            float rotationAngle = Time.time * rotationSpeed;
            Vector3 direction = Quaternion.Euler(0, rotationAngle, 0) * new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians));

            // Adjust the radius for a radial pattern
            float currentRadius = radius * Mathf.Sin(petalAngle / 2f);

            // Set the bullet's position and direction
            bullet.transform.position = transform.position + direction * currentRadius; 
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetMovementDirection(direction.normalized);
            }

            // Activate the bullet
            bullet.SetActive(true);
        }

        // Introduce a delay before spawning the next set of bullets
        yield return new WaitForSeconds(.5f); // Adjust the delay as needed
    }
}


}
