using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] float shootSpeed = 15f;
    [SerializeField] float fireRate = .25f;
    [SerializeField] Transform shootPoint;
    bool isShooting;

    private void Update()
    {
        MouseLook();
    }

    public void Shoot()
    {
        if (isShooting) return;

        SpawnBullet(shootPoint.right);
        isShooting = true;
        Invoke(nameof(Cooldown), fireRate);
    }

    void SpawnBullet(Vector3 direction)
    {
        Rigidbody2D newBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        newBullet.transform.right = direction;
        newBullet.velocity = newBullet.transform.right * shootSpeed;
    }

    void Cooldown()
    {
        isShooting = false;
    }

    void MouseLook()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDir = mousePos - transform.position;
        mouseDir.Normalize();

        float targetAngle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;

        if (mousePos.x < transform.position.x)
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);
    }
}
