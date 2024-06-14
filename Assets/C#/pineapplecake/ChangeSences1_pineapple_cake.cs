using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSences1_pineapple_cake : MonoBehaviour
{
    public string sceneToLoad;
    public Text collectedIngredientsText;
    public Text UncollectedIngredientsText;
    public GameObject GameObject;

    public Sprite questionMarkSprite;
    public Image[] ingredientSlots;
    public Sprite[] ingredientSprites;
    public List<string> objetfoods = new List<string> { "butter1", "butter2", "pineapple1", "pineapple2", "egg1", "egg2" };
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
        int size = ingredients.Count;
        // foreach (string ingredient in ingredients)
        List<string> newingredients;




        newingredients = DisplayCollectedIngredient(ingredients);
        collectfood.Instance.OnIngredientsChanged(newingredients);
        // foreach (string ingredient in ingredients)


        foreach (Transform child in GameObject.transform)
        {
            // Debug.Log(123456789);
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

        // Remove the collected ingredients
        foreach (string ingredient in ingredientsToRemove)
        {
            ingredients.Remove(ingredient);
        }
        collectfood.Instance.OnUNIngredientsChanged(ingredientsToRemove);
        int i = 0;
        foreach (string ingredient in ingredients)
        {
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
            case "pineapple1":
                return ingredientSprites[6];
            case "pineapple2":
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


    public void Choose蔥1()
    {
        SceneManager.LoadScene("蔥1");
    }
    public void Choose蔥2()
    {
        SceneManager.LoadScene("蔥2");
    }
    public void Choosebutter1()
    {
        SceneManager.LoadScene("butter1");
    }
    public void Choosebutter2()
    {
        SceneManager.LoadScene("butter2");
    }
    public void Choosepineapple1()
    {
        SceneManager.LoadScene("pineapple1");
    }
    public void Choosepineapple2()
    {
        SceneManager.LoadScene("pineapple2");
    }
    public void Chooseflour1()
    {
        SceneManager.LoadScene("flour1");
    }
    public void Chooseflour2()
    {
        SceneManager.LoadScene("flour2");
    }
    public void Chooseegg1()
    {
        SceneManager.LoadScene("egg1");
    }
    public void Chooseegg2()
    {
        SceneManager.LoadScene("egg2");
    }
    public void Choosegreen_onion1()
    {
        SceneManager.LoadScene("green_onion1");
    }
    public void Choosegreen_onion2()
    {
        SceneManager.LoadScene("green_onion2");
    }



    public void CloseChoose()
    {
        // string returnScene = PlayerPrefs.GetString("ReturnScene", "MainScene");
        // SceneManager.LoadScene(returnScene);

        SceneManager.LoadScene("taiwan(pineapple_cake) 1");
    }


}