using System;

[Serializable]
public class RecordData
{
    public int turnDirect;
    public float recordTime;
    public float recordLength;


    public RecordData(int turnDirect, float recordTime, float recordLength)
    {
        this.turnDirect = turnDirect;
        this.recordTime = recordTime;
        this.recordLength = recordLength;
    }
}
