using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Button generate;
    [SerializeField]
    private Button addRule;
    [SerializeField]
    private Button reduceRule;
    [SerializeField]
    private Text ruleNumber;
    [SerializeField]
    private Button addIteration;
    [SerializeField]
    private Button reduceIteration;
    [SerializeField]
    private Text iterationNumber;
    [SerializeField]
    private Button addLength;
    [SerializeField]
    private Button reduceLength;
    [SerializeField]
    private Text lengthNumber;
    public LSystemGenerator lSystemGenerator;
    public Visualizer visualizer;

    private void Start()
    {
        ruleNumber.text = lSystemGenerator.ruleNow.ToString();
        iterationNumber.text = lSystemGenerator.iterationLimit.ToString();
        lengthNumber.text = visualizer.roadLength.ToString();
    }
    public void RuleAdd()
    {
        lSystemGenerator.ruleNow++;
        ruleNumber.text = lSystemGenerator.ruleNow.ToString();
    }

    public void RuleReduce()
    {
        lSystemGenerator.ruleNow--;
        ruleNumber.text = lSystemGenerator.ruleNow.ToString();
    }

    public void Generate()
    {
        visualizer.CreateTown(lSystemGenerator.ruleNow);
    }

    public void IterationAdd()
    {
        lSystemGenerator.iterationLimit++;
        iterationNumber.text = lSystemGenerator.iterationLimit.ToString();
    }

    public void IterationReduce()
    {
        lSystemGenerator.iterationLimit--;
        iterationNumber.text = lSystemGenerator.iterationLimit.ToString();
    }

    public void LengthAdd()
    {
        visualizer.roadLength++;
        lengthNumber.text = visualizer.roadLength.ToString();
    }

    public void LengthReduce()
    {
        visualizer.roadLength--;
        lengthNumber.text = visualizer.roadLength.ToString();
    }

}
