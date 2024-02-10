using HarmonyLib;
using UnityEngine;

namespace LethalCompanyTemplate.Patches
{
    public class ModifyQuotaSettings : MonoBehaviour
    {
        void Start()
        {
            QuotaSettings quotaSettings = GetComponent<QuotaSettings>();
            if (quotaSettings != null)
            {
                quotaSettings.deadlineDaysAmount = 5;
                quotaSettings.startingQuota = 1000;
                quotaSettings.startingCredits = 1000;
            }
        }
    }

}

