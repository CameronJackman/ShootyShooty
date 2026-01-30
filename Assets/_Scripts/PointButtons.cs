using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointButtons : MonoBehaviour
{
    public float pointValue;

    private GameMan gameMan;

    private bool canBeShot = true;

    private Renderer objectRenderer;

    private Color originalColor,
                    originalEmissionColor;

    // Start is called before the first frame update
    void Start()
    {
        gameMan = GameObject.Find("GameManager").GetComponent<GameMan>();
        objectRenderer = GetComponent<Renderer>();

        originalColor = objectRenderer.material.color;
        originalEmissionColor = objectRenderer.material.GetColor("_EmissionColor");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            ButtonShot();
        }
    }

    void ButtonShot()
    {
        if (gameMan != null && canBeShot)
        {
            gameMan.points += pointValue;

            StartCoroutine(DeactivateButton(3f));
        }
        else if (gameMan == null)
        {
            Debug.LogError("GameManager reference is missing in PointButtons script.");
        }
    }


    private IEnumerator DeactivateButton(float delayTime)
    {
        canBeShot = false;

        objectRenderer.material.color = Color.gray;
        objectRenderer.material.SetColor("_EmissionColor", Color.black);

        yield return new WaitForSeconds(delayTime);
        canBeShot = true;
        objectRenderer.material.color = originalColor;
        objectRenderer.material.SetColor("_EmissionColor", originalEmissionColor);
    }
}
