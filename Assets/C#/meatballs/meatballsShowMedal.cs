using UnityEngine;

public class meatballsShowMedal : MonoBehaviour
{
    public GameObject goldMedal; // 金牌图片
    public GameObject silverMedal; // 银牌图片
    public GameObject bronzeMedal; // 铜牌图片

    void Start()
    {
        if (MedalManager.GamePlayed)
        {
            ShowMedal(MedalManager.TotalTime);
        }
        else
        {
            HideAllMedals();
        }
    }

    private void ShowMedal(float totalTime)
    {
        HideAllMedals();
        if (totalTime < 30)
        {
            goldMedal.SetActive(true);
        }
        else if (totalTime < 60)
        {
            silverMedal.SetActive(true);
        }
        else
        {
            bronzeMedal.SetActive(true);
        }
    }

    private void HideAllMedals()
    {
        goldMedal.SetActive(false);
        silverMedal.SetActive(false);
        bronzeMedal.SetActive(false);
    }
}
