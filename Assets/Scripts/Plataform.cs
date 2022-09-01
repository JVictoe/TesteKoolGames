using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
using System.Linq;

public class Plataform : MonoBehaviour
{
    [SerializeField] private Color[] colors = default;
    [SerializeField] private PlataformCell[] plataforms = default;

    private void Start()
    {
        List<Color> colorList = new List<Color>();
        colorList = colors.ToList<Color>();

        foreach(PlataformCell p in plataforms)
        {
            int indexColor = UnityEngine.Random.Range(0, colorList.Count);

            p.SetColor(colorList[0]);

            colorList.RemoveAt(0);
        }
    }

    private void OnMouseUp()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        int valueToRotate = 0;

        transform.DOScale(125f, .5f);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1);

        while(valueToRotate < 6)
        {
            float newZRot = transform.localRotation.z;
            newZRot += 10;
            transform.Rotate(0, 0, newZRot);
            valueToRotate++;
            yield return new WaitForSeconds(.01f);
        }

        transform.DOScale(100f, .5f);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }
}
