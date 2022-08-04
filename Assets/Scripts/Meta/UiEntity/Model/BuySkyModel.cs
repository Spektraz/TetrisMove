using System;
using MVC.Model;
using UnityEngine;
using Utils;

namespace Meta.UiEntity.Model
{
    [Serializable]
    [CreateAssetMenu(fileName = "SkyModel", menuName = "Model/Meta/SkyModel")]
    public class BuySkyModel : ScriptableObject, IModel
    {
        [SerializeField] private BuySkyList buySkyList; 
        public InternalSkyPreset GetByName(SkyboxName skyboxName) => buySkyList.GetById(skyboxName);
    }
    [Serializable]
    public class BuySkyList : DataList<BuySkyPreset, InternalSkyPreset, SkyboxName>{}
    
    [Serializable]
    public class BuySkyPreset : InternalData<SkyboxName, InternalSkyPreset>{}

    [Serializable]
    public class InternalSkyPreset
    {        
        [SerializeField] private Material skyBox;
        [SerializeField] private int priceSkybox;
        public Material SkyBox => skyBox;
        public int PriceSkybox => priceSkybox;
    }
    public enum SkyboxName
    {
        Brown = 0,
        Black = 1,
        Orange = 2,
        BluePink =3, 
        Blue = 4, 
        Pink = 5,
        Malohit = 6,
        Unset = 999,
    }
}