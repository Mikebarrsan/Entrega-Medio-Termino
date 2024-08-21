using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletsCounter : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    private int i;

    void Start()
    {
        i = 0;
        UpdateCountText();
    }

    public void IncrementBulletCount()
    {
        i++;
        UpdateCountText();
    }

    public void DecrementBulletCount()
    {
        i--;
        UpdateCountText();
    }

    private void UpdateCountText()
    {
        CountText.text = "Bullets: " + i;
    }
}
