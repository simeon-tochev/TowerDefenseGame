using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct CellWrapper
{
    public CellWrapper(char type, float posX, float posY, bool upgrade1, bool upgrade2, int killCount, int dmgCount) {
        this.type = type;
        this.posX = posX;
        this.posY = posY;
        this.upgrade1 = upgrade1;
        this.upgrade2 = upgrade2;
        this.killCount = killCount;
        this.dmgCount = dmgCount;
    }

    public CellWrapper(Cell c) {
        type = c.type;
        posX = c.transform.position.x;
        posY = c.transform.position.y;
        upgrade1 = c.upgrade1Done;
        upgrade2 = c.upgrade2Done;
        killCount = c.killCount;
        dmgCount = c.damageDone;
    }

    public char type;
    public float posX;
    public float posY;
    public bool upgrade1;
    public bool upgrade2;
    public int killCount;
    public int dmgCount;
}
