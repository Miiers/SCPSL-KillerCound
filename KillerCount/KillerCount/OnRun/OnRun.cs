using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using System;
using Smod2.Events;

namespace KillerCount.OnRun
{
    internal class OnRun: IEventHandler, IEventHandlerSpawn, IEventHandlerPlayerDie, IEventHandlerRoundRestart
    {
        private Plugin plugin;
        private int[] IDKillSCP = new int[200];
        private int[] IDKillCI = new int[200];
        private int[] IDKillMTF = new int[200];
        private int[] IDKillDD = new int[200];
        private int[] IDKillHuman = new int[200];
        private int[] IDKillSC = new int[200];
        private int num = 0;
        private bool kc_save;

        public OnRun(Plugin plugin)
        {
            this.plugin = plugin;

        }
        public void OnSpawn(PlayerSpawnEvent ev)
        {
            int scp = 0;
            int DD = 0;
            int CI = 0;
            int MTF = 0;
            int SC = 0;
            kc_save = plugin.GetConfigBool("kc_save");
            if (kc_save)
            {
                if (ev.Player.TeamRole.Team == Team.CHAOS_INSURGENCY)
                {
                    foreach (int i in IDKillSCP)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            scp++;
                        }
                    }
                    foreach (int i in IDKillMTF)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            MTF++;
                        }
                    }
                    foreach (int i in IDKillDD)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            DD++;
                        }
                    }
                    foreach (int i in IDKillCI)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            CI++;
                        }
                    }
                    foreach (int i in IDKillSC)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            SC++;
                        }
                    }
                    ev.Player.SetRank("default", "(" + ev.Player.PlayerId + ") 九尾: " + MTF + " 混沌: " + CI + " DD: " + DD + "博士: "+ SC +"  | SCP: " + scp, "");
                }
                else if (ev.Player.TeamRole.Team == Team.CLASSD)
                {
                    ev.Player.SetRank("default", "(" + ev.Player.PlayerId + ") 九尾: 0 混沌: 0 DD: 0 博士: 0 | SCP: 0");
                }
                else if (ev.Player.TeamRole.Team == Team.NINETAILFOX)
                {
                    foreach (int i in IDKillSCP)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            scp++;
                        }
                    }
                    foreach (int i in IDKillMTF)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            MTF++;
                        }
                    }
                    foreach (int i in IDKillDD)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            DD++;
                        }
                    }
                    foreach (int i in IDKillCI)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            CI++;
                        }
                    }
                    foreach (int i in IDKillSC)
                    {
                        if (i == ev.Player.PlayerId)
                        {
                            SC++;
                        }
                    }
                    ev.Player.SetRank("default", "(" + ev.Player.PlayerId + ") 九尾: " + MTF + " 混沌: " + CI + " DD: " + DD + "博士: " + SC + "  | SCP: " + scp, "");
                }
                else if (ev.Player.TeamRole.Team == Team.SCIENTIST)
                {
                    ev.Player.SetRank("default", "(" + ev.Player.PlayerId + ") 九尾: 0 混沌: 0 DD: 0 博士: 0 | SCP: 0");
                }
                else if(ev.Player.TeamRole.Team == Team.SCP)
                {
                    ev.Player.SetRank("yellow", "(" + ev.Player.PlayerId + ") 已杀死人类:0", "");
                }

            }
            else
            {
                if (ev.Player.TeamRole.Team == Team.CHAOS_INSURGENCY || ev.Player.TeamRole.Team == Team.CLASSD || ev.Player.TeamRole.Team == Team.NINETAILFOX || ev.Player.TeamRole.Team == Team.SCIENTIST)
                {
                    ev.Player.SetRank("default", "(" + ev.Player.PlayerId + ") 九尾: 0 混沌: 0 DD: 0 博士: 0 | SCP: 0");
                }
                else if(ev.Player.TeamRole.Team == Team.SCP)
                {
                    ev.Player.SetRank("yellow", "(" + ev.Player.PlayerId + ") 已杀死人类:0", "");
                }
            }
            scp = 0; 
            DD = 0; 
            CI = 0; 
            MTF = 0;
            SC = 0;
        }
        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            int KillerID = ev.Killer.PlayerId;
            int PlayerID = ev.Player.PlayerId;
            if (ev.Player.TeamRole.Role == Role.SCP_173) //如果死亡的是173
            {
                if (KillerID == PlayerID)
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP173</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>选择去世或被079上了</color>", false);
                }
                else
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP173</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    IDKillSCP[num] = KillerID; //杀死了SCP，把ID存进杀死的杀死SCP的数组里
                }
            }
            if (ev.Player.TeamRole.Role == Role.SCP_049) //如果死亡的是049
            {
                if (KillerID == PlayerID)
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP049</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>选择去世或被079上</color>", false);
                }
                else
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP049</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    IDKillSCP[num] = KillerID; //杀死了SCP，把ID存进杀死的杀死SCP的数组里
                }
            }
            if (ev.Player.TeamRole.Role == Role.SCP_079) //如果死亡的是079
            {
                this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP079</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>与设施断开连接</color>", false);
            }
            if (ev.Player.TeamRole.Role == Role.SCP_096) //如果死亡的是096
            {
                if (KillerID == PlayerID)
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP096</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>选择去世或被079上了</color>", false);
                }
                else
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP096</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    IDKillSCP[num] = KillerID; //杀死了SCP，把ID存进杀死的杀死SCP的数组里
                }
            }
            if (ev.Player.TeamRole.Role == Role.SCP_939_53) //如果死亡的是SCP_939_53
            {
                if (KillerID == PlayerID)
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP939_53</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>选择去世或被079上了</color>", false);
                }
                else
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP939_53</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    IDKillSCP[num] = KillerID; //杀死了SCP，把ID存进杀死的杀死SCP的数组里
                }
            }
            if (ev.Player.TeamRole.Role == Role.SCP_939_89) //如果死亡的是SCP_939_89
            {
                if (KillerID == PlayerID)
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP939_89</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>选择去世或被079上了</color>", false);
                }
                else
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP939_89</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    IDKillSCP[num] = KillerID; //杀死了SCP，把ID存进杀死的杀死SCP的数组里
                }
            }
            if (ev.Player.TeamRole.Role == Role.SCP_106) //如果死亡的是SCP106
            {
                if (KillerID == PlayerID)
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP106</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>选择去世或被079上了</color>", false);
                }
                else
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(12u, "----[<color=#32CD32>SCP106</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    IDKillSCP[num] = KillerID; //杀死了SCP，把ID存进杀死的杀死SCP的数组里
                }
            }
            if (ev.Player.TeamRole.Role == Role.CLASSD) //杀死了弟弟
            {
                if (ev.Killer.TeamRole.Team != Team.SCP)
                {
                    IDKillDD[num] = KillerID;
                }
                if (ev.Killer.TeamRole.Team == Team.SCP)
                {
                    IDKillHuman[num] = KillerID;
                }
            }
            if (ev.Player.TeamRole.Role == Role.CHAOS_INSURGENCY) //杀死了混沌
            {
                if (ev.Killer.TeamRole.Team != Team.SCP)
                {
                    IDKillCI[num] = KillerID;
                }
                if (ev.Killer.TeamRole.Team == Team.SCP)
                {
                    IDKillHuman[num] = KillerID;
                }
            }
            if (ev.Player.TeamRole.Role == Role.FACILITY_GUARD) //杀死了保安
            {
                if (ev.Killer.TeamRole.Team != Team.SCP)
                {
                    IDKillMTF[num] = KillerID;
                }
                if (ev.Killer.TeamRole.Team == Team.SCP)
                {
                    IDKillHuman[num] = KillerID;
                }
            }
            if (ev.Player.TeamRole.Role == Role.NTF_CADET) //杀死了学员
            {
                if (ev.Killer.TeamRole.Team == Team.SCP)
                {
                    IDKillHuman[num] = KillerID;
                }
                if (ev.Killer.TeamRole.Team != Team.SCP)
                {
                    IDKillMTF[num] = KillerID;
                }
            }
            if (ev.Player.TeamRole.Role == Role.NTF_COMMANDER) //杀死了指挥官
            {
                if (ev.Killer.TeamRole.Team == Team.SCP)
                {
                    IDKillHuman[num] = KillerID;
                }
                if (ev.Killer.TeamRole.Team != Team.SCP)
                {
                    IDKillMTF[num] = KillerID;
                }
            }
            if (ev.Player.TeamRole.Role == Role.NTF_LIEUTENANT) //杀死了副官
            {
                if (ev.Killer.TeamRole.Team == Team.SCP)
                {
                    IDKillHuman[num] = KillerID;
                }
                if (ev.Killer.TeamRole.Team != Team.SCP)
                {
                    IDKillMTF[num] = KillerID;
                }
            }
            if (ev.Player.TeamRole.Role == Role.NTF_SCIENTIST) //杀死了九尾科学家
            {
                if (ev.Killer.TeamRole.Team == Team.SCP)
                {
                    IDKillHuman[num] = KillerID;
                }
                if (ev.Killer.TeamRole.Team != Team.SCP)
                {
                    IDKillMTF[num] = KillerID;
                }
            }
            if (ev.Player.TeamRole.Role == Role.SCIENTIST) //杀死了科学家
            {
                if (ev.Killer.TeamRole.Team == Team.SCP) 
                {
                    IDKillHuman[num] = KillerID;
                }
                if (ev.Killer.TeamRole.Team != Team.SCP)
                {
                    IDKillSC[num] = KillerID;
                }
            }

            int scp = 0; //scp击杀次数
            int DD = 0; //dd击杀次数
            int Human = 0; //人类击杀次数
            int CI = 0; //ci击杀次数
            int MTF = 0; //mtf击杀次数
            int SC = 0;

            if (ev.Killer.TeamRole.Team == Team.CHAOS_INSURGENCY) ////////////////////////CI
            {
                foreach (int i in IDKillSCP) //scp杀手
                {
                    if (i == KillerID) //如果获取到了该玩家曾经杀过SCP
                    {
                        scp++; //记录击杀的次数
                    }
                }
                foreach (int i in IDKillMTF) //MTF杀手
                {
                    if (i == KillerID)
                    {
                        MTF++;
                    }
                }
                foreach (int i in IDKillDD) //DD杀手
                {
                    if (i == KillerID)
                    {
                        DD++;
                    }
                }
                foreach (int i in IDKillCI) //混沌杀手
                {
                    if (i == KillerID)
                    {
                        CI++;
                    }
                }
                foreach (int i in IDKillSC)
                {
                    if (i == ev.Player.PlayerId)
                    {
                        SC++;
                    }
                }
                ev.Killer.SetRank("default", "(" + ev.Player.PlayerId + ") 九尾: " + MTF + " 混沌: " + CI + " DD: " + DD + "博士: " + SC + "  | SCP: " + scp, "");
            }
            else if (ev.Killer.TeamRole.Team == Team.NINETAILFOX) ///////////////////////九尾
            {
                foreach (int i in IDKillSCP) //scp杀手
                {
                    if (i == KillerID) //如果获取到了该玩家曾经杀过SCP
                    {
                        scp++; //记录击杀的次数
                    }
                }
                foreach (int i in IDKillMTF) //MTF杀手
                {
                    if (i == KillerID)
                    {
                        MTF++;
                    }
                }
                foreach (int i in IDKillDD) //DD杀手
                {
                    if (i == KillerID)
                    {
                        DD++;
                    }
                }
                foreach (int i in IDKillCI) //混沌杀手
                {
                    if (i == KillerID)
                    {
                        CI++;
                    }
                }
                foreach (int i in IDKillSC)
                {
                    if (i == ev.Player.PlayerId)
                    {
                        SC++;
                    }
                }
                ev.Killer.SetRank("default", "(" + ev.Player.PlayerId + ") 九尾: " + MTF + " 混沌: " + CI + " DD: " + DD + "博士: " + SC + "  | SCP: " + scp, "");
            }
            else if (ev.Killer.TeamRole.Team == Team.SCIENTIST) ////////////////////////科学家
            {
                foreach (int i in IDKillSCP) //scp杀手
                {
                    if (i == KillerID) //如果获取到了该玩家曾经杀过SCP
                    {
                        scp++; //记录击杀的次数
                    }
                }
                foreach (int i in IDKillMTF) //MTF杀手
                {
                    if (i == KillerID)
                    {
                        MTF++;
                    }
                }
                foreach (int i in IDKillDD) //DD杀手
                {
                    if (i == KillerID)
                    {
                        DD++;
                    }
                }
                foreach (int i in IDKillCI) //混沌杀手
                {
                    if (i == KillerID)
                    {
                        CI++;
                    }
                }
                foreach (int i in IDKillSC)
                {
                    if (i == ev.Player.PlayerId)
                    {
                        SC++;
                    }
                }
                ev.Killer.SetRank("default", "(" + ev.Player.PlayerId + ") 九尾: " + MTF + " 混沌: " + CI + " DD: " + DD + "博士: " + SC + "  | SCP: " + scp, "");
            }
            else if (ev.Killer.TeamRole.Team == Team.CLASSD) //////////////////////////////DD
            {
                foreach (int i in IDKillSCP) //scp杀手
                {
                    if (i == KillerID) //如果获取到了该玩家曾经杀过SCP
                    {
                        scp++; //记录击杀的次数
                    }
                }
                foreach (int i in IDKillMTF) //MTF杀手
                {
                    if (i == KillerID)
                    {
                        MTF++;
                    }
                }
                foreach (int i in IDKillDD) //DD杀手
                {
                    if (i == KillerID)
                    {
                        DD++;
                    }
                }
                foreach (int i in IDKillCI) //混沌杀手
                {
                    if (i == KillerID)
                    {
                        CI++;
                    }
                }
                foreach (int i in IDKillSC)
                {
                    if (i == ev.Player.PlayerId)
                    {
                        SC++;
                    }
                }
                ev.Killer.SetRank("default", "(" + ev.Player.PlayerId + ") 九尾: " + MTF + " 混沌: " + CI + " DD: " + DD + "博士: " + SC + "  | SCP: " + scp, "");
            }
            else if (ev.Killer.TeamRole.Team == Team.SCP) ///////////////////////////////////SCP
            {
                foreach (int a in IDKillHuman) //循环遍历人类杀手
                {
                    if (a == KillerID) //如果获取到了该玩家曾经杀过DD
                    {
                        //记录击杀的次数
                        Human++;
                    }
                }
                ev.Killer.SetRank("yellow", "(" + ev.Player.PlayerId + ") 已杀死人类:" + Human, "");
            }
            //重置变量
            scp = 0;
            DD = 0;
            Human = 0;
            SC = 0;
            KillerID = 0;
            PlayerID = 0;
            this.num++;
        }
        public void OnRoundRestart(RoundRestartEvent ev)
        {
            Array.Clear(IDKillSCP, 0, IDKillSCP.Length);
            Array.Clear(IDKillCI, 0, IDKillCI.Length);
            Array.Clear(IDKillMTF, 0, IDKillMTF.Length);
            Array.Clear(IDKillDD, 0, IDKillDD.Length);
            Array.Clear(IDKillHuman, 0, IDKillHuman.Length);
            Array.Clear(IDKillSC, 0, IDKillSC.Length);
            num = 0;
        }
    }
}