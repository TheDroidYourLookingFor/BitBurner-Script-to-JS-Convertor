using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bitburner_JS_Converter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void OpenFile()
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = ".Script Files (*.script)|*.script";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtb_CurrentFile.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        public void SaveFile()
        {
            saveFileDialog1.Filter = "*.js|*.js";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, rtb_ModedFile.Text);
            }
        }

        public void ReplaceTxt(string regx, string outputstr, RegexOptions regxopts, RichTextBox inputstr, RichTextBox outputrtb)
        {
            Regex regex = new Regex(regx, regxopts);
            string cleanString = regex.Replace(inputstr.Text, outputstr);
            outputrtb.Text = cleanString;
        }

        public void ParseText()
        {
            rtb_ModedFile.Text = rtb_CurrentFile.Text.Replace("\n", Environment.NewLine + "\t");
            rtb_ModedFile.Text = "\t" + rtb_ModedFile.Text;
            rtb_ModedFile.Text = "//** @param {NS} ns **//"
                + "\r\n"
                + "export async function main(ns) {"
                + "\r\n"
                + "" + rtb_ModedFile.Text.Replace("\n", Environment.NewLine + "\t")
                + "\r\n"
                + "}";

            //scp(script, source, destination)
            Regex regex = new Regex("scp\\((.*)\\)", RegexOptions.IgnoreCase);
            string cleanString = regex.Replace(rtb_ModedFile.Text, "await ns.scp($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("sleep\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "await ns.sleep($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("asleep\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "await ns.asleep($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("nuke\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.nuke($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("brutessh\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.brutessh($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("ftpcrack\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.ftpcrack($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("httpworm\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.httpworm($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("sqlinject\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.sqlinject($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("relaysmtp\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.relaysmtp($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("alert\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.alert($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("atExit\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.atExit($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("clear\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.clear($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("clearLog\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.clearLog()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("exit\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.exit()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getPlayer\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getPlayer()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getPurchasedServerLimit\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getPurchasedServerLimit()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getScriptName\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getScriptName()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getTimeSinceLastAug\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getTimeSinceLastAug()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getFavorToDonate\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getFavorToDonate()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getHackingLevel\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getHackingLevel()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getHackingMultipliers\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getHackingMultipliers()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getHacknetMultipliers\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getHacknetMultipliers()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getHostname\\(\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getHostname()");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("clearPortHandle\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.clearPortHandle($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("deleteServer\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.deleteServer($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("disableLog\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.disableLog($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("enableLog\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.enableLog($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("flags\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.flags($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("exec\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.exec($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getBitNodeMultipliers\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getBitNodeMultipliers($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getGrowTime\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getGrowTime($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getHackTime\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getHackTime($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getPurchasedServerCost\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getPurchasedServerCost($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getRunningScript\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getRunningScript($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getScriptExpGain\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getScriptExpGain($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getScriptIncome\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getScriptIncome($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getScriptLogs\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getScriptLogs($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getScriptRam\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getScriptRam($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServer\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServer($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServerBaseSecurityLevel\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServerBaseSecurityLevel($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServerGrowth\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServerGrowth($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServerMaxMoney\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServerMaxMoney($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServerMaxRam\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServerMaxRam($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServerMinSecurityLevel\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServerMinSecurityLevel($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServerMoneyAvailable\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServerMoneyAvailable($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServerRequiredHackingLevel\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServerRequiredHackingLevel($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServerSecurityLevel\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServerSecurityLevel($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getServerUsedRam\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getServerUsedRam($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getWeakenTime\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.getWeakenTime($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("grow\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.grow($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("growthAnalyze\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.growthAnalyze($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("growthAnalyzeSecurity\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.growthAnalyzeSecurity($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("hack\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.hack($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("hackAnalyze\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.hackAnalyze($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("hackAnalyzeChance\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.hackAnalyzeChance($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("hackAnalyzeSecurity\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.hackAnalyzeSecurity($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("hackAnalyzeThreads\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.hackAnalyzeThreads($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("hasRootAccess\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.hasRootAccess($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("isLogEnabled\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.isLogEnabled($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("isRunning\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.isRunning($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("kill\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.kill($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("killall\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.killall($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("ls\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.ls($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("nFormat\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.nFormat($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("peek\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.peek($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("print\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.print($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("prompt\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.prompt($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("ps\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.ps($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("purchaseServer\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.purchaseServer($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("read\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.read($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("readPort\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.readPort($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("rm\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.rm($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("run\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.run($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("scan\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.scan($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("scriptKill\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.scriptKill($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("scriptRunning\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.scriptRunning($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("serverExists\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.serverExists($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("spawn\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.spawn($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("sprintf\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.sprintf($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("tail\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.tail($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("tFormat\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.tFormat($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("toast\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.toast($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("tprint\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.tprint($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("tprintf\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.tprintf($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("tryWritePort\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.tryWritePort($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("vsprintf\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.vsprintf($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("weaken\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.weaken($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("weakenAnalyze\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.weakenAnalyze($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("wget\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.wget($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("write\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.write($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("writePort\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.writePort($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("fileExists\\((.*)\\)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ns.fileExists($1)");
            rtb_ModedFile.Text = cleanString;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void Btn_Parse_Click(object sender, EventArgs e)
        {
            ParseText();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/TheDroidYourLookingFor/BitBurner-Script-to-JS-Convertor");
        }

        private void BbPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://danielyxie.github.io/bitburner/");
        }

        private void BbSteamToolStripMenuItemClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://store.steampowered.com/app/1812820/Bitburner/");
        }

        private void BitburnerGithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/danielyxie/bitburner");
        }
    }
}
