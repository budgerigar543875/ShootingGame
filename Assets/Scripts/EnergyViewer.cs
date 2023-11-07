using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyViewer : MonoBehaviour
{
    [SerializeField] GameObject energyBarPrefab;
    int maxEnergy;
    int energy;
    List<GameObject> energyBars;

    private void Awake()
    {
        energyBars = new List<GameObject>();
        maxEnergy = 0;
        energy = 0;
    }

    public void SetMaxEnergy(int energy)
    {
        CreateEnergyBars(maxEnergy, energy);
        maxEnergy = energy;
        this.energy = Math.Min(this.energy, maxEnergy);
    }

    public void SetEnergy(int energy)
    {
        this.energy = Math.Min(energy, maxEnergy);
        UpdateEnergy();
    }

    private void CreateEnergyBars(int before, int after)
    {
        if (before == after || after < 1)
        {
            return;
        }
        if (after > before)
        {
            for (int i = before; i < (after - before); i++)
            {
                GameObject img = Instantiate(energyBarPrefab, new Vector3(0f + 30f * i, 0f, 0f), transform.rotation);
                img.transform.SetParent(transform, false);
                energyBars.Add(img);
            }
        }
        else
        {
            for (int i = before - 1; i >= after; i--)
            {
                GameObject bar = energyBars[i];
                Destroy(bar);
                energyBars.RemoveAt(i);
            }
        }
    }

    private void UpdateEnergy()
    {
        for (int i = 0; i < energy; i++)
        {
            Image img = energyBars[i].GetComponent<Image>();
            img.color = new Color((160 - 16 * i) / 255f, (240 - 12 * i) / 255f, (24 * i) / 255f, 255);
        }
        for (int i = energy; i < energyBars.Count; i++)
        {
            Image img = energyBars[i].GetComponent<Image>();
            img.color = Color.red;
        }
    }
}
