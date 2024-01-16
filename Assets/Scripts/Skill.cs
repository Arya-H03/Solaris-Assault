using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillTree;

public class Skill : MonoBehaviour
{
    public static SaveData saveData;
    public int id;
    public TMP_Text TitleText;
    public TMP_Text DescriptionText;

    public int[] ConnectedSkills;
    public void UpdateUI()
    {
        TitleText.text = $"{skilltree.SkillLevels[id]}/{skilltree.SkillCaps[id]}\n{skilltree.SkillNames[id]}";
        DescriptionText.text = $"{skilltree.SkillDescriptions[id]}\n Cost: {skilltree.SkillPoint}/1 SP ";

        GetComponent<Image>().color = skilltree.SkillLevels[id] >= skilltree.SkillCaps[id] ? Color.yellow : skilltree.SkillPoint >= 1 ? Color.green : Color.white;

        foreach (var connectedSkill in ConnectedSkills)
        {
            skilltree.SkillList[connectedSkill].gameObject.SetActive(skilltree.SkillLevels[id] > 0);
            skilltree.ConnectorList[connectedSkill].SetActive(skilltree.SkillLevels[id] > 0);
        }
    }
    public void Buy()
    {
        if (skilltree.SkillPoint < 1 || skilltree.SkillLevels[id] >= skilltree.SkillCaps[id]) return;
        skilltree.SkillPoint -= 1;
        skilltree.SkillLevels[id]++;
        saveData.skillLevels[id]++;
        skilltree.UpdateAllSkillUI();
    }
}