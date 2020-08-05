using Exiled.API.Features;
using Exiled.Events;
using Exiled.Events.EventArgs;
using Respawning;
using Respawning.NamingRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCassieEventbc
{
    public class EventHandlers
    {
        private Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        public void AnnouncingDecontamination(AnnouncingDecontaminationEventArgs ev)
        {
            switch (ev.Id)
            {
                case 0:
                    {
                        Map.Broadcast(15, Configs.DecontaminationInit);
                        break;
                    }
                case 1:
                    {
                        Map.Broadcast(15, Configs.DecontaminationMinutesCount.Replace("{0}", "10"));
                        break;
                    }
                case 2:
                    {
                        Map.Broadcast(15, Configs.DecontaminationMinutesCount.Replace("{0}", "5"));
                        break;
                    }
                case 3:
                    {
                        Map.Broadcast(15, Configs.DecontaminationMinutesCount.Replace("{0}", "1"));
                        break;
                    }
                case 4:
                    {
                        Map.Broadcast(15, Configs.Decontamination30s);
                        break;
                    }
            }
        }
        public void OnDecontaminating(DecontaminatingEventArgs ev)
        {
            Map.Broadcast(15, Configs.DecontaminationLockdown);
        }

        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            int curgen = Generator079.mainGenerator.NetworktotalVoltage + 1;
            if (curgen < 5)
            {
                Map.Broadcast(10, Configs.GeneratorFinish.Replace("{0}", curgen.ToString()));
            }
            else
            {
                Map.Broadcast(20, Configs.GeneratorComplete);
            }
        }
        public void AlphaStart(StartingEventArgs ev)
        {
            bool isresumed = AlphaWarheadController._resumeScenario != -1;
            double left = isresumed ? AlphaWarheadController.Host.timeToDetonation : AlphaWarheadController.Host.timeToDetonation - 4;
            double count = Math.Truncate(left / 10.0) * 10.0;
            if (!isresumed)
            {
                Map.Broadcast(15, Configs.AlphaWarheadStart.Replace("{0}", count.ToString()));
            }
            else
            {
                Map.Broadcast(10, Configs.AlphaWarheadResume.Replace("{0}", count.ToString()));
            }
        }
        public void AlohaStop(StoppingEventArgs ev)
        {
            Map.Broadcast(7, Configs.AlphaWarheadCancel);
        }
        public void Died(DiedEventArgs ev)
        {
            var damagetypes = ev.HitInformations.GetDamageType();
            var targetrole = ev.Target.ReferenceHub.characterClassManager._prevId;
            string fullname = CharacterClassManager._staticClasses.Get(targetrole).fullName;
            if (ev.Target.Team == Team.SCP)
            {
                if (damagetypes == DamageTypes.Tesla)
                {
                    Map.Broadcast(10, Configs.SCPDeathTesla.Replace("{0}", fullname));
                }
                if (damagetypes == DamageTypes.Nuke)
                {
                    Map.Broadcast(10, Configs.SCPDeathWarhead.Replace("{0}", fullname));
                }
                if (damagetypes == DamageTypes.Decont)
                {
                    Map.Broadcast(10, Configs.SCPDeathDecont.Replace("{0}", fullname));
                }
            }
            else if (ev.Target.Team == Team.SCP)
            {
                if (ev.Killer.Team == Team.CDP)
                {
                     Map.Broadcast(10, Configs.SCPDeathTerminated.Replace("{0}", fullname).Replace("{1}", "Class-D Personnel"));
                }
                else if (ev.Killer.Team == Team.CDP && Player.List.Any(x => x.Role == RoleType.Scp079) && Player.List.Count(x => x.Team == Team.SCP) == 1
                    && Generator079.mainGenerator.totalVoltage < 4 && !Generator079.mainGenerator.forcedOvercharge && damagetypes != DamageTypes.Nuke)
                {
                    Map.Broadcast(10, Configs.SCPDeathTerminated.Replace("{0}", fullname).Replace("{1}", "Class-D Personnel").Replace("{-2}", "All SCP subject has been secured.SCP - 079 recontainment sequence commencing.\nHeavy containment zone will overcharge in t - minus 1 minutes."));
                }
                else if (ev.Killer.Team == Team.CHI)
                {
                    Map.Broadcast(10, Configs.SCPDeathTerminated.Replace("{0}", fullname).Replace("{1}", "Chaos Insurgency"));
                }
                else if (ev.Killer.Team == Team.CHI && Player.List.Any(x => x.Role == RoleType.Scp079) && Player.List.Count(x => x.Team == Team.SCP) == 1
                    && Generator079.mainGenerator.totalVoltage < 4 && !Generator079.mainGenerator.forcedOvercharge && damagetypes != DamageTypes.Nuke)
                {
                    Map.Broadcast(10, Configs.SCPDeathTerminated.Replace("{0}", fullname).Replace("{1}", "Chaos Insurgency"));
                }
                else if (ev.Killer.Team == Team.RSC)
                {
                    Map.Broadcast(10, Configs.SCPDeathTerminated.Replace("{0}", fullname).Replace("{1}", "Scientist"));
                }
                else if (ev.Killer.Team == Team.RSC && Player.List.Any(x => x.Role == RoleType.Scp079) && Player.List.Count(x => x.Team == Team.SCP) == 1
                    && Generator079.mainGenerator.totalVoltage < 4 && !Generator079.mainGenerator.forcedOvercharge && damagetypes != DamageTypes.Nuke)
                {
                    Map.Broadcast(10, Configs.SCPDeathTerminated.Replace("{0}", fullname).Replace("{1}", "Scientist"));
                }
                else if (ev.Killer.Team == Team.MTF)
                {
                    Map.Broadcast(10, Configs.SCPDeathContainedMTF.Replace("{0}", fullname).Replace("{1}", ev.Killer.ReferenceHub.characterClassManager.CurUnitName));
                }
                else if (ev.Killer.Team == Team.MTF && Player.List.Any(x => x.Role == RoleType.Scp079) && Player.List.Count(x => x.Team == Team.SCP) == 1
                    && Generator079.mainGenerator.totalVoltage < 4 && !Generator079.mainGenerator.forcedOvercharge && damagetypes != DamageTypes.Nuke)
                {
                    Map.Broadcast(10, Configs.SCPDeathContainedMTF.Replace("{0}", fullname).Replace("{1}", ev.Killer.ReferenceHub.characterClassManager.CurUnitName));
                }
                else
                {
                    Map.Broadcast(10, Configs.SCPDeathUnknown.Replace("{0}", fullname));
                }
            }

        }
    }
}
