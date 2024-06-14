using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSences_Scallion_pancake : MonoBehaviour
{
    public string sceneToLoad;
    public Text collectedIngredientsText;
    public Text UncollectedIngredientsText;
    public GameObject GameObject;

    public Sprite questionMarkSprite;
    public Image[] ingredientSlots;
    public Sprite[] ingredientSprites;
    public List<string> objetfoods = new List<string> { "green_onion1", "green_onion2", "egg1", "egg2", "flour1", "flour2" };
    public Image Error;
    void Start()
    {
        // PlayerPrefs.SetString("ReturnScene", SceneManager.GetActiveScene().name);

        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            ingredientSlots[i].sprite = questionMarkSprite;
        }
        // UpdateCollectedIngredients();
        Error.gameObject.SetActive(false);

    }

    void UpdateCollectedIngredients()
    {
        List<string> ingredients = collectfood.Instance.GetCollectedIngredients();
        // collectedIngredientsText.text = "收集到的食材:\n" + string.Join("\n", ingredients);
        List<string> Uningredients = collectfood.Instance.GetUnCollectedIngredients();
        // UncollectedIngredientsText.text = "沒有收集到的食材:\n" + string.Join("\n", Uningredients);
        Debug.Log("ingredients123" + ingredients[0]);
        // foreach (string ingredient in ingredients)
        int size = ingredients.Count;
        // foreach (string ingredient in ingredients)
        List<string> newingredients;


        newingredients = DisplayCollectedIngredient(ingredients);
        collectfood.Instance.OnIngredientsChanged(newingredients);

        //Debug.Log("1"+collectfood.Instance.GetCollectedIngredients()[0]);
        //Debug.Log("2"+collectfood.Instance.GetUnCollectedIngredients()[0]);

        foreach (Transform child in GameObject.transform)
        {
            Debug.Log(123456789);
            Button ingredientButton = child.GetComponent<Button>();
            if (ingredientButton != null)
            {
                string ingredientName = child.name.Replace("1", "");
                string ingredientName2 = child.name.Replace("2", "");

                // Debug.Log(ingredientName);
                // Debug.Log(child.name);
                if (collectfood.Instance.HasCollected(ingredientName) || collectfood.Instance.HasCollected(ingredientName2))
                {
                    ingredientButton.gameObject.SetActive(false);

                }

                if (collectfood.Instance.NotHasCollected(ingredientName) || collectfood.Instance.NotHasCollected(ingredientName2))
                {
                    ingredientButton.gameObject.SetActive(false);

                }

            }
        }
    }
    public List<string> DisplayCollectedIngredient(List<string> ingredients)
    {
        //for (int i = 0; i < ingredientSlots.Length; i++)
        //{
        //    if (ingredientSlots[i].sprite == questionMarkSprite)
        //    {
        //        ingredientSlots[i].sprite = GetIngredientSprite(ingredient);
        //        break;
        //    }
        //}
        List<string> ingredientsToRemove = collectfood.Instance.GetUnCollectedIngredients();

        foreach (string ingredient in ingredients)
        {
            if (!objetfoods.Contains(ingredient))
            {
                Debug.Log("NO");
                ingredientsToRemove.Add(ingredient);
                StartCoroutine(ShowAndHideErrorImage());
            }
        }
        Debug.Log("333333");
        // Remove the collected ingredients
        foreach (string ingredient in ingredientsToRemove)
        {
            ingredients.Remove(ingredient);
        }
        collectfood.Instance.OnUNIngredientsChanged(ingredientsToRemove);
        Debug.Log("NO123456789" + ingredients[0]);
        int i = 0;
        foreach (string ingredient in ingredients)
        {
            Debug.Log("333333");
            if (objetfoods.Contains(ingredient))
            {
                ingredientSlots[i].sprite = GetIngredientSprite(ingredient);
            }
            i++;
        }
        return ingredients;
    }
    private IEnumerator ShowAndHideErrorImage()
    {
        // Show the image
        Error.gameObject.SetActive(true);

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Hide the image
        Error.gameObject.SetActive(false);
    }
    private Sprite GetIngredientSprite(string ingredient)
    {
        switch (ingredient)
        {
            case "butter1":
                return ingredientSprites[0];
            case "butter2":
                return ingredientSprites[1];
            case "egg1":
                return ingredientSprites[2];
            case "egg2":
                return ingredientSprites[3];
            case "flour1":
                return ingredientSprites[4];
            case "flour2":
                return ingredientSprites[5];
            case "pork1":
                return ingredientSprites[6];
            case "pork2":
                return ingredientSprites[7];
            case "green_onion1":
                return ingredientSprites[8];
            case "green_onion2":
                return ingredientSprites[9];
            default:
                return questionMarkSprite;
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateCollectedIngredients();
    }

    public void Choosebutter1()
    {
        Debug.Log("12346789");
        SceneManager.LoadScene("butter1(Scallion_pancake)");
    }
    public void Choosebutter2()
    {
        SceneManager.LoadScene("butter2(Scallion_pancake)");
    }
    public void Choosepork1()
    {
        SceneManager.LoadScene("pork1(Scallion_pancake)");
    }
    public void Choosepork2()
    {
        SceneManager.LoadScene("pork2(Scallion_pancake)");
    }
    public void Chooseflour1()
    {
        SceneManager.LoadScene("flour1(Scallion_pancake)");
    }
    public void Chooseflour2()
    {
        SceneManager.LoadScene("flour2(Scallion_pancake)");
    }
    public void Chooseegg1()
    {
        SceneManager.LoadScene("egg1(Scallion_pancake)");
    }
    public void Chooseegg2()
    {
        SceneManager.LoadScene("egg2(Scallion_pancake)");
    }
    public void Choosegreen_onion1()
    {
        SceneManager.LoadScene("green_onion1(Scallion_pancake)");
    }
    public void Choosegreen_onion2()
    {
        SceneManager.LoadScene("green_onion2(Scallion_pancake)");
    }



    public void CloseChoose()
    {
        // string returnScene = PlayerPrefs.GetString("ReturnScene", "MainScene");
        // SceneManager.LoadScene(returnScene);

        SceneManager.LoadScene("taiwan(Scallion_pancake)");
    }


}