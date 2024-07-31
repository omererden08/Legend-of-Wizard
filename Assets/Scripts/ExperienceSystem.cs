using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    //Experience
    [SerializeField] private int currentLevel;
    [SerializeField] private int currentExperience;
    [SerializeField] private int maxExperience;
    [SerializeField] private int newExperience;


    private void Start()
    {   
        currentLevel = 0;
        currentExperience = 0;
        maxExperience = 100;
        newExperience = 20;
        print(maxExperience + "need exp to level up");
    }
    public void HandleExperienceChange()
    {    
        currentExperience += newExperience;
        if (currentExperience > maxExperience)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        print("level up");
        currentExperience = 0;
        currentLevel += 1;
        maxExperience *= 2;
        print(maxExperience + "need exp to level up");
    }
}
