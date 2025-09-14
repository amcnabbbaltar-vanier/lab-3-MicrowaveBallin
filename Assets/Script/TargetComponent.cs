using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class TargetComponent : MonoBehaviour
{
    private Renderer targetRenderer;
    private Color originalColor;
    public Color hitColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            originalColor = targetRenderer.material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {

            GameManager.Instance.IncrementScore();

            if (targetRenderer != null)
            {
                targetRenderer.material.color = hitColor;
            }
            // Reset color after a delay
            Invoke("ResetColor", 5f);
        }
    }

    private void ResetColor()
    {
        if (targetRenderer != null)
        {
            targetRenderer.material.color = originalColor;
        }
    }
}
