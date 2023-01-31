using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text target;
    [SerializeField] private TMP_Text point;
    // Start is called before the first frame update

    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject playCanvas;
    [SerializeField] GameObject endCanvas;
    [SerializeField] private int[] numbers = Enumerable.Repeat(100, 3).ToArray();
    [SerializeField] private string[] names = new string[3];
    void Start(){
        int i = 0;
        while (i < 3)
        {
            numbers[i] = NewNumber(7);
            names[i] = GetFruitName(numbers[i]);
            i++;
        }

        target.text = "Bạn cần Thu thập: \n3 "+names[0]+", \n3 "+names[1]+", \n3 "+names[2];
        numbers = Enumerable.Repeat(0, 3).ToArray();
        point.text =    names[0]+": "+numbers[0]+"/3\n"+
                        names[1]+": "+numbers[1]+"/3\n"+
                        names[2]+": "+numbers[2]+"/3\n";
    }

    private string GetFruitName(int v){
        switch (v)
        {
            case 0:
                return "apple";
            case 1:
                return "bananas";
            case 2:
                return "cherries";
            case 3:
                return "kiwi";
            case 4:
                return "melon";
            case 5:
                return "orange";
            case 6:
                return "pineapple";
            default:
                return "strawberry";
        }
    }
    public int NewNumber(int r){
        int a = Random.Range(0, r);
        while (numbers.Contains(a))
        {
            a = Random.Range(0, r);
        }
        return a;
    }
    public void ClickStart(){
        startCanvas.SetActive(false);
        playCanvas.SetActive(true);
    }
    public void endGame(){
        playCanvas.SetActive(false);
        endCanvas.SetActive(true);
    }
}
