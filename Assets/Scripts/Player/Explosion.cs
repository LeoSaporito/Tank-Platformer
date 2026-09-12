using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Explosion : MonoBehaviour
{
    public PointEffector2D explosionComponent;
    public CircleCollider2D circleCollider;

    [SerializeField] private float addTorqueAmountInDegrees;
    private float explosionRadius;

    public LayerMask layersToHit;
    public GameObject explosionParticles;
    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        explosionComponent = GetComponent<PointEffector2D>();
        
        //So bomb doesnt go off immediately
        explosionComponent.enabled = false;
        explosionRadius = circleCollider.radius;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("LayerToHit"))
        {
            Explode();
        }
    }
    private void Explode()
    {
        explosionComponent.enabled = true;

        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layersToHit);

        foreach (Collider2D obj in objects)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.AddTorque(addTorqueAmountInDegrees * Mathf.Deg2Rad * rb.inertia);            
        }
        ExplosionParticles();
        GetComponent<SpriteRenderer>().enabled = false;
        Invoke("DestroyBomb", 0.1f);
    }
    private void ExplosionParticles()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
    }
    private void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
/*    public float expForce, radius;

    public LayerMask layerToHit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Knockback();
        Destroy(gameObject);
    }

    private void Knockback()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, layerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * expForce);

            Vector2 rotation = (Vector2)transform.position - (Vector2)obj.transform.position;

            float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }*/
/*private void Knockback()
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

    foreach (Collider2D nearby in colliders)
    {
        Rigidbody2D rb = nearby.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 force = (transform.position - nearby.transform.position).normalized * expForce;
            rb.AddForce(force, ForceMode2D.Force);
        }
    }
}*/
