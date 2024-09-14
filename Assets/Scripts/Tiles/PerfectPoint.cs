using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectPoint : MonoBehaviour
{
    ////private bool isGetPerfectPoints = false;
    BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // perfect points
            ScoreManager.Instance.SetIsGetPerfectPoints();
            UIManager.Instance.ShowPerfectUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) boxCollider2D.enabled = false;
    }

    public void ResetPerfectPoint()
    {
        boxCollider2D.enabled = true;
    }
}
