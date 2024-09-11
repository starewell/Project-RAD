using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUnitFrame : MonoBehaviour {

    [SerializeField] Image friendlyGear, enemyGear;
    [SerializeField] GameObject friendlyFrame, enemyFrame, fragile;
    public void Init(GridElement ge) {
        bool friendly = ge is not EnemyUnit;        
        friendlyFrame.SetActive(friendly);
        enemyFrame.SetActive(!friendly);
        Image gear = friendly ? friendlyGear : enemyGear;
        if (!friendly) {
            EnemyUnit e = (EnemyUnit)ge;
            GearData data = e.equipment[1];
            GetComponentInChildren<GearTooltipTrigger>().Initialize(data);
            if (ge is Unit u && u.fragile) {
                fragile.SetActive(true);
            }
            gear.sprite = data.icon;
        } else if (ge is Nail) {
            gear.gameObject.SetActive(true);
            GetComponentInChildren<GearTooltipTrigger>().Initialize("Thorns");
        }
    }

    public void BecomeFragile() {
        fragile.SetActive(true);
    }

}
