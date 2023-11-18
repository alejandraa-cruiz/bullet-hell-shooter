using System.Collections;
using UnityEngine;

public class ChestMonsterController : MonoBehaviour
{
    public int numberOfBullets = 10;
    private int bulletCount = 0;
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
        StartCoroutine(PatternBullets());
    }

    private IEnumerator PatternBullets()
    {
        float radius = 2f;
        float rotationSpeed = 30f; // Adjust the rotation speed as needed

        // Spawn bullets for the specified time range (e.g., minutes 20 to 30)
        while (TimeManager.Minute >= 22 && TimeManager.Minute < 32)
        {
            for (int i = 0; i < numberOfBullets; i++)
            {
                // Use the object pool to get a bullet
                GameObject bullet = LargeBulletPool.Instance.GetBullet();

                // Calculate position in a flower pattern in the XZ plane
                float angle = i * (90f / numberOfBullets);
                float radians = Mathf.Deg2Rad * angle;

                // Introduce rotation in the radial pattern
                float rotationAngle = Time.time * rotationSpeed;
                Vector3 direction = Quaternion.Euler(0, rotationAngle, 0) * new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians));

                // Adjust the radius for a radial pattern
                float currentRadius = radius * Mathf.Sin(angle / 2f);

                // Set the bullet's position and direction
                bullet.transform.position = transform.position + direction * currentRadius; 
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    bulletScript.SetMovementDirection(direction.normalized);
                }

                bulletCount++;
                // Activate the bullet
                bullet.SetActive(true);
            }

            // Introduce a delay before spawning the next set of bullets
            yield return new WaitForSeconds(.5f); // Adjust the delay as needed
        }
    }

    public int BulletCount()
    {
        return bulletCount;
    }
}
