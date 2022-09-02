using UnityEngine;
using Color = UnityEngine.Color;
using DG.Tweening;
using System.Collections;

public class PlataformCell : MonoBehaviour
{
    [SerializeField] private Color[] colors = default;
    [SerializeField] private PlataformControll plataformControll = default;
    [SerializeField] private Plataform plataform = default;
    [SerializeField] private MeshRenderer meshRenderer = default;

    public PlataformEnum plataformEnum = default;
    
    public int cellId = default;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);

        if (PlayerPrefs.HasKey(plataformEnum.ToString() + "-" + cellId))
        {
            meshRenderer.material.color = colors[PlayerPrefs.GetInt(plataformEnum.ToString() + "-" + cellId + "-color-")];
            gameObject.SetActive(false);
            plataformControll.MatchColor(plataformEnum, meshRenderer.material.color);
        }
    }

    public void SetColor(Color color, int colorId)
    {
        PlayerPrefs.SetInt(plataformEnum.ToString() + "-" + cellId + "-color-", colorId);
        meshRenderer.material.color = color;
    }

    public Color GetColor { get { return meshRenderer.material.color; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlataformCell>().GetColor == meshRenderer.material.color)
        {
            if (!plataformControll.gameStarted) return;
            plataform.rotation = false;

            PlayerPrefs.SetInt(plataformEnum.ToString() + "-" + cellId, 1);

            plataformControll.MatchColor(plataformEnum, meshRenderer.material.color);
            transform.DOScale(0.005f, .5f).SetEase(Ease.InOutSine).OnComplete(() => { gameObject.SetActive(false); transform.DOScale(0.002644233f, 1f); plataform.rotation = true; });
        }
    }
}
