using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Plataform : MonoBehaviour
{
    [SerializeField] private PlataformControll plataformControll = default;
    [SerializeField] private PlataformEnum plataformEnum = default;
    public bool rotation;
    int rot;

    private void Start()
    {
        rotation = true;
        if (PlayerPrefs.HasKey(plataformEnum.ToString() + "RotatePos"))
        {
            int value = rot = PlayerPrefs.GetInt(plataformEnum.ToString() + "RotatePos", rot);

            while(value > 0)
            {
                int valueToRotate = 0;

                while (valueToRotate < 6)
                {
                    transform.Rotate(0, 0, 10);

                    valueToRotate++;
                }

                value--;
            }
        }
    }

    private void OnMouseUp()
    {
        plataformControll.gameStarted = true;

        if(rotation)
        {
            StartCoroutine(Rotate());
        }
    }

    private IEnumerator Rotate()
    {
        int valueToRotate = 0;

        transform.DOScale(7000f, .5f);

        while (valueToRotate < 6)
        {
            transform.Rotate(0, 0, 10);
            
            valueToRotate++;

            yield return new WaitForSeconds(.01f);
        }

        rot++;

        PlayerPrefs.SetInt(plataformEnum.ToString() + "RotatePos", rot);

        transform.DOScale(6500f, .5f);
    }
}
