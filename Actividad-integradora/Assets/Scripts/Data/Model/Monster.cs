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
        StartCoroutine(SpawnBullets());
    }

    private IEnumerator SpawnBullets()
    {
        // Spawn bullets for the specified time range (e.g., minutes 0 to 10)
        while (TimeManager.Minute >= 0 && TimeManager.Minute < 10){
            for (int i = 0; i < numberOfBullets; i++){
                 // Use the object pool to get a bullet
                GameObject bullet = BulletPool.Instance.GetBullet();

                // Calculate position in a circle in the XZ plane
                float angle = i * (360f / numberOfBullets);
                Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0f, Mathf.Sin(Mathf.Deg2Rad * angle));
                
                // Set the bullet's position and direction
                bullet.transform.position = transform.position;
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
}
