using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace OpenkoreUtil
{
    public partial class Form1 : Form
    {
        string configFileRoot = null;
        string configData = null;
        Config conf = new Config();
        public Form1()
        {
            InitializeComponent();
        }
        class Config
        {
            public Config()
            {

            }
            public string GetConfigData(string input, string regtext, string replace,int usetrim)
            {

                Regex reg = new Regex(regtext);
                MatchCollection resultColl = reg.Matches(input);
                if (resultColl.Count > 0)
                {
                    string temp = resultColl[0].Value;
                    if(usetrim == 1) {
                        return temp.Replace(replace, "").Trim();
                    }
                    else
                    {
                        return temp.Replace(replace, "");
                       
                    }
                }
                else
                {
                    return "없음";
                }
            }
            public string GetConfigDataLine(string filename,int number)
            {
                string line;
                int i = 0;
                using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default))
                {
                  
                    while ((line = sr.ReadLine()) != null)
                    {
                        i++;
                        if (number == i)
                        {
                            return line;
                        }
                        
                    }
                }
                return line;
            }
            public void InfoChange(string filename,string data,string type,string param1,string param2)
            {
                data = data.Replace(type + param1,type+param2);
                File.WriteAllText(filename, data);
            }
        }

        private void FileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPanel = new OpenFileDialog();
            openPanel.InitialDirectory = "d:\\";
            openPanel.Filter = "config.txt (config.txt)|config.txt";
            if (openPanel.ShowDialog() == DialogResult.OK)
            {
                configFileRoot = openPanel.FileName;
                Status.Text = "파일이 선택되었습니다." + configFileRoot;
                configData = File.ReadAllText(configFileRoot);
                id.Text = conf.GetConfigData(configData, @"username (.*)", "username",1);
                pw.Text = conf.GetConfigData(configData, @"password (.*)", "password", 1);
                pw2.Text = conf.GetConfigData(configData, @"loginPinCode (.*)", "loginPinCode", 1);
                alias.Text = conf.GetConfigData(configData, @"alias_(.*)", "alias_", 0);
                attackAuto.Text = conf.GetConfigData(configData, @"attackAuto [0-2]", "attackAuto", 1);
                attackAuto_party.Text = conf.GetConfigData(configData, @"attackAuto_party [0-2]", "attackAuto_party", 1);
                attackAuto_onlyWhenSafe.Text = conf.GetConfigData(configData, @"attackAuto_onlyWhenSafe [0-2]", "attackAuto_onlyWhenSafe", 1);
                attackAuto_inLockOnly.Text = conf.GetConfigData(configData, @"attackAuto_inLockOnly [0-2]", "attackAuto_inLockOnly", 1);
                attackDistance.Text = conf.GetConfigData(configData, @"attackDistance (.*)", "attackDistance", 1);
                attackMaxDistance.Text = conf.GetConfigData(configData, @"attackMaxDistance (.*)", "attackMaxDistance", 1);
                attackDistanceAuto.Text = conf.GetConfigData(configData, @"attackDistanceAuto [0-2]", "attackDistanceAuto", 1);
                attackMaxRouteDistance.Text = conf.GetConfigData(configData, @"attackMaxRouteDistance ([0-9]*)", "attackMaxRouteDistance", 1);
                attackMaxRouteTime.Text = conf.GetConfigData(configData, @"attackMaxRouteTime ([0-9]*)", "attackMaxRouteTime", 1);
                attackMinPlayerDistance.Text = conf.GetConfigData(configData, @"attackMinPlayerDistance (.*)", "attackMinPlayerDistance", 1);
                attackMinPortalDistance.Text = conf.GetConfigData(configData, @"attackMinPortalDistance (.*)", "attackMinPortalDistance", 1);
                attackUseWeapon.Text = conf.GetConfigData(configData, @"attackUseWeapon [0-2]", "attackUseWeapon", 1);
                attackNoGiveup.Text = conf.GetConfigData(configData, @"attackNoGiveup [0-2]", "attackNoGiveup", 1);
                attackCanSnipe.Text = conf.GetConfigData(configData, @"attackCanSnipe [0-2]", "attackCanSnipe", 1);
                attackCheckLOS.Text = conf.GetConfigData(configData, @"attackCheckLOS [0-2]", "attackCheckLOS", 1);
                aggressiveAntiKS.Text = conf.GetConfigData(configData, @"aggressiveAntiKS [0-2]", "aggressiveAntiKS", 1);
                avoidGM_near.Text = conf.GetConfigData(configData, @"avoidGM_near [0-2]", "avoidGM_near", 1);
                avoidGM_near_inTown.Text = conf.GetConfigData(configData, @"avoidGM_near_inTown [0-2]", "avoidGM_near_inTown", 1);
                avoidGM_talk.Text = conf.GetConfigData(configData, @"avoidGM_talk [0-2]", "avoidGM_talk", 1);
                avoidList.Text = conf.GetConfigData(configData, @"avoidList [0-2]", "avoidList", 1);
                avoidList_inLockOnly.Text = conf.GetConfigData(configData, @"avoidList_inLockOnly [0-2]", "avoidList_inLockOnly", 1);
                lockMap.Text = conf.GetConfigData(configData, @"lockMap (.*)", "lockMap", 1);
                lockMap_x.Text = conf.GetConfigData(configData, @"lockMap_x (.*)", "lockMap_x", 1);
                lockMap_y.Text = conf.GetConfigData(configData, @"lockMap_y (.*)", "lockMap_y", 1);
                statsAddAuto.Text = conf.GetConfigData(configData, @"statsAddAuto [0-2]", "statsAddAuto", 1);
                statsAddAuto_list.Text = conf.GetConfigData(configData, @"statsAddAuto_list (.*)", "statsAddAuto_list", 1);
                statsAdd_over_99.Text = conf.GetConfigData(configData, @"statsAdd_over_99 [0-2]", "statsAdd_over_99", 1);
                skillsAddAuto.Text = conf.GetConfigData(configData, @"skillsAddAuto [0-2]", "skillsAddAuto", 1);
                skillsAddAuto_list.Text = conf.GetConfigData(configData, @"skillsAddAuto_list (.*)", "skillsAddAuto_list", 1);
                teleportAuto_hp.Text = conf.GetConfigData(configData, @"teleportAuto_hp (.*)", "teleportAuto_hp", 1);
                dealAuto.Text = conf.GetConfigData(configData, @"dealAuto [0-2]", "dealAuto", 1);
                partyAuto.Text = conf.GetConfigData(configData, "@partyAuto [0-2]", "partyAuto", 1);
                partyAutoShare.Text = conf.GetConfigData(configData, @"partyAutoShare [0-2]", @"partyAutoShare", 1);
                guildAutoDeny.Text = conf.GetConfigData(configData, @"guildAutoDeny [0-2]", "guildAutoDeny", 1);
                usePotion.Text = conf.GetConfigData(configData, @"useSelf_item (.*) {", "useSelf_item", 1);
                usePotion.Text = usePotion.Text.Replace("{", "");
                ifusePotion.Text = conf.GetConfigData(configData, @"useSelf_item (.*)\n	hp (.*)", "useSelf_item", 1);
                ifusePotion.Text = ifusePotion.Text.Replace(usePotion.Text, "");
                ifusePotion.Text = ifusePotion.Text.Replace("{", "");
                ifusePotion.Text = ifusePotion.Text.Replace(@"	", "");
                storageAuto.Text = conf.GetConfigData(configData, @"storageAuto [0-2]", "storageAuto", 1);
                storageAuto_npc.Text = conf.GetConfigData(configData, @"storageAuto_npc (.*)", "storageAuto_npc", 1);
                storageAuto_npc_type.Text = conf.GetConfigData(configData, @"storageAuto_npc_type [0-2]", "storageAuto_npc_type", 1);
                storageAuto_npc_steps.Text = conf.GetConfigData(configData, @"storageAuto_npc_steps (.*)", "storageAuto_npc_steps", 1);
                relogAfterStorage.Text = conf.GetConfigData(configData, @"relogAfterStorage [0-2]", "relogAfterStorage", 1);
                GetAuto.Text = conf.GetConfigData(configData, @"getAuto (.*) {", "getAuto", 1);
                GetAuto.Text = GetAuto.Text.Replace("{", "");
                minAmount.Text = conf.GetConfigDataLine(configFileRoot, 729).Replace("minAmount", "").Trim();
                maxAmount.Text = conf.GetConfigDataLine(configFileRoot, 730).Replace("maxAmount", "").Trim();
                passive.Text = conf.GetConfigData(configData, @"passive [0-2]", "passive", 1);
            }
            else
            {
                MessageBox.Show(null, "config.txt 파일을 선택하지 않았습니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FolderOpen_Click(object sender, EventArgs e)
        {
            if (configFileRoot != null)
            {
                System.Diagnostics.Process.Start("explorer.exe", configFileRoot);
            }
            else
            {
                MessageBox.Show(null, "config.txt 파일을 선택하지 않았습니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigChange_Click(object sender, EventArgs e)
        {
            if (configFileRoot != null)
            {
                conf.InfoChange(configFileRoot, configData, "username ", conf.GetConfigData(configData, @"username (.*)", "username", 1), this.id.Text);
                conf.InfoChange(configFileRoot, configData, "password ", conf.GetConfigData(configData, @"password (.*)", "password", 1), this.pw.Text);
                conf.InfoChange(configFileRoot, configData, "loginPinCode ", conf.GetConfigData(configData, @"loginPinCode (.*)", "loginPinCode", 1), this.pw2.Text);
                conf.InfoChange(configFileRoot, configData, "alias_ ", conf.GetConfigData(configData, @"alias_(.*)", "alias_", 0), this.alias.Text);
                conf.InfoChange(configFileRoot, configData, "attackAuto  ", conf.GetConfigData(configData, @"attackAuto [0-2]", "attackAuto", 1), this.attackAuto.Text);
                conf.InfoChange(configFileRoot, configData, "attackAuto_party  ", conf.GetConfigData(configData, @"attackAuto_party [0-2]", "attackAuto_party", 1), this.attackAuto_party.Text);
                conf.InfoChange(configFileRoot, configData, "attackAuto_onlyWhenSafe ", conf.GetConfigData(configData, @"attackAuto_onlyWhenSafe [0-2]", "attackAuto_onlyWhenSafe", 1), this.attackAuto_onlyWhenSafe.Text);
                conf.InfoChange(configFileRoot, configData, "attackAuto_inLockOnly  ", conf.GetConfigData(configData, @"attackAuto_inLockOnly [0-2]", "attackAuto_inLockOnly", 1), this.attackAuto_inLockOnly.Text);
                conf.InfoChange(configFileRoot, configData, "attackDistance ", conf.GetConfigData(configData, @"attackDistance (.*)", "attackDistance", 1), this.attackDistance.Text);
                conf.InfoChange(configFileRoot, configData, "attackMaxDistance ", conf.GetConfigData(configData, @"attackMaxDistance (.*)", "attackMaxDistance", 1), this.attackMaxDistance.Text);
                conf.InfoChange(configFileRoot, configData, "attackDistanceAuto ", conf.GetConfigData(configData, @"attackDistanceAuto [0-2]", "attackDistanceAuto", 1), this.attackDistanceAuto.Text);
                conf.InfoChange(configFileRoot, configData, "attackMaxRouteDistance ", conf.GetConfigData(configData, @"attackMaxRouteDistance ([0-9]*)", "attackMaxRouteDistance", 1), this.attackMaxRouteDistance.Text);
                conf.InfoChange(configFileRoot, configData, "attackMinPlayerDistance ", conf.GetConfigData(configData, @"attackMinPlayerDistance (.*)", "attackMinPlayerDistance", 1), this.attackMinPlayerDistance.Text);
                conf.InfoChange(configFileRoot, configData, "attackMinPortalDistance ", conf.GetConfigData(configData, @"attackMinPortalDistance (.*)", "attackMinPortalDistance", 1), this.attackMinPortalDistance.Text);
                conf.InfoChange(configFileRoot, configData, "attackUseWeapon ", conf.GetConfigData(configData, @"attackUseWeapon [0-2]", "attackUseWeapon", 1), this.attackUseWeapon.Text);
                conf.InfoChange(configFileRoot, configData, "attackNoGiveup ", conf.GetConfigData(configData, @"attackNoGiveup [0-2]", "attackNoGiveup", 1), this.attackNoGiveup.Text);
                conf.InfoChange(configFileRoot, configData, "attackCanSnipe ", conf.GetConfigData(configData, @"attackCanSnipe [0-2]", "attackCanSnipe", 1), this.attackCanSnipe.Text);
                conf.InfoChange(configFileRoot, configData, "attackCheckLOS ", conf.GetConfigData(configData, @"attackCheckLOS [0-2]", "attackCheckLOS", 1), this.attackCheckLOS.Text);
                conf.InfoChange(configFileRoot, configData, "aggressiveAntiKS ", conf.GetConfigData(configData, @"aggressiveAntiKS [0-2]", "aggressiveAntiKS", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "avoidGM_near ", conf.GetConfigData(configData, @"avoidGM_near [0-2]", "avoidGM_near", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "avoidGM_near_inTown ", conf.GetConfigData(configData, @"avoidGM_near_inTown [0-2]", "avoidGM_near_inTown", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "avoidGM_talk ", conf.GetConfigData(configData, @"avoidGM_talk [0-2]", "avoidGM_talk", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "avoidList ", conf.GetConfigData(configData, @"avoidList [0-2]", "avoidList", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "avoidList_inLockOnly ", conf.GetConfigData(configData, @"avoidList_inLockOnly [0-2]", "avoidList_inLockOnly", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "lockMap ", conf.GetConfigData(configData, @"lockMap (.*)", "lockMap", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "lockMap_x ", conf.GetConfigData(configData, @"lockMap_x (.*)", "lockMap_x", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "lockMap_y ", conf.GetConfigData(configData, @"lockMap_y (.*)", "lockMap_y", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "statsAddAuto ", conf.GetConfigData(configData, @"statsAddAuto [0-2]", "statsAddAuto", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "statsAddAuto_list ", conf.GetConfigData(configData, @"statsAddAuto_list (.*)", "statsAddAuto_list", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "statsAdd_over_99 ", conf.GetConfigData(configData, @"statsAdd_over_99 [0-2]", "statsAdd_over_99", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "skillsAddAuto ", conf.GetConfigData(configData, @"skillsAddAuto [0-2]", "skillsAddAuto", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "skillsAddAuto_list ", conf.GetConfigData(configData, @"skillsAddAuto_list (.*)", "skillsAddAuto_list", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "teleportAuto_hp ", conf.GetConfigData(configData, @"teleportAuto_hp (.*)", "teleportAuto_hp", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "dealAuto ", conf.GetConfigData(configData, @"dealAuto [0-2]", "dealAuto", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "partyAuto ", conf.GetConfigData(configData, "@partyAuto [0-2]", "partyAuto", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "partyAutoShare ", conf.GetConfigData(configData, @"partyAutoShare [0-2]", @"partyAutoShare", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "guildAutoDeny ", conf.GetConfigData(configData, @"guildAutoDeny [0-2]", "guildAutoDeny", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "storageAuto ", conf.GetConfigData(configData, @"storageAuto [0-2]", "storageAuto", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "storageAuto_npc ", conf.GetConfigData(configData, @"storageAuto_npc (.*)", "storageAuto_npc", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "storageAuto_npc_type ", conf.GetConfigData(configData, @"storageAuto_npc_type [0-2]", "storageAuto_npc_type", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "storageAuto_npc_steps ", conf.GetConfigData(configData, @"storageAuto_npc_steps (.*)", "storageAuto_npc_steps", 1), this.aggressiveAntiKS.Text);
                conf.InfoChange(configFileRoot, configData, "relogAfterStorage ", conf.GetConfigData(configData, @"relogAfterStorage [0-2]", "relogAfterStorage", 1), this.aggressiveAntiKS.Text);

                configData = File.ReadAllText(configFileRoot);
                id.Text = conf.GetConfigData(configData, @"username (.*)", "username", 1);
                pw.Text = conf.GetConfigData(configData, @"password (.*)", "password", 1);
                pw2.Text = conf.GetConfigData(configData, @"loginPinCode (.*)", "loginPinCode", 1);
                alias.Text = conf.GetConfigData(configData, @"alias_(.*)", "alias_", 0);
                attackAuto.Text = conf.GetConfigData(configData, @"attackAuto [0-2]", "attackAuto", 1);
                attackAuto_party.Text = conf.GetConfigData(configData, @"attackAuto_party [0-2]", "attackAuto_party", 1);
                attackAuto_onlyWhenSafe.Text = conf.GetConfigData(configData, @"attackAuto_onlyWhenSafe [0-2]", "attackAuto_onlyWhenSafe", 1);
                attackAuto_inLockOnly.Text = conf.GetConfigData(configData, @"attackAuto_inLockOnly [0-2]", "attackAuto_inLockOnly", 1);
                attackDistance.Text = conf.GetConfigData(configData, @"attackDistance (.*)", "attackDistance", 1);
                attackMaxDistance.Text = conf.GetConfigData(configData, @"attackMaxDistance (.*)", "attackMaxDistance", 1);
                attackDistanceAuto.Text = conf.GetConfigData(configData, @"attackDistanceAuto [0-2]", "attackDistanceAuto", 1);
                attackMaxRouteDistance.Text = conf.GetConfigData(configData, @"attackMaxRouteDistance ([0-9]*)", "attackMaxRouteDistance", 1);
                attackMaxRouteTime.Text = conf.GetConfigData(configData, @"attackMaxRouteTime ([0-9]*)", "attackMaxRouteTime", 1);
                attackMinPlayerDistance.Text = conf.GetConfigData(configData, @"attackMinPlayerDistance (.*)", "attackMinPlayerDistance", 1);
                attackMinPortalDistance.Text = conf.GetConfigData(configData, @"attackMinPortalDistance (.*)", "attackMinPortalDistance", 1);
                attackUseWeapon.Text = conf.GetConfigData(configData, @"attackUseWeapon [0-2]", "attackUseWeapon", 1);
                attackNoGiveup.Text = conf.GetConfigData(configData, @"attackNoGiveup [0-2]", "attackNoGiveup", 1);
                attackCanSnipe.Text = conf.GetConfigData(configData, @"attackCanSnipe [0-2]", "attackCanSnipe", 1);
                attackCheckLOS.Text = conf.GetConfigData(configData, @"attackCheckLOS [0-2]", "attackCheckLOS", 1);
                aggressiveAntiKS.Text = conf.GetConfigData(configData, @"aggressiveAntiKS [0-2]", "aggressiveAntiKS", 1);
                avoidGM_near.Text = conf.GetConfigData(configData, @"avoidGM_near [0-2]", "avoidGM_near", 1);
                avoidGM_near_inTown.Text = conf.GetConfigData(configData, @"avoidGM_near_inTown [0-2]", "avoidGM_near_inTown", 1);
                avoidGM_talk.Text = conf.GetConfigData(configData, @"avoidGM_talk [0-2]", "avoidGM_talk", 1);
                avoidList.Text = conf.GetConfigData(configData, @"avoidList [0-2]", "avoidList", 1);
                avoidList_inLockOnly.Text = conf.GetConfigData(configData, @"avoidList_inLockOnly [0-2]", "avoidList_inLockOnly", 1);
                lockMap.Text = conf.GetConfigData(configData, @"lockMap (.*)", "lockMap", 1);
                lockMap_x.Text = conf.GetConfigData(configData, @"lockMap_x (.*)", "lockMap_x", 1);
                lockMap_y.Text = conf.GetConfigData(configData, @"lockMap_y (.*)", "lockMap_y", 1);
                statsAddAuto.Text = conf.GetConfigData(configData, @"statsAddAuto [0-2]", "statsAddAuto", 1);
                statsAddAuto_list.Text = conf.GetConfigData(configData, @"statsAddAuto_list (.*)", "statsAddAuto_list", 1);
                statsAdd_over_99.Text = conf.GetConfigData(configData, @"statsAdd_over_99 [0-2]", "statsAdd_over_99", 1);
                skillsAddAuto.Text = conf.GetConfigData(configData, @"skillsAddAuto [0-2]", "skillsAddAuto", 1);
                skillsAddAuto_list.Text = conf.GetConfigData(configData, @"skillsAddAuto_list (.*)", "skillsAddAuto_list", 1);
                teleportAuto_hp.Text = conf.GetConfigData(configData, @"teleportAuto_hp (.*)", "teleportAuto_hp", 1);
                dealAuto.Text = conf.GetConfigData(configData, @"dealAuto [0-2]", "dealAuto", 1);
                partyAuto.Text = conf.GetConfigData(configData, "@partyAuto [0-2]", "partyAuto", 1);
                partyAutoShare.Text = conf.GetConfigData(configData, @"partyAutoShare [0-2]", @"partyAutoShare", 1);
                guildAutoDeny.Text = conf.GetConfigData(configData, @"guildAutoDeny [0-2]", "guildAutoDeny", 1);
                usePotion.Text = conf.GetConfigData(configData, @"useSelf_item (.*) {", "useSelf_item", 1);
                usePotion.Text = usePotion.Text.Replace("{", "");
                ifusePotion.Text = conf.GetConfigData(configData, @"useSelf_item (.*)\n	hp (.*)", "useSelf_item", 1);
                ifusePotion.Text = ifusePotion.Text.Replace(usePotion.Text, "");
                ifusePotion.Text = ifusePotion.Text.Replace("{", "");
                ifusePotion.Text = ifusePotion.Text.Replace(@"	", "");
                storageAuto.Text = conf.GetConfigData(configData, @"storageAuto [0-2]", "storageAuto", 1);
                storageAuto_npc.Text = conf.GetConfigData(configData, @"storageAuto_npc (.*)", "storageAuto_npc", 1);
                storageAuto_npc_type.Text = conf.GetConfigData(configData, @"storageAuto_npc_type [0-2]", "storageAuto_npc_type", 1);
                storageAuto_npc_steps.Text = conf.GetConfigData(configData, @"storageAuto_npc_steps (.*)", "storageAuto_npc_steps", 1);
                relogAfterStorage.Text = conf.GetConfigData(configData, @"relogAfterStorage [0-2]", "relogAfterStorage", 1);
                GetAuto.Text = conf.GetConfigData(configData, @"getAuto (.*) {", "getAuto", 1);
                GetAuto.Text = GetAuto.Text.Replace("{", "");
                minAmount.Text = conf.GetConfigDataLine(configFileRoot, 729).Replace("minAmount", "").Trim();
                maxAmount.Text = conf.GetConfigDataLine(configFileRoot, 730).Replace("maxAmount", "").Trim();
                passive.Text = conf.GetConfigData(configData, @"passive [0-2]", "passive", 1);
                MessageBox.Show("변경되었습니다.");
            }
            else
            {
                MessageBox.Show(null, "config.txt 파일을 선택하지 않았습니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void aliasText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "단축키 설정입니다. heal 이라고 콘솔창에 입력하면 스킬 28번(힐)을 사용하게 됩니다. 여러가지로 사용할수 있습니다." +
                   "\n ex) alias_no c -_ - : 콘솔창에서 no 라고 입력하면 채팅창으로 - _ - 가 입력됩니다.코어가 외국꺼라서 한글은 오류납니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackAutoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "0은 공격안함, 1은 반격만 함, 2는 mon_control.txt 파일의 설정에 따라 공격하게 됩니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackAuto_partyText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 파티원이 치는 몬스터를 공격합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackAuto_onlyWhenSafeText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "0은 주변에 사람이 있어도 공격, 1은 반격만, 2는 잡던몹만 잡고 이동합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackAuto_inLockOnlyText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "0은 아무맵에서나 공격, 1은 지정된 락맵까지 가는동안 반격, 2는 지정된 락맵까지 공격당해도 그냥 이동합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackDistanceText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "공격 사정거리입니다. 일반 밀리캐릭은 기본설정인 1.5가 적당하고 원거리 캐릭은 3정도 주시면 됩니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackMaxDistanceText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "최대 공격 사정거리입니다. 일반 밀리캐릭은 기본설정인 2.5~3이 적당하고 원거리 캐릭은 적어도 6셀이상은 줘야겠죠.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackDistanceAutoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 공격거리를 자동으로 측정합니다. 컨픽 설정까지 바꿔버리기에 개인적으론 안쓰는 옵션입니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackMaxRouteDistanceText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "공격시 최대 이동거리입니다. 지정된 거리(셀) 이상 이동해서 공격해야 할 몹은 포기합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackMaxRouteTimeText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "공격시 최대 이동시간입니다. 지정된 시간(초) 이상 이동해서 공격해야 할 몹은 포기합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackMinPlayerDistanceText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "몹과 타인의 거리가 지정된 거리 이내면 포기합니다. 최소 10 이상은 주는걸 권장합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackMinPortalDistanceText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "포탈과 지정된 거리 이내면 공격하지 않습니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackUseWeaponText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 무기를 사용해서 공격합니다. 마법사라면 0으로 해야겠죠.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackNoGiveupText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 무슨일이 있어도 포기하지 않고 공격합니다. 비추천입니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackCanSnipeText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 원거리 캐릭일시 언덕치기를 가능하게 합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void attackCheckLOSText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 레드셀(이동불가지역)을 계산해서 이동합니다. 어떤맵에서든 쓰는게 좋고 특히 장애물이 많은 맵에서 추천합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aggressiveAntiKSText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 스틸 상관없이 마구 공격합니다. 당연히 0으로 해야겠죠.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void avoidGM_nearText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "0은 사용안함, 1은 텔레포트 후 접속종료, 2는 접속종료, 3은 텔레포트, 4는 마을로 귀환입니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void avoidGM_near_inTownText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 마을에서 GM 발견시 접속종료합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void avoidGM_talkText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 GM이 말걸면 접속종료합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void avoidListText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 avoid.txt 에 적힌 사람들을 발견시 접속종료합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void avoidList_inLockOnlyText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 avoid.txt 에 적힌 사람들을 락맵에서 발견시 접속종료합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lockMapText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "자신이 사냥할 맵을 지정합니다. maps.txt 파일을 참고해서 적으시면 됩니다. ex) gef_dun02", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lockMap_xText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "자신이 사냥할 맵에서 고정사냥할 위치좌표중 X좌표입니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lockMap_yText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "자신이 사냥할 맵에서 고정사냥할 위치좌표중 Y좌표입니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void statsAddAutoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 자동으로 스텟을 올립니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void statsAddAuto_listText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "자동으로 올릴 스텟 리스트입니다.\n"+
                    "ex) statsAddAuto_list 30 dex, 20 str, 60 agi->덱스부터 30 올리고 다음에 힘을 20 올린뒤 어질을 60 올립니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void statsAdd_over_99Text_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 스텟을 99이상 올립니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void skillsAddAutoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 자동으로 스킬을 올립니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void skillsAddAuto_listText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "자동으로 올릴 스킬 리스트입니다.\n"+
                    " ex) skillsAddAuto_list 10 Bash, 10 Two - Handed Sword Mastery", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void teleportAuto_hpText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "지정된 체력(%) 이하가 되면 텔레포트합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dealAutoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "0은 거래무시, 1은 자동 거래취소, 2는  자동 거래수락입니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void partyAutoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "0은 파티무시, 1은 자동 파티취소, 2는 자동 파티수락입니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void partyAutoShareText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 자동으로 경험치 균등파티로 설정합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guildAutoDenyText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 자동으로 길드가입을 거절합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ifusePotionText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "포션 사용 조건입니다.\n ex)hp > 40% , ex)hp > 200", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void usePotionText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "체력회복에 사용할 아이템 이름입니다. 중복 가능합니다.\nex)빨간포션,주황포션", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void storageAutoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 자동창고를 사용합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void storageAuto_npcText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "자동창고를 사용할 엔피시의 위치입니다. ex) prontera 164 125", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void storageAuto_npc_typeText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "1은 기본 카프라 타입(c r1 n), 2는 코모도 카프라 타입(c c r1 n), 3은 사용자 정의 타입입니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void storageAuto_npc_stepsText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "엔피시와의 대화 패턴입니다. 위에서 사용자 정의 타입을 선택했을시에 사용가능합니다."+
                       " ex) c = 계속 r1 = r0부터 순서대로 내려가며 선택합니다.n = 대화종료", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void relogAfterStorageText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "창고를 이용후 아이템의 인덱스 오류방지로 재접속합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void getAutoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "지정된 아이템을 창고에서 꺼냅니다. 아이템 이름을 입력하시면 됩니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void minAmountText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "지정된 아이템이 설정한 갯수이하가 되면 창고에서 꺼냅니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void maxAmountText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "지정된 아이템을 설정한 갯수만큼 창고에서 꺼냅니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void passiveText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "0은 minAmount 의 조건이 충족되면 자동창고를 사용, 1은 minAmount 이외의 조건에 의해 자동창고를 사용하러 왔을때 덤으로 사용합니다.", "오픈코어유틸", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("변경 지원 안되는 목록입니다.\n" +
                "-체력 포션 사용 조건\n" +
                "-사용 포션\n" +
                "-꺼낼 아이템\n" +
                "-설정한 갯수 이하일시 꺼냄\n" +
                "-꺼낼 갯수\n" +
                "-설정한 갯수 이하 조건일때 창고로 이동\n"
                );
        }
    }
}
