using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject instruction;
    // Start is called before the first frame update
    void Start()
    {
        instruction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    public void ChangeToMenu()
    {
        SceneManager.LoadScene("menu");

        //SceneManager.LoadScene(1);
    }
    public void ChooseFood1()
    {
        SceneManager.LoadScene("蔥油餅");
    }
    public void ChooseFood2()
    {
        SceneManager.LoadScene("鳳梨酥");
    }
    public void ChooseFood3()
    {
        SceneManager.LoadScene("雞肉飯");
    }
    public void ChooseFood4()
    {
        SceneManager.LoadScene("肉圓");
    }
    public void CloseChoose()
    {
        SceneManager.LoadScene("map");

        //SceneManager.LoadScene(1);
    }
    public void CloseChoose2()
    {
        SceneManager.LoadScene("cover");

        //SceneManager.LoadScene(1);
    }
    public void ShowInstruction()
    {
        instruction.SetActive(true);

        //SceneManager.LoadScene(1);
    }

    public void meatballsQues()
    {
        if (MedalManager.meatBallsGamePass)
        {
            collectfood_meatballs.Instance.ResetCollectedIngredients();
        }
        MedalManager.meatBallsGamePlayed = false;
        MedalManager.meatBallsTotalTime = 0;
        MedalManager.meatBallsGamePass = false;

        Timer.Instance.currentGame = Timer.GameType.MeatBalls;
        Timer.Instance.ResetTimer(); // 重置计时器
        SceneManager.LoadScene("Scenes/meatballs/taiwan(meatballs)");

    }
    public void pineappleCakeQues()
    {
        if (MedalManager.pineappleCakeGamePass)
        {
            collectfood_pineapplecake.Instance.ResetCollectedIngredients();
        }
        MedalManager.pineappleCakeGamePlayed = false;
        MedalManager.pineappleCakeTotalTime = 0;
        MedalManager.pineappleCakeGamePass = false;

        Timer.Instance.currentGame = Timer.GameType.PineappleCake;
        Timer.Instance.ResetTimer(); // 重置计时器
        SceneManager.LoadScene("Scenes/pineapplecake/taiwan(pineapple_cake)");
    }
    public void chickenRiceQues()
    {
        if (MedalManager.chickenriceGamePass)
        {
            collectfood_chickenrice.Instance.ResetCollectedIngredients();
        }
        MedalManager.chickenriceGamePlayed = false;
        MedalManager.chickenriceTotalTime = 0;
        MedalManager.chickenriceGamePass = false;

        Timer.Instance.currentGame = Timer.GameType.ChickenRice;
        Timer.Instance.ResetTimer(); // 重置计时器
        SceneManager.LoadScene("Scenes/chickenrice/taiwan(chickenrice)");

    }
    public void scallionpancakeQues()
    {
        if (MedalManager.scallionPancakeGamePass)
        {
            collectfood_scallionpancake.Instance.ResetCollectedIngredients();
        }
        MedalManager.scallionPancakeGamePlayed = false;
        MedalManager.scallionPancakeTotalTime = 0;
        MedalManager.scallionPancakeGamePass = false;

        Timer.Instance.currentGame = Timer.GameType.ScallionPancake;
        Timer.Instance.ResetTimer(); // 重置计时器
        SceneManager.LoadScene("Scenes/Scallion_pancake/taiwan(Scallion_pancake)");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
