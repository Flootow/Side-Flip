using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    float duration = 4.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "The Enemy")
        {
            collision.gameObject.GetComponent<Health>().HP -= 1;
            Explode();
        }
        gameObject.GetComponent<VisualEffect>();
    }

    private void Start()
    {
        this.gameObject.transform.localScale = Vector3.one;
    }

    private void Update()
    {
        float scale = gameObject.transform.localScale.x;
        scale -= Time.deltaTime / duration;
        if (scale <= 0)
        {
            Destroy(gameObject);
        }
        gameObject.transform.localScale = Vector3.one * scale;
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 2.0f);
        Destroy(gameObject);
    }
}
