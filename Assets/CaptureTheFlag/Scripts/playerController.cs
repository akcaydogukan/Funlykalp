using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlme : MonoBehaviour
{
    public FixedJoystick joystick;

    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;
    [HideInInspector]
    public bool onDrag = false;

    private bool isFrozen = false;          // Oyuncu donmuş mu kontrolü
    private float freezeTimer = 0f;         // Donma süresi sayacı
    private float freezeDuration = 3f;      // Kar tanesi ile donma süresi (saniye)

    private void Start()
    {
        joystick.player = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(onDrag);

        if (!isFrozen)
        {
            move.x = joystick.Horizontal;
            move.y = joystick.Vertical;
        }
        else
        {
            // Eğer oyuncu donmuşsa, hareketi sıfırla
            move = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (onDrag)
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
            transform.up = move;
        }

        UpdateFrozenState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowflake"))
        {
            // Kar tanesi ile çarpışma
            Freeze();
            Destroy(collision.gameObject); // Kar tanesi nesnesini yok et
        }
    }

    private void Freeze()
    {
        isFrozen = true;
        rb.velocity = Vector2.zero;
        freezeTimer = 0f;
    }

    private void UpdateFrozenState()
    {
        if (isFrozen)
        {
            freezeTimer += Time.deltaTime;

            if (freezeTimer >= freezeDuration)
            {
                isFrozen = false;
                freezeTimer = 0f;
            }
        }
    }
}