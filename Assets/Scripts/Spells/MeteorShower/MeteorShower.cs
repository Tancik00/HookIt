using UnityEngine;

public class MeteorShower : Spell
{
    [Header("Status")]
    public bool Status = false;

    [Header("Attribute")]
    public float Damage;
    public float Radius;
    public float Duration;
    public float Interval;
    public int countPerWave;

    //[SerializeField]
    //private AttributeSpell _attribute;
    //public override AttributeSpell A_Attribute{get { return _attribute;} set{ _attribute = value;}}


    [Header("Ref")]
    public GameObject epicenterPrefab;

    private Vector3 p_pointCast;

    public override void A_ActivateSpell(Vector3 _point)
    {
        p_pointCast = new Vector3(_point.x, 0.5f, _point.z);
        Status = true;
    }

    private void Update()
    {
        if(Status)
        {
            var temp = Instantiate(epicenterPrefab, p_pointCast, Quaternion.identity).GetComponent<Epicentr>();
            temp.Init(Damage, Duration, Radius, Interval, countPerWave, p_pointCast);
            Status = false;
        }
    }
}
