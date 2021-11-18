using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObstacle : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 50f;

    private float zAngle;

    private void Update()
    {
        zAngle += rotateSpeed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManger.PLAYERTAG))
        {
            Destroy(collision.gameObject);
        }
    }
}
