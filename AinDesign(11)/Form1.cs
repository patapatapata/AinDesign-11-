using Illustrator;
using InDesign;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AinDesign
{
    public partial class Form1 : Form
    {
        static public double[,] tmpVal = new double[65535, 4];
        static public dynamic[] tmpObj = new dynamic[65535];

        static public string illVer = "";
        static public string indVer = "";
        static public double docX = 0;
        static public double docY = 0;
        static public double docHeight = 0;
        static public double docWidth = 0;
        static public double selX = 0;
        static public double selY = 0;
        static public double selXend = 0;
        static public double selYend = 0;
        static public int ThredValFrame = 1;
        static public int ThredValChara = 1;
        static public int ThredValPara = 1;
        private ReaderWriterLock rwLock = new ReaderWriterLock();
        public Form1()
        {
            InitializeComponent();
            Properties.Settings.Default.Reload();
            myMargin.Value = Properties.Settings.Default.saveMargin;
            myMarginY.Value = Properties.Settings.Default.saveMarginY;
            checkXY.Checked = Properties.Settings.Default.moveXY;
            if (Properties.Settings.Default.ColorConvert == false)
            {
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
            if (Properties.Settings.Default.OneChara == true)
            {
                ConvertRun.Text = "実行（鈍足1文字モード）";
            }
            Form1.CheckForIllegalCrossThreadCalls = false;
            listBox1.Items.Clear();
            var versions = new System.Collections.Generic.List<string>();
            using (var hkcr = Registry.ClassesRoot)
            {
                foreach (var name in hkcr.GetSubKeyNames())
                {
                    if (name.StartsWith("Illustrator.Application.", StringComparison.OrdinalIgnoreCase))
                    {
                        var ver = name.Substring("Illustrator.Application.".Length);
                        if (!versions.Contains(ver)) versions.Add(ver);
                    }
                }
            }
            // 数値として降順ソート（未解析は末尾）
            var sorted = versions
                .OrderByDescending(s => { int v; return int.TryParse(s, out v) ? v : int.MinValue; })
                .ToArray();
            listBox1.Items.AddRange(sorted);
            listBox1.SelectedIndex = 0;

            listBox2.Items.Clear();
            using (var hkcr = Registry.ClassesRoot)
            {
                foreach (var name in hkcr.GetSubKeyNames())
                {
                    if (name.StartsWith("InDesign.Application.", StringComparison.OrdinalIgnoreCase))
                    {
                        var ver = name.Substring("InDesign.Application.".Length);
                        if (!listBox2.Items.Contains(ver)) listBox2.Items.Add(ver);
                    }
                }
            }
            // Sorted は false にしておく
            listBox2.Sorted = false;

            // 例：ListBox に入っている "2021","2022",... を数値として降順に並べ替える
            sorted = listBox2.Items
                .Cast<string>()
                .OrderByDescending(s => {
                    int v;
                    return int.TryParse(s, out v) ? v : int.MinValue;
                })
                .ToArray();
            listBox2.Items.Clear();
            listBox2.Items.AddRange(sorted);
            listBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            illVer = listBox1.SelectedItem.ToString();
            indVer = listBox2.SelectedItem.ToString();
            label1.Text = "Illustrator " + illVer + "の選択テキストを" + "\n" + "InDesign" + indVer + "に移植します。";
            panel1.Visible = false;
        }

        #region テキスト移植
        private void ConvertRun_Click(object sender, EventArgs e)
        {
            Form1.ThredValFrame = 1;
            Form1.ThredValChara = 1;
            Form1.ThredValPara = 1;
            System.Threading.Thread ConvertT =
                new System.Threading.Thread(
                new System.Threading.ThreadStart(ConvertThread));
            ConvertT.Start();
        }

        private void ConvertThread()
        {
            dynamic illSel;
            dynamic inddDoc;
            int[] myJust = { 1818584692, 1919379572, 1667591796, 1818915700, 1919578996, 1667920756, 1718971500 };
            try
            {
                dynamic illApp = null;
                var ver = listBox1.SelectedItem.ToString();
                try
                {
                    var progId = "Illustrator.Application." + ver;
                    var t = Type.GetTypeFromProgID(progId, false);
                    if (t == null) { MessageBox.Show(progId + " は登録されていません。"); return; }
                    Type type = t;
                    illApp = Activator.CreateInstance(t, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Illustrator " + ver + " を起動できませんでした。\n" + ex.Message);
                }
                //Properties.Settings.Default.ver = listBox1.SelectedIndex;
                //Properties.Settings.Default.Save();
                illSel = illApp.ActiveDocument.Selection;
                string myCheck = illSel[0].Typename;
                Form1.docX = illApp.ActiveDocument.CropBox[0];
                Form1.docY = illApp.ActiveDocument.CropBox[1];
                progressBar1.Value = 0;
                progressBar1.Maximum = illSel.Length * 50;
            }
            catch
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Illustrator " + Form1.illVer + "のドキュメントを開いて、\r変換したいテキストを選択してください。");
                return;
            }
            try
            {
                //Type type = Type.GetTypeFromProgID("InDesign.Application." + indVer, true);
                dynamic inddApp = null;

                var ver = listBox2.SelectedItem.ToString();
                try
                {
                    var progId = "InDesign.Application." + ver;
                    var t = Type.GetTypeFromProgID(progId, false);
                    if (t == null) { MessageBox.Show(progId + " は登録されていません。"); return; }
                    inddApp = Activator.CreateInstance(t, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("InDesign " + ver + " を起動できませんでした。\n" + ex.Message);
                }
                //Properties.Settings.Default.ver = listBox1.SelectedIndex;
                //Properties.Settings.Default.Save();
                //InDesign.Application inddApp = new InDesign.Application();
                inddApp.Activate();
                inddDoc = inddApp.ActiveDocument;
            }
            catch
            {
                this.Activate();
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("InDesignドキュメントを開いてください。");
                return;
            }
            ConvertRun.Visible = false;
            this.Activate();

            for (int i = illSel.Length - 1; i > -1; i--)
            {
                if ((illSel[i].Typename == "TextFrame") && (illSel[i].Contents != ""))
                {
                    while (Form1.ThredValFrame > Properties.Settings.Default.MultiFrame)
                    {
                        Thread.Sleep(10);
                    }
                    object[] tmpDynamic = { illSel[i], inddDoc};
                    System.Threading.Thread myConvertT =
                        new System.Threading.Thread(
                        new System.Threading.ParameterizedThreadStart(MyConvert));
                    myConvertT.Start(tmpDynamic);
                }
                if (illSel[i].Typename == "GroupItem")
                {
                    for (int j = illSel[i].PageItems.Count; j > 0; j--)
                    {
                        if (illSel[i].PageItems[j].Typename == "GroupItem")
                        {
                            MyGroup1(illSel[i].PageItems[j], inddDoc, myJust);
                        }
                        if ((illSel[i].PageItems[j].Typename == "TextFrame") && (illSel[i].PageItems[j].Contents != ""))
                        {
                            while (Form1.ThredValFrame > Properties.Settings.Default.MultiFrame)
                            {
                                Thread.Sleep(10);
                            }
                            object[] tmpDynamic = { illSel[i].PageItems[j], inddDoc };
                            System.Threading.Thread myConvertT =
                                new System.Threading.Thread(
                                new System.Threading.ParameterizedThreadStart(MyConvert));
                            myConvertT.Start(tmpDynamic);
                        }
                    }
                }
                try
                {
                    rwLock.AcquireWriterLock(Timeout.Infinite);
                    progressBar1.Value = progressBar1.Value + 50;
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
            }
            System.Threading.Thread.Sleep(1000);
            while (Form1.ThredValFrame > 1)
            {
                Thread.Sleep(10);
            }
            while (Form1.ThredValPara > 1)
            {
                Thread.Sleep(10);
            }
            while (Form1.ThredValChara > 1)
            {
                Thread.Sleep(10);
            }
            if (Properties.Settings.Default.ShowMessage == true)
            {
                this.Activate();
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("終了しました");
            }
            ConvertRun.Visible = true;
        }



        private void MyConvert(object myObj)
        {
            Interlocked.Increment(ref Form1.ThredValFrame);
            object[] tmpDynamic = (object[])myObj;
            dynamic illSel = tmpDynamic[0];
            dynamic inddDoc = tmpDynamic[1];
            dynamic inddTf = inddDoc.TextFrames.Add();
            string myLeft = illSel.VisibleBounds[0] - Form1.docX + "pt";
            string myTop = -illSel.VisibleBounds[1] + Form1.docY + "pt";
            string myRight = illSel.VisibleBounds[2] - Form1.docX + "pt";
            string myBottom = -illSel.VisibleBounds[3] + Form1.docY + "pt";
            inddTf.VisibleBounds = new string[4] { myTop, myLeft, myBottom, myRight };
            if (illSel.Orientation == 0)
            {
                inddTf.ParentStory.StoryPreferences.StoryOrientation = InDesign.idStoryHorizontalOrVertical.idHorizontal;
            }
            else
            {
                inddTf.ParentStory.StoryPreferences.StoryOrientation = InDesign.idStoryHorizontalOrVertical.idVertical;
            }
            inddTf.Contents = illSel.Contents;

            //強制改行処理
            try
            {
                dynamic inddStory = inddTf.ParentStory;
                if (illSel.Paragraphs.Count > inddStory.Paragraphs.Count)
                {
                    dynamic inddApp = inddDoc.Parent;
                    inddApp.FindTextPreferences = idNothingEnum.idNothing;
                    inddApp.ChangeGrepPreferences = idNothingEnum.idNothing;
                    inddApp.FindTextPreferences.FindWhat = "^h";
                    inddApp.ChangeTextPreferences.ChangeTo = "^p";
                    inddStory.ChangeText();
                }
            }
            catch
            { }

            try
            {
                rwLock.AcquireWriterLock(Timeout.Infinite);
                progressBar1.Maximum = progressBar1.Maximum + (illSel.Paragraphs.Count * 20) + 20;
            }
            finally
            {
                rwLock.ReleaseWriterLock();
            }
            for (int i = 0; i < illSel.Paragraphs.Count + 1; i++)
            {
                dynamic inddPara;
                dynamic illParaAtt;
                dynamic illCharaAtt;
                try
                {
                    inddPara = inddTf.ParentStory.Paragraphs[i + 1];
                    illParaAtt = illSel.Paragraphs[i + 1];
                    illCharaAtt = illSel.Paragraphs[i + 1].Characters[1];
                }
                catch
                {
                    try
                    {
                        inddPara = inddTf.ParentStory.Paragraphs[i + 1];
                        int charaNum = 0;
                        for (int k = 0; k < i; k++)
                        {
                            charaNum = charaNum + illSel.Paragraphs[k + 1].Characters.Count + 1;
                        }
                        illParaAtt = illSel.TextRanges[charaNum + 1];
                        illCharaAtt = illSel.TextRanges[charaNum + 1];
                    }
                    catch
                    {
                        Interlocked.Decrement(ref Form1.ThredValFrame);
                        try
                        {
                            rwLock.AcquireWriterLock(Timeout.Infinite);
                            progressBar1.Value = progressBar1.Value + 20;
                        }
                        finally
                        {
                            rwLock.ReleaseWriterLock();
                        }
                        continue;
                    }
                }
                while (Form1.ThredValPara > Properties.Settings.Default.MultiPara)
                {
                    Thread.Sleep(100);
                }
                object[] tmpDynamicPara = { inddPara, illParaAtt, illCharaAtt, inddDoc, illSel, i + 1 };
                System.Threading.Thread myConvertParaT =
                    new System.Threading.Thread(
                    new System.Threading.ParameterizedThreadStart(MyConvertPara));
                Interlocked.Increment(ref Form1.ThredValPara);
                myConvertParaT.Start(tmpDynamicPara);
            }
            Interlocked.Decrement(ref Form1.ThredValFrame); 
        }

        private void MyConvertPara(object myObj)
        {
            object[] tmpDynamicPara = (object[])myObj;
            dynamic inddPara = tmpDynamicPara[0];
            dynamic illParaAtt = tmpDynamicPara[1];
            dynamic illCharaAtt = tmpDynamicPara[2];
            dynamic inddDoc = tmpDynamicPara[3];
            dynamic illSel = tmpDynamicPara[4];
            int paraNum = (int)tmpDynamicPara[5];
            int[] myJust = { 1818584692, 1919379572, 1667591796, 1818915700, 1919578996, 1667920756, 1718971500 };
            try
            {
                inddPara.Justification = myJust[illParaAtt.ParagraphAttributes.Justification];
            }
            catch
            {

            }
            if (Properties.Settings.Default.OneChara == true)
            {
                try
                {
                    rwLock.AcquireWriterLock(Timeout.Infinite);
                    progressBar1.Maximum = progressBar1.Maximum + illParaAtt.Characters.Count + 1;
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
                for (int j = 0; j < illParaAtt.Characters.Count + 1; j++)
                {
                    dynamic illChara;
                    dynamic inddChara;
                    try
                    {
                        if (j == illParaAtt.Characters.Count)
                        {
                            int charaNum = 0;
                            for (int k = 0; k < paraNum; k++)
                            {
                                charaNum = charaNum + illSel.Paragraphs[k + 1].Characters.Count + 1;
                            }
                            illChara = illSel.Characters[charaNum];
                            inddChara = inddPara.Characters[j + 1];
                        }
                        else
                        {
                            illChara = illParaAtt.Characters[j + 1];
                            inddChara = inddPara.Characters[j + 1];
                        }

                        while (Form1.ThredValChara > Properties.Settings.Default.MultiChara)
                        {
                            Thread.Sleep(100);
                        }
                        object[] tmpDynamicChara = { illChara, inddChara, inddDoc };
                        System.Threading.Thread myConvertCharaT =
                            new System.Threading.Thread(
                            new System.Threading.ParameterizedThreadStart(MyConvertChara));
                        Interlocked.Increment(ref Form1.ThredValChara);
                        myConvertCharaT.Start(tmpDynamicChara);
                    }
                    catch
                    {
                        try
                        {
                            rwLock.AcquireWriterLock(Timeout.Infinite);
                            progressBar1.Value++;
                        }
                        finally
                        {
                            rwLock.ReleaseWriterLock();
                        }
                    }
                }
            }
            else
            {
                try
                {
                    inddPara.HorizontalScale = illCharaAtt.CharacterAttributes.HorizontalScale;
                    inddPara.VerticalScale = illCharaAtt.CharacterAttributes.VerticalScale;
                    inddPara.Tracking = illCharaAtt.CharacterAttributes.Tracking;
                    inddPara.PointSize = illCharaAtt.CharacterAttributes.Size + "pt";
                    inddPara.Leading = illCharaAtt.CharacterAttributes.Leading + "pt";
                }
                catch
                {

                }

                try
                {
                    inddPara.AppliedFont = illCharaAtt.CharacterAttributes.TextFont.Family + "\t" + illCharaAtt.CharacterAttributes.TextFont.Style;
                }
                catch
                {

                }

                if (Properties.Settings.Default.ColorConvert == true)
                {
                    ColorConvert(illCharaAtt, inddDoc, inddPara);
                }
            }

            try
            {
                if (illParaAtt.ParagraphAttributes.TabStops.Length > 0)
                {
                    for (int i = 0; i < illParaAtt.ParagraphAttributes.TabStops.Length; i++)
                    {
                        dynamic newTab = inddPara.TabStops.Add();
                        if (illParaAtt.ParagraphAttributes.TabStops[i].Alignment == 0)
                        {
                            newTab.Alignment = InDesign.idTabStopAlignment.idLeftAlign;
                        }
                        if (illParaAtt.ParagraphAttributes.TabStops[i].Alignment == 1)
                        {
                            newTab.Alignment = InDesign.idTabStopAlignment.idCenterAlign;
                        }
                        if (illParaAtt.ParagraphAttributes.TabStops[i].Alignment == 2)
                        {
                            newTab.Alignment = InDesign.idTabStopAlignment.idRightAlign;
                        }
                        if (illParaAtt.ParagraphAttributes.TabStops[i].Alignment == 3)
                        {
                            newTab.Alignment = InDesign.idTabStopAlignment.idCharacterAlign;
                        }
                        //newTab.Leader = illParaAtt.ParagraphAttributes.TabStops[i].Leader;
                        newTab.Position = illParaAtt.ParagraphAttributes.TabStops[i].Position + "pt";
                    }
                }
            }
            catch
            { 
            
            }

            try
            {
                inddPara.SpaceAfter = illParaAtt.ParagraphAttributes.SpaceAfter + "pt";
                inddPara.SpaceBefore = illParaAtt.ParagraphAttributes.SpaceBefore + "pt";
                if (illParaAtt.ParagraphAttributes.FirstLineIndent + illParaAtt.ParagraphAttributes.LeftIndent >= 0 && illParaAtt.ParagraphAttributes.LeftIndent >= 0)
                {
                    inddPara.LeftIndent = illParaAtt.ParagraphAttributes.LeftIndent + "pt";
                    inddPara.FirstLineIndent = illParaAtt.ParagraphAttributes.FirstLineIndent + "pt";
                }
                else
                {
                    double myAdjust = illParaAtt.ParagraphAttributes.FirstLineIndent + illParaAtt.ParagraphAttributes.LeftIndent;
                    if (myAdjust >= 0)
                    {
                        inddPara.LeftIndent = 0;
                        inddPara.FirstLineIndent = myAdjust + "pt";
                    }
                    else
                    {
                        if (myAdjust <= illParaAtt.ParagraphAttributes.LeftIndent)
                        {
                            inddPara.LeftIndent = illParaAtt.ParagraphAttributes.LeftIndent - myAdjust + "pt";
                            inddPara.FirstLineIndent = illParaAtt.ParagraphAttributes.FirstLineIndent + "pt";
                        }
                        else
                        {
                            inddPara.LeftIndent = 0;
                            inddPara.FirstLineIndent = illParaAtt.ParagraphAttributes.FirstLineIndent + "pt";
                        }
                    }
                }
                inddPara.RightIndent = illParaAtt.ParagraphAttributes.RightIndent + "pt";
            }
            catch
            {

            }
            Interlocked.Decrement(ref Form1.ThredValPara);
            try
            {
                rwLock.AcquireWriterLock(Timeout.Infinite);
                progressBar1.Value = progressBar1.Value + 20;
            }
            finally
            {
                rwLock.ReleaseWriterLock();
            }
        }

        private void MyConvertChara(object myObj)
        {
            object[] tmpDynamicChara = (object[])myObj;
            dynamic illChara = tmpDynamicChara[0];
            dynamic inddChara = tmpDynamicChara[1];
            dynamic inddDoc = tmpDynamicChara[2];
            try
            {
                inddChara.HorizontalScale = illChara.CharacterAttributes.HorizontalScale;
                inddChara.VerticalScale = illChara.CharacterAttributes.VerticalScale;
                if (Properties.Settings.Default.OneTracking == true)
                {
                    inddChara.Tracking = illChara.CharacterAttributes.Tracking;
                }
                inddChara.PointSize = illChara.CharacterAttributes.Size + "pt";
                inddChara.Leading = illChara.CharacterAttributes.Leading + "pt";
                inddChara.BaselineShift = illChara.CharacterAttributes.BaselineShift + "pt";
                if (Properties.Settings.Default.OneRotation == true)
                {
                    inddChara.CharacterRotation = illChara.CharacterAttributes.Rotation;
                }
                if (Properties.Settings.Default.OnePosition == true)
                {
                    if (illChara.CharacterAttributes.BaselinePosition == 1)
                    {
                        inddChara.Position = idPosition.idSuperscript;
                    }
                    else
                    {
                        if (illChara.CharacterAttributes.BaselinePosition == 2)
                        {
                            inddChara.Position = idPosition.idSubscript;
                        }
                    }
                }
                if (Properties.Settings.Default.OneNoBreak == true)
                {
                    inddChara.NoBreak = illChara.CharacterAttributes.NoBreak;
                }
                if (Properties.Settings.Default.OneAki == true)
                {
                    inddChara.LeadingAki = illChara.CharacterAttributes.AkiLeft;
                    inddChara.TrailingAki = illChara.CharacterAttributes.AkiRight;
                }
                if (Properties.Settings.Default.OneUnderline == true)
                {
                    inddChara.Underline = illChara.CharacterAttributes.Underline;
                    inddChara.StrikeThru = illChara.CharacterAttributes.StrikeThrough;
                }
                if (Properties.Settings.Default.OneStroke == true)
                {
                    inddChara.StrokeWeight = illChara.CharacterAttributes.StrokeWeight + "pt";
                    if (Properties.Settings.Default.ColorConvert == true)
                    {
                        StrokeColorConvert(illChara, inddDoc, inddChara);
                    }
                }
                if (Properties.Settings.Default.OneTsume == true)
                {
                    inddChara.Tsume = illChara.CharacterAttributes.Tsume / 100;
                }
                if (Properties.Settings.Default.OneItalics == true)
                {
                    inddChara.OTFRomanItalics = illChara.CharacterAttributes.Italics;
                }
            }
            catch
            {

            }

            try
            {
                inddChara.AppliedFont = illChara.CharacterAttributes.TextFont.Family + "\t" + illChara.CharacterAttributes.TextFont.Style;
            }
            catch
            {

            }

            if (Properties.Settings.Default.ColorConvert == true)
            {
                ColorConvert(illChara, inddDoc, inddChara);
            }
            System.Windows.Forms.Application.DoEvents();
            Interlocked.Decrement(ref Form1.ThredValChara);
            try
            {
                rwLock.AcquireWriterLock(Timeout.Infinite);
                progressBar1.Value++;
            }
            finally
            {
                rwLock.ReleaseWriterLock();
            }
        }


        private void MyGroup1(dynamic myGroup, dynamic inddDoc, dynamic myJust)
        {
            for (int i = myGroup.PageItems.Count; i > 0; i--)
            {
                if (myGroup.PageItems[i].Typename == "GroupItem")
                {
                    MyGroup2(myGroup.PageItems[i], inddDoc, myJust);
                }
                if ((myGroup.PageItems[i].Typename == "TextFrame") && (myGroup.PageItems[i].Contents != ""))
                {
                    while (Form1.ThredValFrame > Properties.Settings.Default.MultiFrame)
                    {
                        Thread.Sleep(10);
                    }
                    object[] tmpDynamic = { myGroup.PageItems[i], inddDoc };
                    System.Threading.Thread myConvertT =
                        new System.Threading.Thread(
                        new System.Threading.ParameterizedThreadStart(MyConvert));
                    myConvertT.Start(tmpDynamic);
                }
            }
        }

        private void MyGroup2(dynamic myGroup, dynamic inddDoc, dynamic myJust)
        {
            for (int i = myGroup.PageItems.Count; i > 0; i--)
            {
                if (myGroup.PageItems[i].Typename == "GroupItem")
                {
                    MyGroup1(myGroup.PageItems[i], inddDoc, myJust);
                }
                if ((myGroup.PageItems[i].Typename == "TextFrame") && (myGroup.PageItems[i].Contents != ""))
                {
                    while (Form1.ThredValFrame > Properties.Settings.Default.MultiFrame)
                    {
                        Thread.Sleep(10);
                    }
                    object[] tmpDynamic = { myGroup.PageItems[i], inddDoc };
                    System.Threading.Thread myConvertT =
                        new System.Threading.Thread(
                        new System.Threading.ParameterizedThreadStart(MyConvert));
                    myConvertT.Start(tmpDynamic);
                }
            }
        }
        #endregion

        #region 表コンバート処理
        private void Convert_Table_Click(object sender, EventArgs e)
        {
            System.Threading.Thread ConvertTableT =
                new System.Threading.Thread(
                new System.Threading.ThreadStart(ConvertTableThread));
            ConvertTableT.Start();
        }

        private void ConvertTableThread()
        {
            int txtNum = -1;
            dynamic illSel;
            dynamic inddDoc;
            try
            {
                dynamic illApp = null;
                var ver = listBox1.SelectedItem.ToString();
                try
                {
                    var progId = "Illustrator.Application." + ver;
                    var t = Type.GetTypeFromProgID(progId, false);
                    if (t == null) { MessageBox.Show(progId + " は登録されていません。"); return; }
                    Type type = t;
                    illApp = Activator.CreateInstance(t, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Illustrator " + ver + " を起動できませんでした。\n" + ex.Message);
                }
                illSel = illApp.ActiveDocument.Selection;
                string myCheck = illSel[0].Typename;
                Form1.docHeight = illApp.ActiveDocument.Height;
                Form1.docWidth = illApp.ActiveDocument.Width;
                Form1.docX = illApp.ActiveDocument.CropBox[0];
                Form1.docY = illApp.ActiveDocument.CropBox[1];
                progressBar2.Value = 0;
                progressBar2.Maximum = illSel.Length;
            }
            catch
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Illustrator " + Form1.illVer + "のドキュメントを開いて、\r変換したいテキストを選択してください。");
                return;
            }
            try
            {
                dynamic inddApp = null;

                var ver = listBox2.SelectedItem.ToString();
                try
                {
                    var progId = "InDesign.Application." + ver;
                    var t = Type.GetTypeFromProgID(progId, false);
                    if (t == null) { MessageBox.Show(progId + " は登録されていません。"); return; }
                    inddApp = Activator.CreateInstance(t, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("InDesign " + ver + " を起動できませんでした。\n" + ex.Message);
                }
                inddApp.Activate();
                inddDoc = inddApp.ActiveDocument;
            }
            catch
            {
                this.Activate();
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("InDesignドキュメントを開いてください。");
                return;
            }
            Convert_Table.Visible = false;
            this.Activate();
            for (int i = 0; i < illSel.Length; i++)
            {
                progressBar2.Value++;
                if ((illSel[i].Typename == "TextFrame") && (illSel[i].Contents != ""))
                {
                    txtNum++;
                    MyPreTableConvert(illSel[i], txtNum);
                }
                if (illSel[i].Typename == "GroupItem")
                {
                    for (int j = illSel[i].PageItems.Count; j > 0; j--)
                    {
                        if (illSel[i].PageItems[j].Typename == "GroupItem")
                        {
                            MyTableGroup1(illSel[i].PageItems[j], txtNum);
                        }
                        if ((illSel[i].PageItems[j].Typename == "TextFrame") && (illSel[i].PageItems[j].Contents != ""))
                        {
                            txtNum++;
                            MyPreTableConvert(illSel[i].PageItems[j], txtNum);
                        }
                    }
                }
            }
            MyTableConvert(inddDoc, txtNum);
            if (Properties.Settings.Default.ShowMessage == true)
            {
                this.Activate();
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("表に変換\r終了しました");
            }
            Convert_Table.Visible = true;
        }

        private void MyPreTableConvert(dynamic illSel, int txtNum)
        {
            if (checkXY.Checked == true)
            {
                if (txtNum == 0)
                {
                    Form1.selX = illSel.VisibleBounds[0];
                    Form1.selY = illSel.VisibleBounds[1];
                }
                else
                {
                    if (Form1.selX > illSel.VisibleBounds[0])
                    {
                        Form1.selX = illSel.VisibleBounds[0];
                    }
                    if (Form1.selY < illSel.VisibleBounds[1])
                    {
                        Form1.selY = illSel.VisibleBounds[1];
                    }
                }
            }
            Form1.tmpVal[txtNum, 0] = illSel.VisibleBounds[0];
            if (illSel.TextRange.Justification == 2)
            {
                Form1.tmpVal[txtNum, 0] = illSel.Width / 2 + illSel.Left;
            }
            if (illSel.TextRange.Justification == 1)
            {
                Form1.tmpVal[txtNum, 0] = illSel.Width + illSel.Left;
            }
            Form1.tmpVal[txtNum,1] = illSel.VisibleBounds[1];
            Form1.tmpVal[txtNum,2] = 0;
            Form1.tmpVal[txtNum,3] = 0;
            Form1.tmpObj[txtNum] = illSel;
            progressBar2.Maximum++;
        }

        private void MyTableGroup1(dynamic myGroup, int txtNum)
        {
            for (int i = myGroup.PageItems.Count; i > 0; i--)
            {
                if (myGroup.PageItems[i].Typename == "GroupItem")
                {
                    MyTableGroup2(myGroup.PageItems[i], txtNum);
                }
                if ((myGroup.PageItems[i].Typename == "TextFrame") && (myGroup.PageItems[i].Contents != ""))
                {
                    txtNum++;
                    MyPreTableConvert(myGroup.PageItems[i], txtNum);
                }
            }
        }

        private void MyTableGroup2(dynamic myGroup, int txtNum)
        {
            for (int i = myGroup.PageItems.Count; i > 0; i--)
            {
                if (myGroup.PageItems[i].Typename == "GroupItem")
                {
                    MyTableGroup1(myGroup.PageItems[i], txtNum);
                }
                if ((myGroup.PageItems[i].Typename == "TextFrame") && (myGroup.PageItems[i].Contents != ""))
                {
                    txtNum++;
                    MyPreTableConvert(myGroup.PageItems[i], txtNum);
                }
            }
        }

        private void MyTableConvert(dynamic inddDoc, int txtNum)
        {
            double[] myWid = new double[txtNum+2];
            int[] kazu = new int[txtNum+2];
            double checkVal = 0;
            double[] marginVal = { (double)myMargin.Value * 2.835, (double)myMarginY.Value * 2.835 };
            for (int i = 0; i < 2; i++)
            {
                int myCount = 0;
                while (myCount < txtNum+1)
                {
                    myCount++;
                    for (int j = 0; j < txtNum+1; j++)
                    {
                        if (Form1.tmpVal[j,i + 2] == 0)
                        {
                            checkVal = Form1.tmpVal[j, i];
                            kazu[i] = myCount;
                            for (int k = 0; k < txtNum+1; k++)
                            {
                                if ((Form1.tmpVal[k, i] < checkVal) && (Form1.tmpVal[k, i + 2] == 0))
                                {
                                    checkVal = Form1.tmpVal[k,i];
                                }
                            }
                        }
                    }
                    if (i == 0) { myWid[myCount] = checkVal; }
                    for (int k = 0; k < txtNum+1; k++)
                    {
                        if (((Form1.tmpVal[k,i] - marginVal[i]) <= checkVal) && (Form1.tmpVal[k,i + 2] == 0))
                        {
                            Form1.tmpVal[k,i + 2] = myCount;
                        }
                    }
                }
            }
            //ドキュメントに表を作成
            dynamic myTf = inddDoc.textFrames.add();
            if (checkXY.Checked == true)
            {
                myTf.visibleBounds = new dynamic[4] { - Form1.selY + Form1.docY + "pt", Form1.selX - Form1.docX + "pt", (- Form1.selY + Form1.docY + Form1.docHeight) * 2 + "pt", Form1.selX - Form1.docX + Form1.docWidth + "pt" };

            }
            else
            {
                myTf.visibleBounds = new dynamic[4] {0, 0, Form1.docHeight * 2 + "pt",Form1.docWidth + "pt" };
            }
            var myTb = myTf.Tables.add();
            myTb.ColumnCount = kazu[0];
            myTb.BodyRowCount = kazu[1];

            //表幅リセット
            for (int i = 0; i < kazu[0] - 1; i++)
            {
                myTb.Columns[i + 1].Width = myWid[i + 2] - myWid[i + 1] + "pt";
            }

            //表の文字入れ
            int[] myJust = { 1818584692, 1919379572, 1667591796, 1818915700, 1919578996, 1667920756, 1718971500 };
            dynamic tmpWidth = 0;
            for (int j = 0; j < txtNum + 1; j++)
            {
                int myRow = myTb.BodyRowCount - (int)Form1.tmpVal[j, 3] + 1;
                int myCell = (int)Form1.tmpVal[j, 2];
                if (myTb.Rows[myRow].Cells[myCell].Texts[1].Contents == "")
                {
                    myTb.Rows[myRow].Cells[myCell].Contents = Form1.tmpObj[j].Contents;
                }
                else
                {
                    myTb.Rows[myRow].Cells[myCell].Contents = Form1.tmpObj[j].Contents + "\r" + myTb.Rows[myRow].Cells[myCell].Texts[1].Contents;
                }

                int selVal = Form1.tmpObj[j].Paragraphs.Count;
                for (int i = 0; i < selVal + 1; i++)
                {
                    dynamic inddPara;
                    dynamic illParaAtt;
                    dynamic illCharaAtt;
                    try
                    {
                        inddPara = myTb.Rows[myRow].Cells[myCell].Paragraphs[i + 1];
                        illParaAtt = Form1.tmpObj[j].Paragraphs[i + 1];
                        illCharaAtt = Form1.tmpObj[j].Paragraphs[i + 1].Characters[1];
                    }
                    catch
                    {
                        try
                        {
                            inddPara = myTb.Rows[myRow].Cells[myCell].Paragraphs[i + 1];
                            int charaNum = 0;
                            for (int k = 0; k < i; k++)
                            {
                                charaNum = charaNum + Form1.tmpObj[j].Paragraphs[k + 1].Characters.Count + 1;
                            }
                            illParaAtt = Form1.tmpObj[j].TextRanges[charaNum + 1];
                            illCharaAtt = Form1.tmpObj[j].TextRanges[charaNum + 1];
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    try
                    {
                        inddPara.Justification = myJust[illParaAtt.ParagraphAttributes.Justification];
                        inddPara.HorizontalScale = illCharaAtt.CharacterAttributes.HorizontalScale;
                        inddPara.VerticalScale = illCharaAtt.CharacterAttributes.VerticalScale;
                        inddPara.Tracking = illCharaAtt.CharacterAttributes.Tracking;
                    }
                    catch
                    {

                    }

                    try
                    {
                        inddPara.AppliedFont = illCharaAtt.CharacterAttributes.TextFont.Family + "\t" + illCharaAtt.CharacterAttributes.TextFont.Style;
                    }
                    catch
                    {

                    }

                    if (Properties.Settings.Default.ColorConvert == true)
                    {
                        ColorConvert(illCharaAtt, inddDoc, inddPara);
                    }

                    try
                    {
                        if (illParaAtt.ParagraphAttributes.TabStops.Length > 0)
                        {
                            for (int k = 0; k < illParaAtt.ParagraphAttributes.TabStops.Length; k++)
                            {
                                dynamic newTab = inddPara.TabStops.Add();
                                if (illParaAtt.ParagraphAttributes.TabStops[k].Alignment == 0)
                                {
                                    newTab.Alignment = InDesign.idTabStopAlignment.idLeftAlign;
                                }
                                if (illParaAtt.ParagraphAttributes.TabStops[k].Alignment == 1)
                                {
                                    newTab.Alignment = InDesign.idTabStopAlignment.idCenterAlign;
                                }
                                if (illParaAtt.ParagraphAttributes.TabStops[k].Alignment == 2)
                                {
                                    newTab.Alignment = InDesign.idTabStopAlignment.idRightAlign;
                                }
                                if (illParaAtt.ParagraphAttributes.TabStops[k].Alignment == 3)
                                {
                                    newTab.Alignment = InDesign.idTabStopAlignment.idCharacterAlign;
                                }
                                //newTab.Leader = illParaAtt.ParagraphAttributes.TabStops[k].Leader;
                                newTab.Position = illParaAtt.ParagraphAttributes.TabStops[k].Position + "pt";
                            }
                        }
                    }
                    catch
                    {

                    }


                    try
                    {
                        inddPara.PointSize = illCharaAtt.CharacterAttributes.Size + "pt";
                        inddPara.Leading = illCharaAtt.CharacterAttributes.Leading + "pt";
                        inddPara.SpaceAfter = illParaAtt.ParagraphAttributes.SpaceAfter + "pt";
                        inddPara.SpaceBefore = illParaAtt.ParagraphAttributes.SpaceBefore + "pt";
                        if (illParaAtt.ParagraphAttributes.FirstLineIndent + illParaAtt.ParagraphAttributes.LeftIndent >= 0 && illParaAtt.ParagraphAttributes.LeftIndent >= 0)
                        {
                            inddPara.LeftIndent = illParaAtt.ParagraphAttributes.LeftIndent + "pt";
                            inddPara.FirstLineIndent = illParaAtt.ParagraphAttributes.FirstLineIndent + "pt";
                        }
                        else
                        {
                            double myAdjust = illParaAtt.ParagraphAttributes.FirstLineIndent + illParaAtt.ParagraphAttributes.LeftIndent;
                            if (myAdjust >= 0)
                            {
                                inddPara.LeftIndent = 0;
                                inddPara.FirstLineIndent = myAdjust + "pt";
                            }
                            else
                            {
                                if (myAdjust <= illParaAtt.ParagraphAttributes.LeftIndent)
                                {
                                    inddPara.LeftIndent = illParaAtt.ParagraphAttributes.LeftIndent - myAdjust + "pt";
                                    inddPara.FirstLineIndent = illParaAtt.ParagraphAttributes.FirstLineIndent + "pt";
                                }
                                else
                                {
                                    inddPara.LeftIndent = 0;
                                    inddPara.FirstLineIndent = illParaAtt.ParagraphAttributes.FirstLineIndent + "pt";
                                }
                            }
                        }
                        inddPara.RightIndent = illParaAtt.ParagraphAttributes.RightIndent + "pt";
                    }
                    catch
                    {

                    }
                    //幅設定
                    if (myCell == myTb.ColumnCount && tmpWidth < Form1.tmpObj[j].Width)
                    {
                        tmpWidth = Form1.tmpObj[j].Width;
                    }
                }
                progressBar2.Value++;
            }
            myTb.Columns[myTb.ColumnCount].Width = tmpWidth + 5.669 + "pt";
            myTf.Fit(idFitOptions.idFrameToContent);
        }
        #endregion

        #region 1枠に変換
        private void Convert_OneFrame_Click(object sender, EventArgs e)
        {
            System.Threading.Thread ConvertOneFrameT =
                new System.Threading.Thread(
                new System.Threading.ThreadStart(ConvertOneFrameThread));
            ConvertOneFrameT.Start();
        }

        private void ConvertOneFrameThread()
        {
            int txtNum = -1;
            dynamic illSel;
            dynamic inddDoc;
            try
            {
                dynamic illApp = null;
                var ver = listBox1.SelectedItem.ToString();
                try
                {
                    var progId = "Illustrator.Application." + ver;
                    var t = Type.GetTypeFromProgID(progId, false);
                    if (t == null) { MessageBox.Show(progId + " は登録されていません。"); return; }
                    Type type = t;
                    illApp = Activator.CreateInstance(t, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Illustrator " + ver + " を起動できませんでした。\n" + ex.Message);
                }
                illSel = illApp.ActiveDocument.Selection;
                string myCheck = illSel[0].Typename;
                Form1.docHeight = illApp.ActiveDocument.Height;
                Form1.docWidth = illApp.ActiveDocument.Width;
                Form1.docX = illApp.ActiveDocument.CropBox[0];
                Form1.docY = illApp.ActiveDocument.CropBox[1];
                progressBar3.Value = 0;
                progressBar3.Maximum = illSel.Length;
            }
            catch
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Illustrator " + Form1.illVer + "のドキュメントを開いて、\r変換したいテキストを選択してください。");
                return;
            }
            try
            {
                dynamic inddApp = null;

                var ver = listBox2.SelectedItem.ToString();
                try
                {
                    var progId = "InDesign.Application." + ver;
                    var t = Type.GetTypeFromProgID(progId, false);
                    if (t == null) { MessageBox.Show(progId + " は登録されていません。"); return; }
                    inddApp = Activator.CreateInstance(t, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("InDesign " + ver + " を起動できませんでした。\n" + ex.Message);
                }
                inddApp.Activate();
                inddDoc = inddApp.ActiveDocument;
            }
            catch
            {
                this.Activate();
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("InDesignドキュメントを開いてください。");
                return;
            }
            Convert_OneFrame.Visible = false;
            this.Activate();
            for (int i = 0; i < illSel.Length; i++)
            {
                progressBar3.Value++;
                if ((illSel[i].Typename == "TextFrame") && (illSel[i].Contents != ""))
                {
                    txtNum++;
                    MyPreFrameConvert(illSel[i], txtNum);
                }
                if (illSel[i].Typename == "GroupItem")
                {
                    for (int j = illSel[i].PageItems.Count; j > 0; j--)
                    {
                        if (illSel[i].PageItems[j].Typename == "GroupItem")
                        {
                            MyFrameGroup1(illSel[i].PageItems[j], txtNum);
                        }
                        if ((illSel[i].PageItems[j].Typename == "TextFrame") && (illSel[i].PageItems[j].Contents != ""))
                        {
                            txtNum++;
                            MyPreFrameConvert(illSel[i].PageItems[j], txtNum);
                        }
                    }
                }
            }
            MyFrameConvert(inddDoc, txtNum);
            if (Properties.Settings.Default.ShowMessage == true)
            {
                this.Activate();
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("1枠に収納\r終了しました");
            }
            Convert_OneFrame.Visible = true;
        }

        private void MyPreFrameConvert(dynamic illSel, int txtNum)
        {
            if (txtNum == 0)
            {
                Form1.selX = illSel.VisibleBounds[0];
                Form1.selY = illSel.VisibleBounds[1];
                Form1.selXend = illSel.VisibleBounds[2];
                Form1.selYend = illSel.VisibleBounds[3];
            }
            else
            {
                if (Form1.selX > illSel.VisibleBounds[0])
                {
                    Form1.selX = illSel.VisibleBounds[0];
                }
                if (Form1.selY < illSel.VisibleBounds[1])
                {
                    Form1.selY = illSel.VisibleBounds[1];
                }
                if (Form1.selXend < illSel.VisibleBounds[2])
                {
                    Form1.selXend = illSel.VisibleBounds[2];
                }
                if (Form1.selYend > illSel.VisibleBounds[3])
                {
                    Form1.selYend = illSel.VisibleBounds[3];
                }
            }
            Form1.tmpVal[txtNum, 0] = illSel.VisibleBounds[0];
            Form1.tmpVal[txtNum, 1] = illSel.VisibleBounds[1];
            Form1.tmpVal[txtNum, 2] = 0;
            Form1.tmpVal[txtNum, 3] = 0;
            Form1.tmpObj[txtNum] = illSel;
            progressBar3.Maximum++;
        }

        private void MyFrameGroup1(dynamic myGroup, int txtNum)
        {
            for (int i = myGroup.PageItems.Count; i > 0; i--)
            {
                if (myGroup.PageItems[i].Typename == "GroupItem")
                {
                    MyFrameGroup2(myGroup.PageItems[i], txtNum);
                }
                if ((myGroup.PageItems[i].Typename == "TextFrame") && (myGroup.PageItems[i].Contents != ""))
                {
                    txtNum++;
                    MyPreFrameConvert(myGroup.PageItems[i], txtNum);
                }
            }
        }

        private void MyFrameGroup2(dynamic myGroup, int txtNum)
        {
            for (int i = myGroup.PageItems.Count; i > 0; i--)
            {
                if (myGroup.PageItems[i].Typename == "GroupItem")
                {
                    MyFrameGroup1(myGroup.PageItems[i], txtNum);
                }
                if ((myGroup.PageItems[i].Typename == "TextFrame") && (myGroup.PageItems[i].Contents != ""))
                {
                    txtNum++;
                    MyPreFrameConvert(myGroup.PageItems[i], txtNum);
                }
            }
        }

        private void MyFrameConvert(dynamic inddDoc, int txtNum)
        {
            double[] myWid = new double[txtNum + 2];
            int[] kazu = new int[txtNum + 2];
            double checkVal = 0;
            double[] marginVal = { (double)myMargin.Value * 2.835, (double)myMarginY.Value * 2.835 };
            for (int i = 0; i < 2; i++)
            {
                int myCount = 0;
                while (myCount < txtNum + 1)
                {
                    myCount++;
                    for (int j = 0; j < txtNum + 1; j++)
                    {
                        if (Form1.tmpVal[j, i + 2] == 0)
                        {
                            checkVal = Form1.tmpVal[j, i];
                            kazu[i] = myCount;
                            for (int k = 0; k < txtNum + 1; k++)
                            {
                                if ((Form1.tmpVal[k, i] < checkVal) && (Form1.tmpVal[k, i + 2] == 0))
                                {
                                    checkVal = Form1.tmpVal[k, i];
                                }
                            }
                        }
                    }
                    if (i == 0) { myWid[myCount] = checkVal; }
                    for (int k = 0; k < txtNum + 1; k++)
                    {
                        if (((Form1.tmpVal[k, i] - marginVal[i]) <= checkVal) && (Form1.tmpVal[k, i + 2] == 0))
                        {
                            Form1.tmpVal[k, i + 2] = myCount;
                        }
                    }
                }
            }
            //ドキュメントにフレームを作成
            dynamic myTf = inddDoc.textFrames.add();
            if (checkXY.Checked == true)
            {
                myTf.visibleBounds = new dynamic[4] { -Form1.selY + Form1.docY + "pt", Form1.selX - Form1.docX + "pt", Form1.docY - Form1.selYend + "pt", Form1.selXend - Form1.docX + "pt" };
            }
            else
            {
                myTf.visibleBounds = new dynamic[4] { 0, 0, Form1.selY - Form1.selYend + "pt", Form1.selXend - Form1.selX + "pt" };
            }
            dynamic myStory = myTf.ParentStory;
            myStory.Contents = " ";

            //順序設定
            int[] tmpSort = new int[txtNum + 2];
            int[][] mySort = new int[txtNum + 2][];
            for (int i = 0; i < txtNum + 1; i++)
            {
                tmpSort[i] = -kazu[0] * (int)Form1.tmpVal[i, 3] + (int)Form1.tmpVal[i, 2];
                mySort[i] = new int[] { i , -kazu[0] * (int)Form1.tmpVal[i, 3] + (int)Form1.tmpVal[i, 2], 0, (int)Form1.tmpVal[i, 2]};
            }
            Array.Sort(tmpSort);

            for (int i = tmpSort.Length-1; i > -1; i--)
            {
                for (int j = 0; j < mySort.Length-1; j++)
                {
                    if (tmpSort[i] == mySort[j][1] && mySort[j][2] == 0)
                    {
                        dynamic inddChara = myStory.Characters[1];
                        dynamic illParaAtt = Form1.tmpObj[mySort[j][0]].Paragraphs[1];
                        dynamic illCharaAtt = Form1.tmpObj[mySort[j][0]].Characters[1];
                        try
                        {
                            inddChara.HorizontalScale = illCharaAtt.CharacterAttributes.HorizontalScale;
                            inddChara.VerticalScale = illCharaAtt.CharacterAttributes.VerticalScale;
                            inddChara.Tracking = illCharaAtt.CharacterAttributes.Tracking;
                        }
                        catch
                        {

                        }

                        try
                        {
                            inddChara.AppliedFont = illCharaAtt.CharacterAttributes.TextFont.Family + "\t" + illCharaAtt.CharacterAttributes.TextFont.Style;
                        }
                        catch
                        {

                        }
                        try
                        {
                            inddChara.PointSize = illCharaAtt.CharacterAttributes.Size + "pt";
                            inddChara.Leading = illCharaAtt.CharacterAttributes.Leading + "pt";
                            inddChara.SpaceAfter = illParaAtt.ParagraphAttributes.SpaceAfter + "pt";
                            inddChara.SpaceBefore = illParaAtt.ParagraphAttributes.SpaceBefore + "pt";
                            inddChara.BaselineShift = illParaAtt.CharacterAttributes.BaselineShift + "pt";
                        }
                        catch
                        {

                        }

                        if (Properties.Settings.Default.ColorConvert == true)
                        {
                            ColorConvert(illCharaAtt, inddDoc, inddChara);
                        }

                        mySort[j][2] = -1;
                        if (mySort[j][3] == 1 && i > 0)
                        {
                            inddChara.Contents = " \r" + Form1.tmpObj[mySort[j][0]].Contents;
                        }
                        else
                        {
                            inddChara.Contents = " " + Form1.tmpObj[mySort[j][0]].Contents;
                        }
                        progressBar3.Value++;
                        break;
                    }
                }
            }
            myStory.Characters[1].Contents = "";
            if (myStory.Characters[1].Contents == "\r")
            {
                myStory.Characters[1].Contents = "";
            }
        }
        #endregion

        private void MyMargin_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.saveMargin = myMargin.Value;
            Properties.Settings.Default.Save();
        }

        private void CheckXY_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.moveXY = checkXY.Checked;
            Properties.Settings.Default.Save();
        }

        private void MyMarginY_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.saveMarginY = myMarginY.Value;
            Properties.Settings.Default.Save();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void OneCharaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting myFrom = new Setting();
            myFrom.ShowDialog(this);
            myFrom.Dispose();
            if (Properties.Settings.Default.OneChara == false)
            {
                ConvertRun.Text = "実行";
            }
            if (Properties.Settings.Default.OneChara == true)
            {
                ConvertRun.Text = "実行（鈍足1文字モード）";
            }
        }

        private void ColorConvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color myFrom = new color();
            myFrom.ShowDialog(this);
            myFrom.Dispose();
            if (Properties.Settings.Default.ColorConvert == true)
            {
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
            }
            else
            {
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
        }

        //カラーコンバート;
        private void ColorConvert(dynamic illChara, dynamic inddDoc, dynamic inddChara)
        {
            if (illChara.CharacterAttributes.FillColor.TypeName == "GrayColor")
            {
                double colorTint = illChara.CharacterAttributes.FillColor.Gray;
                string colorName = "C=0 M=0 Y=0 K=100";
                if (Properties.Settings.Default.CMYK0 == true && colorTint == 0)
                {
                    inddChara.FillColor = "Paper";
                    return;
                }
                if (Properties.Settings.Default.CMY0 == true)
                {
                    inddChara.FillColor = "Black";
                    inddChara.FillTint = colorTint;
                    return;
                }
                try
                {
                    rwLock.AcquireWriterLock(Timeout.Infinite);
                    try
                    {
                        inddChara.FillColor = colorName;
                        inddChara.FillTint = colorTint;
                    }
                    catch
                    {
                        dynamic newColor = inddDoc.Colors.Add();
                        try
                        {
                            newColor.Name = colorName;
                            newColor.Space = idColorSpace.idCMYK;
                            newColor.Model = idColorModel.idProcess;
                            newColor.ColorValue = new int[] { 0, 0, 0, 100 };
                            inddChara.FillColor = newColor;
                            inddChara.FillTint = colorTint;
                        }
                        catch
                        {
                            inddChara.FillColor = colorName;
                            inddChara.FillTint = colorTint;
                            newColor.Delete();
                        }
                    }
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
                return;
            }
            if (illChara.CharacterAttributes.FillColor.TypeName == "SpotColor")
            {
                dynamic getSpotColor = illChara.CharacterAttributes.FillColor.Spot.GetInternalColor();
                double colorTint = illChara.CharacterAttributes.FillColor.Tint;
                string colorName = "C=" + (int)getSpotColor[0] + " M=" + (int)getSpotColor[1] + " Y=" + (int)getSpotColor[2] + " K=" + (int)getSpotColor[3];
                try
                {
                    rwLock.AcquireWriterLock(Timeout.Infinite);
                    try
                    {
                        inddChara.FillColor = colorName;
                        inddChara.FillTint = colorTint;
                    }
                    catch
                    {
                        dynamic newColor = inddDoc.Colors.Add();
                        try
                        {
                            newColor.Name = colorName;
                            newColor.Space = idColorSpace.idCMYK;
                            newColor.Model = idColorModel.idProcess;
                            newColor.ColorValue = new int[] { (int)getSpotColor[0], (int)getSpotColor[1], (int)getSpotColor[2], (int)getSpotColor[3] };
                            inddChara.FillColor = newColor;
                            inddChara.FillTint = colorTint;
                        }
                        catch
                        {
                            inddChara.FillColor = colorName;
                            inddChara.FillTint = colorTint;
                            newColor.Delete();
                        }
                    }
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
                return;
            }
            if (illChara.CharacterAttributes.FillColor.TypeName == "NoColor")
            {
                inddChara.FillColor = "None";
                return;
            }
            try
            {
                double myC = illChara.CharacterAttributes.FillColor.Cyan;
                double myM = illChara.CharacterAttributes.FillColor.Magenta;
                double myY = illChara.CharacterAttributes.FillColor.Yellow;
                double myK = illChara.CharacterAttributes.FillColor.Black;
                string colorName = "C=" + (int)myC + " M=" + (int)myM + " Y=" + (int)myY + " K=" + (int)myK;
                if (Properties.Settings.Default.CMYK0 == true && colorName == "C=0 M=0 Y=0 K=0")
                {
                    inddChara.FillColor = "Paper";
                    return;
                }
                if (Properties.Settings.Default.CMY0 == true && colorName.IndexOf("C=0 M=0 Y=0") > -1)
                {
                    inddChara.FillColor = "Black";
                    inddChara.FillTint = (int)myK;
                    return;
                }
                try
                {
                    rwLock.AcquireWriterLock(Timeout.Infinite);
                    try
                    {
                        inddChara.FillColor = colorName;
                    }
                    catch
                    {
                        dynamic newColor = inddDoc.Colors.Add();
                        try
                        {
                            newColor.Name = colorName;
                            newColor.Space = idColorSpace.idCMYK;
                            newColor.Model = idColorModel.idProcess;
                            newColor.ColorValue = new int[] { (int)myC, (int)myM, (int)myY, (int)myK };
                            inddChara.FillColor = newColor;
                        }
                        catch
                        {
                            inddChara.FillColor = colorName;
                            newColor.Delete();
                        }
                    }
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
            }
            catch
            {

            }
        }

        //線カラーコンバート
        private void StrokeColorConvert(dynamic illChara, dynamic inddDoc, dynamic inddChara)
        {
            if (illChara.CharacterAttributes.StrokeColor.TypeName == "NoColor")
            {
                inddChara.StrokeColor = "None";
                return;
            }
            if (illChara.CharacterAttributes.StrokeColor.TypeName == "GrayColor")
            {
                double colorTint = illChara.CharacterAttributes.StrokeColor.Gray;
                string colorName = "C=0 M=0 Y=0 K=100";
                if (Properties.Settings.Default.CMYK0 == true && colorTint == 0)
                {
                    inddChara.StrokeColor = "Paper";
                    return;
                }
                if (Properties.Settings.Default.CMY0 == true)
                {
                    inddChara.StrokeColor = "Black";
                    inddChara.StrokeTint = colorTint;
                    return;
                }

                try
                {
                    rwLock.AcquireWriterLock(Timeout.Infinite);
                    try
                    {
                        inddChara.StrokeColor = colorName;
                        inddChara.StrokeTint = colorTint;
                    }
                    catch
                    {
                        dynamic newColor = inddDoc.Colors.Add();
                        try
                        {
                            newColor.Name = colorName;
                            newColor.Space = idColorSpace.idCMYK;
                            newColor.Model = idColorModel.idProcess;
                            newColor.ColorValue = new int[] { 0, 0, 0, 100 };
                            inddChara.StrokeColor = newColor;
                            inddChara.StrokeTint = colorTint;
                        }
                        catch
                        {
                            inddChara.StrokeColor = colorName;
                            inddChara.StrokeTint = colorTint;
                            newColor.Delete();
                        }
                    }
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
                return;
            }
            if (illChara.CharacterAttributes.StrokeColor.TypeName == "SpotColor")
            {
                dynamic getSpotColor = illChara.CharacterAttributes.StrokeColor.Spot.GetInternalColor();
                double colorTint = illChara.CharacterAttributes.StrokeColor.Tint;
                string colorName = "C=" + (int)getSpotColor[0] + " M=" + (int)getSpotColor[1] + " Y=" + (int)getSpotColor[2] + " K=" + (int)getSpotColor[3];
                try
                {
                    rwLock.AcquireWriterLock(Timeout.Infinite);
                    try
                    {
                        inddChara.StrokeColor = colorName;
                        inddChara.StrokeTint = colorTint;
                    }
                    catch
                    {
                        dynamic newColor = inddDoc.Colors.Add();
                        try
                        {
                            newColor.Name = colorName;
                            newColor.Space = idColorSpace.idCMYK;
                            newColor.Model = idColorModel.idProcess;
                            newColor.ColorValue = new int[] { (int)getSpotColor[0], (int)getSpotColor[1], (int)getSpotColor[2], (int)getSpotColor[3] };
                            inddChara.StrokeColor = newColor;
                            inddChara.StrokeTint = colorTint;
                        }
                        catch
                        {
                            inddChara.StrokeColor = colorName;
                            inddChara.StrokeTint = colorTint;
                            newColor.Delete();
                        }
                    }
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
                return;
            }
            try
            {
                double myC = illChara.CharacterAttributes.StrokeColor.Cyan;
                double myM = illChara.CharacterAttributes.StrokeColor.Magenta;
                double myY = illChara.CharacterAttributes.StrokeColor.Yellow;
                double myK = illChara.CharacterAttributes.StrokeColor.Black;
                string colorName = "C=" + (int)myC + " M=" + (int)myM + " Y=" + (int)myY + " K=" + (int)myK;
                if (Properties.Settings.Default.CMYK0 == true && colorName == "C=0 M=0 Y=0 K=0")
                {
                    inddChara.StrokeColor = "Paper";
                    return;
                }
                if (Properties.Settings.Default.CMY0 == true && colorName.IndexOf("C=0 M=0 Y=0") > -1)
                {
                    inddChara.StrokeColor = "Black";
                    inddChara.StrokeTint = (int)myK;
                    return;
                }
                try
                {
                    rwLock.AcquireWriterLock(Timeout.Infinite);
                    try
                    {

                        inddChara.StrokeColor = colorName;
                    }
                    catch
                    {
                        dynamic newColor = inddDoc.Colors.Add();
                        try
                        {
                            newColor.Name = colorName;
                            newColor.Space = idColorSpace.idCMYK;
                            newColor.Model = idColorModel.idProcess;
                            newColor.ColorValue = new int[] { (int)myC, (int)myM, (int)myY, (int)myK };
                            inddChara.StrokeColor = newColor;
                        }
                        catch
                        {
                            inddChara.StrokeColor = colorName;
                            newColor.Delete();
                        }
                    }
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
            }
            catch
            {
            }
        }

        private void OtherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Other myFrom = new Other();
            myFrom.ShowDialog(this);
            myFrom.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void 使用Ver切替ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
    }

    static class ProgramCheck
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ミューテックス生成
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(false, System.Windows.Forms.Application.ProductName))
            {
                // 二重起動を禁止する
                if (mutex.WaitOne(0, false))
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    System.Windows.Forms.Application.Run(new Form1());
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("既に起動しています。");
                }
            }
        }
    }
}
