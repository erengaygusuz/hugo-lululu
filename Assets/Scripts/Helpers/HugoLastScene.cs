using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugoLastScene : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;

    public void ActivateGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
