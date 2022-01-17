using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LSystemGenerator : MonoBehaviour
{
    public Rule[] rules;
    public int ruleNow = 0;
    public string rootSentence;
    [Range(0, 10)]
    public int iterationLimit = 1;

    public bool randomIgnoreRuleModifier = true;
    [Range(0, 1)]
    public float chanceToIgnoreRule = 0.3f;

    private void Start()
    {
        Debug.Log(GenerateSentence(ruleNow));
    }

    

    public string GenerateSentence(int ruleNumber,string word = null)
    {
        if (word == null)
        {
            word = rootSentence;
        }
        return Generate(word, ruleNumber);
    }

    // private string GrowRecursive(string word, int iterationIndex = 0)
    // {
    //     if (iterationIndex >= iterationLimit)
    //     {
    //         return word;
    //     }
    //     StringBuilder newWord = new StringBuilder();

    //     foreach (var c in word)
    //     {
    //         newWord.Append(c);
    //         ProcessRulesRecursivelly(newWord, c, iterationIndex);
    //     }

    //     return newWord.ToString();
    // }

    // private void ProcessRulesRecursivelly(StringBuilder newWord, char c, int iterationIndex)
    // {
    //     foreach (var rule in rules)
    //     {
    //         if (rule.letter == c.ToString())
    //         {
    //             if (randomIgnoreRuleModifier && iterationIndex > 1)
    //             {
    //                 if (Random.value < chanceToIgnoreRule)
    //                 {
    //                     return;
    //                 }
    //             }
    //             newWord.Append(GrowRecursive(rule.GetResult(), iterationIndex + 1));
    //         }

    //     }
    // }
    public string Generate(string word, int ruleNumber)
    {

        string temp;
        int iterationIndex = 0;

        for (int i = 0; i < iterationLimit; i++)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char item in word)
            {
                temp = sb.ToString();
                for (int j = 0; j < rules[ruleNumber].datas.Length; j++)
                {
                    if (item == rules[ruleNumber].datas[j].letter)
                    {
                        if (randomIgnoreRuleModifier && iterationIndex > 0)
                        {
                            if (Random.value < chanceToIgnoreRule)
                            {

                            }
                            else
                            {
                                sb.Append(rules[ruleNumber].GetResult(j));
                            }
                        }
                        else
                        {
                            sb.Append(rules[ruleNumber].datas[j].results[0]);
                        }

                    }

                }
                if (temp == sb.ToString())
                {
                    sb.Append(item);
                }
            }
            word = sb.ToString();
            iterationIndex++;
        }

        return word;
    }
}