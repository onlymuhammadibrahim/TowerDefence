using UnityEngine;
using System.Collections;

public class TowerManager : Singleton<TowerManager> {

    private TowerButton towerButtonPressed;

    public void SelectedTower(TowerButton towerSelected)
    {
        towerButtonPressed = towerSelected;
        Debug.Log("pressed" + towerButtonPressed.gameObject);
    }

}
