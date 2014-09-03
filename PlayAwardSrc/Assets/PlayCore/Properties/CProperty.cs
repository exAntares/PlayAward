using UnityEngine;
using System;
using System.Collections;

//[System.Serializable]
[AddComponentMenu("")]
public abstract class CProperty<TValue> : CPropertyBase
{
    #region Fields
    //Private----------
    [SerializeField]
    private TValue _value;
    //-----------------
    //Public ----------
    public TValue Value
    {
        set 
        {
            if (!_value.Equals(value))
            {
                OnPropertyChanged(_value, value);
                _value = value; 
            }            
        }
        get { return _value; }
    }

    public PropertyChangeHandler PropertyChanged;
    //-----------------
    #endregion

    #region Methods
    //Public ----------
    public delegate void PropertyChangeHandler(CProperty<TValue> sender, TValue oldValue, TValue newValue);

    //Conversion operator
    public static implicit operator TValue(CProperty<TValue> property)
    {
        return property.Value;
    }

    public override Type ValueType { get{ return typeof(TValue);} }

    public override void SetValue(CPropertyBase srcBaseProp)
    {
        CProperty<TValue> srcProp = srcBaseProp as CProperty<TValue>;
        if (srcProp)
            Value = srcProp.Value;
    }

    public override bool IsSameValue(CPropertyBase srcBaseProp)
    {
        CProperty<TValue> srcProp = srcBaseProp as CProperty<TValue>;
        return Equals(Value, srcProp.Value);
    }    
    //-----------------

    //Private ---------
    private void OnPropertyChanged(TValue oldValue, TValue newValue)
    {
        PropertyChangeHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, oldValue, newValue);
    }
    //-----------------
    #endregion

}
