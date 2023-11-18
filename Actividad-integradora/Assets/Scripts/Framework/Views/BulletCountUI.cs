using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCountUI : MonoBehaviour
{
    public ChestMonsterController chestMonsterController;
    public PinkMonsterController pinkMonsterController;
    
    public TextMeshProUGUI totalBulletText;

    private void Update()
    {
        // Get the total bullet count from both controllers
        int totalBulletCount = GetBulletCount(chestMonsterController) + GetBulletCount(pinkMonsterController);

        // Update the TextMeshPro text for the total bullet count
        totalBulletText.text = $"Total Bullet Count: {totalBulletCount}";
    }

    private int GetBulletCount(ChestMonsterController monsterController)
    {
        if (monsterController != null)
        {
            // Get the bullet count from the chest monster controller
            return monsterController.BulletCount();
        }

        return 0;
    }

    private int GetBulletCount(PinkMonsterController monsterController)
    {
        if (monsterController != null)
        {
            // Get the bullet count from the pink monster controller
            return monsterController.BulletCount();
        }

        return 0;
    }
}
