using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ptak : MonoBehaviour
{
    public bool hunting = true;
    public float walkSpeed = 0.9f;
    public float spacerSpeedMult = 0.4f;
    public float spacerRotateMult = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Fgfg() && !Hunt())
            Spacerekxd();
    }
    
    private bool Fgfg()
    {
        if (Board.instance.cosie != Board.GRA)
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            return true;
        }
        return false;
    }

    // Returns true if there are any seeds.
    private bool Hunt()
    {
        float odl = float.PositiveInfinity;
        Ziarenko najblizej = null;

        if (Board.instance.seedsAll.Any())
        {

            // iterate root objects and do something
            for (int i = 0; i < Board.instance.seedsAll.Count; ++i)
            {
                Ziarenko z = Board.instance.seedsAll[i].GetComponent<Ziarenko>(); ;
                if (z != null)
                {
                    float o = (transform.position - Board.instance.seedsAll[i].transform.position).sqrMagnitude;
                    if (o < odl)
                    {
                        odl = o;
                        najblizej = z;
                    }
                }
            }
            if (najblizej != null)
            {
                Vector2 diff = najblizej.transform.position - transform.position;
                float angle = Mathf.Atan2(diff.y, diff.x);
                angle = Mathf.Rad2Deg * angle;
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

                transform.rotation = targetRotation;

                // zmieńmy jeszcze prędkość xd

                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.velocity = targetRotation * (Vector3.right * walkSpeed);
                rb.angularVelocity = 0f;
                return true;
            }
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ziarenko z = collision.collider.GetComponent<Ziarenko>();
        if (z != null)
        {
            Destroy(z.gameObject);
        }
    }
    private void Spacerekxd()
    {
        //Debug.Log("jabłeczka xd");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = spacerRotateMult * (2 * Random.value - 1);
        Debug.Log(rb.angularVelocity);
        rb.velocity = Quaternion.Euler(0f, 0f, rb.rotation) * (Vector3.right * walkSpeed * spacerSpeedMult);
    }
}
