using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCassieEventbc
{
    public class Configs : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public static string DecontaminationInit { get; set; } = "<size=30><color=purple>Attention, all personnel, the Light Containment Zone decontamination process will occur in t-minus 15 minutes. \nAll biological substances must be removed in order to avoid destruction.</color></size>";
        public static string DecontaminationMinutesCount { get; set; } = "<size=30><color=purple>Danger, Light Containment zone overall decontamination in T-minus {0} Minutes.</color></size>";
        public static string Decontamination30s { get; set; } = "<size=30><color=purple>Danger, Light Containment Zone overall decontamination in T-minus 30 seconds.\nAll checkpoint doors have been permanently opened. Please evacuate immediately.</color></size>";
        public static string DecontaminationLockdown { get; set; } = "<size=30><color=purple>Light Containment Zone is locked down and ready for decontamination. The removal of organic substances has now begun.</color></size>";
        public static string DecontEvent { get; set; } = "Decontamination process for Light Containment Zone has been started. SCP subject in zone will be destroyed.";
        public static string GeneratorFinish { get; set; } = "<size=30><color=blue>{0} out of 5 generators activated.</color></size>";
        public static string GeneratorComplete { get; set; } = "<size=30><color=blue>5 out of 5 generators activated.\nAll generators has been sucessfully engaged.\nFinalizing recontainment sequence.\nHeavy containment zone will overcharge in t-minus 1 minutes.</color></size>";
        public static string Generatorofflight { get; set; } = "All SCP subject has been secured. SCP-079 recontainment sequence commencing.\nHeavy containment zone will overcharge in t-minus 1 minutes.";
        public static string AlphaWarheadStart { get; set; } = "<size=30><color=purple>Alpha Warhead emergency detonation sequence engaged.\nThe underground section of the facility will be detonated in t-minus {0} seconds.</color></size>";
        public static string AlphaWarheadResume { get; set; } = "<size=30><color=purple>Detonation sequence resumed. t-minus {0} seconds.</color></size>";
        public static string AlphaWarheadCancel { get; set; } = "Detonation cancelled. Restarting systems.";
        public static string SCPDeathTesla { get; set; } = "{0} successfully terminated by automatic security system.";
        public static string SCPDeathWarhead { get; set; } = "{0} terminated by alpha warhead.";
        public static string SCPDeathDecont { get; set; } = "{0} lost in decontamination sequence.";
        public static string SCPDeathTerminated { get; set; } = "{0} terminated by {1}.{-1}";
        public static string SCPDeathContainedMTF { get; set; } = "{0} contained successfully. Containment unit:{1}.{-2}";
        public static string SCPDeathUnknown { get; set; } = "{0} successfully terminated. Termination cause unspecified.{-2}";
        public static string MTFRespawnSCPS { get; set; } = "<size=20><color=blue>Mobile Task Force Unit, Epsilon-11, designated, '{0}', has entered the facility.\nAll remaining personnel are advised to proceed with standard evacuation protocols until an MTF squad reaches your destination.\nAwaiting recontainment of: {1} SCP subject.</color></size>";
        public static string MTFRespawnNOSCP { get; set; } = "<size=20><color=blue>Mobile Task Force Unit, Epsilon-11, designated, '{0}', has entered the facility.\nAll remaining personnel are advised to proceed with standard evacuation protocols, until MTF squad has reached your destination.\nSubstantial threat to safety is within the facility -- Exercise caution.</color></size>";
    }   
         
}
