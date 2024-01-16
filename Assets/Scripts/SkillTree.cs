using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    //Static Skill Tree Class
    public static SkillTree skilltree;
    //On Awake assign skill tree static to this gameobject
    private void Awake() => skilltree = this;
    //Public Skill attributes
    public int[] SkillLevels;
    public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;
    //Skill List
    public List<Skill> SkillList;
    //Skill Holder GameObject
    public GameObject SkillHolder;
    //Connector List
    public List<GameObject> ConnectorList;
    //Connector Holder GameObject
    public GameObject ConnectorHolder;
    //Skill Points
    public int SkillPoint;

    private void Start()
    {
        //your score in the game is converted to skill points
        //This is a place holder but we will convert your score into skill points
        SkillPoint = 20;
        //Ammount of skills
        SkillLevels = new int[6];
        //Skill level cap
        SkillCaps = new[] { 1, 5, 5, 2, 10, 10 };
        //Descriptions for the name of the skills
        SkillNames = new[]
        {
            "Upgrade 1",
            "Upgrade 2",
            "Upgrade 3",
            "Upgrade 4",
            "Upgrade 5",
            "Upgrade 6"
        };
        //Descriptions of the skills abilities
        SkillDescriptions = new[]
        {
            "Does a thing",
            "Does another thing",
            "Does another another thing",
            "Does another other thing",
            "Does nothing",
            "Does something"
        };
        //Adding skills to the skill list
        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>()) SkillList.Add(skill);
        //Adding connectors to the connector list
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>()) ConnectorList.Add(connector.gameObject);
        //Assigning id for each skill in skill list
        for (var i = 0; i < SkillList.Count; i++) SkillList[i].id = i;
        //This part of the code is to show how the skills connect to each other
        //Skill list [0] is the connection with the skills 1, 2, 3
        //Skill list [2] is the connection with the skills 4 and 5
        SkillList[0].ConnectedSkills = new[] { 1, 2, 3 };
        SkillList[2].ConnectedSkills = new[] { 4, 5 };
        //Calls Update All Skill UI
        UpdateAllSkillUI();
    }
    //Function Update All Skill UI
    public void UpdateAllSkillUI()
    {
        //Updates Each Skill in Skill List
        foreach (var skill in SkillList) skill.UpdateUI();
    }
}