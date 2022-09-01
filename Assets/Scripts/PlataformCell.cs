using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformCell : MonoBehaviour
{
    [SerializeField] private PlataformControll plataformControll = default;
    [SerializeField] private PlataformEnum plataformEnum = default;
    [SerializeField] private MeshRenderer meshRenderer = default;
    [SerializeField] private int cellId = default;

    public void SetColor(Color color)
    {
        meshRenderer.material.color = color;
    }

    public Color GetColor { get { return meshRenderer.material.color; } }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlataformCell>().GetColor == meshRenderer.material.color)
        {
            gameObject.SetActive(false);
            plataformControll.MatchColor(plataformEnum, cellId);
        }
    }
}
