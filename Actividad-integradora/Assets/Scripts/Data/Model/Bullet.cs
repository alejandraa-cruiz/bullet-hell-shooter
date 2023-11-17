using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 movementDirection;
    private float movementSpeed;
    public float bulletLifetime = 1.5f;

    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(DestroyAfterTime());
    }

    void Start()
    {
        movementSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    public void SetMovementDirection(Vector3 dir)
    {
        movementDirection = dir;
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(bulletLifetime);

        // Instead of deactivating the bullet, return it to the object pool
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Clean up any ongoing coroutines when the object is disabled
        StopAllCoroutines();
    }
}
