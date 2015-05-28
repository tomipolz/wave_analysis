using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Threading;

namespace WaveGenAnalysis
{
    public partial class FormMain : Form
    {
        WaveForm waveForm = new WaveForm();
        Size OldSize;
        FormWindowState OldFormWindowsState;
        public FormMain()
        {
            InitializeComponent();
            OldFormWindowsState = WindowState;
        }

        /// <summary>
        /// Select .csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectCSVFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "CSV|*csv";
            openFileDialog.DefaultExt = "|*csv";
            openFileDialog.FileName = "Wave";

            // Run through openFileDialog - using switch to make easier to run through different result scenario
            switch (openFileDialog.ShowDialog())
            { 
                case System.Windows.Forms.DialogResult.Cancel:
                    Console.WriteLine("File Cancelled");
                    break;
                case System.Windows.Forms.DialogResult.OK:
                    Console.WriteLine("File Selected");
                    FormLoading formLoading = new FormLoading();
                    formLoading.Show();
                    try
                    {
                        // read selected files
                        waveForm.ClearRawText();
                        listBoxCollection.Items.Clear();
                        waveForm.ClearFileNameList(); waveForm.ClearFrequencyItems(); waveForm.ClearRawText();
                        //progressBarAxisProgress.Value = progressBarAxisProgress.Minimum;
                        //progressBarAxisProgress.Maximum = openFileDialog.FileNames.Count();
                        formLoading.progressBarPrimary.Value = formLoading.progressBarPrimary.Minimum;
                        formLoading.progressBarPrimary.Maximum = openFileDialog.FileNames.Count();
                        foreach (string FileName in openFileDialog.FileNames)
                        {
                            waveForm.AddRawTextItem(System.IO.File.ReadAllText(FileName));
                            waveForm.AddFileNameItem(FileName.Split((char)92)[FileName.Split((char)92).Count() - 1]);
                            listBoxCollection.Items.Add(FileName);

                            /*Console.WriteLine("sortTextToStringList");
                            sortTextToStringList(waveForm.GetRawTextFromIndex(waveForm.GetFileName().Count() - 1).ToString());

                            Console.WriteLine("sortStringListToDoubleList");
                            sortStringListToDoubleList(waveForm.GetXAxis(), waveForm.GetYAxis());

                            waveForm.AddFrequencyItem(calculateFrequency(waveForm.GetXAxisDouble(), waveForm.GetYAxisDouble(), textBoxThreshold.Text.ToString(), textBoxReanalyse.Text.ToString()));*/

                            formLoading.progressBarPrimary.Value++;
                            //progressBarAxisProgress.Value++;
                            //Console.WriteLine("Adding - " + openFileDialog.FileName);
                        }
                        Console.WriteLine("Adding complete");
                        //progressBarAxisProgress.Value = progressBarAxisProgress.Minimum;
                    }
                    catch (Exception ex)
                    {
                        // show excemption if problem occurs
                        MessageBox.Show(ex.Message); Console.WriteLine(ex.Message);
                    }
                    formLoading.Close(); formLoading.Dispose(); formLoading = null;
                    break;
            }
        }

        /// <summary>
        /// This method converts one long string into two seperate axis lists and automatically saves it to waveForm class and refreshes listboxes
        /// </summary>
        /// <param name="InputRawText"></param>
        private void sortTextToStringList(string InputRawText = "")
        {
            Console.WriteLine("SortTextToList method launched");

            // clear list items, list box items and refresh
            waveForm.ClearXAxis(); waveForm.ClearYAxis();

            // if no text is put through, stop here
            if (InputRawText == "" || InputRawText == null)
            {
                Console.WriteLine("SortTextToList - empty string"); return;
            }

            // if text has come through, carry on...seperate lines (or at return char) into arrays
            string[] LineSeperatedText = InputRawText.Split(Convert.ToChar(Keys.Return));
            Console.WriteLine("LineSeperatedText item count: " + LineSeperatedText.Count().ToString());

            // set progress bar to empty
            progressBarAxisProgress.Maximum = LineSeperatedText.Count();
            progressBarAxisProgress.Value = 0;

            // store temp list results until this method finishes
            List<string> TempXAxis = new List<string>(); List<string> TempYAxis = new List<string>();

            // seperate text in arrays at commas into more arrays, store results inside TempXAxis and TempYAxis
            int i = 0; string[] CommaSeperatedText; while (LineSeperatedText.Count() != 0)
            {
                if (i + 1 == LineSeperatedText.Count())
                {
                    Console.WriteLine("Reached maximum index");
                    progressBarAxisProgress.Value = progressBarAxisProgress.Maximum; break;
                }
                CommaSeperatedText = LineSeperatedText[i].Split(',');
                CommaSeperatedText[0].Replace("\n", ""); CommaSeperatedText[1].Replace("\n", "");
                TempXAxis.Add(CommaSeperatedText[0]); TempYAxis.Add(CommaSeperatedText[1]);
                //Console.WriteLine("CommaSeperatedText[0]: " + CommaSeperatedText[0] + " CommaSeperatedText[1]: " + CommaSeperatedText[1]);
                i++; 
                //Console.WriteLine("Adding index: " + (i + 1).ToString()); 
                progressBarAxisProgress.Value = i;
                
            }

            // save results to waveForm class
            waveForm.SetXAxis(TempXAxis); waveForm.SetYAxis(TempYAxis);
            progressBarAxisProgress.Value = progressBarAxisProgress.Minimum;
        }

        /// <summary>
        /// Parse string list pair to double list pair
        /// </summary>
        /// <param name="InputXStringList"></param>
        /// <param name="InputYStringList"></param>
        private void sortStringListToDoubleList(List<string> InputXStringList, List<string> InputYStringList)
        {
            if (InputXStringList.Count == 0 || InputYStringList.Count == 0 || InputYStringList.Count != InputXStringList.Count) { return; }

            List<double> XAxisConverted = new List<double>();
            List<double> YAxisConverted = new List<double>();

            int i = 1; while (i + 1 <= InputXStringList.Count() || i + 1 <= InputYStringList.Count)
            {
                try
                {
                    //Console.WriteLine("Converting string index " + i.ToString());
                    XAxisConverted.Add(double.Parse(InputXStringList[i], NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture));
                    YAxisConverted.Add(double.Parse(InputYStringList[i], NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                i++; progressBarAxisProgress.Value = i;
            }

            progressBarAxisProgress.Value = progressBarAxisProgress.Minimum;
            waveForm.SetXAxisDouble(XAxisConverted); waveForm.SetYAxisDouble(YAxisConverted);
            Console.Write("Converted " + i.ToString() + " string pairs to doubles");
        }

        /// <summary>
        /// Plot graph, will automatically readjust
        /// </summary>
        /// <param name="XAxis"></param>
        /// <param name="YAxis"></param>
        private void drawGraph(List<double> InputXDoubleList, List<double> InputYDoubleList)
        {
            Bitmap DrawPlot = new Bitmap(pictureBoxGraph.Size.Width, pictureBoxGraph.Size.Height);
            pictureBoxGraph.Image = DrawPlot;

            if (InputXDoubleList.Count == 0 || InputYDoubleList.Count == 0 || InputXDoubleList.Count != InputYDoubleList.Count || !checkBoxDrawGraph.Checked)
            {
                using (Graphics ClearData = Graphics.FromImage(pictureBoxGraph.Image))
                {
                    ClearData.Clear(Color.Transparent);
                }
                pictureBoxGraph.Refresh();
                return; 
            }
            Console.WriteLine("XAxis and YAxis values present");

            Pen AxisLines = new Pen(Color.White);
            Pen DataPlot = new Pen(Color.Red);

            Double XAxisRange = InputXDoubleList.Max() - InputXDoubleList.Min();
            textBoxXRange.Text = XAxisRange.ToString();
            Double XAxisPixelProportion = pictureBoxGraph.Size.Width / XAxisRange;
            Double XAxisOffset = InputXDoubleList.Max();

            Double YAxisRange = InputYDoubleList.Max() - InputYDoubleList.Min();
            textBoxYRange.Text = YAxisRange.ToString();
            Double YAxisPixelProportion = pictureBoxGraph.Size.Height / YAxisRange;
            Double YAxisOffset = InputYDoubleList.Max();
            Console.WriteLine("Calculated graph dimentions");

            using (Graphics PlottingData = Graphics.FromImage(pictureBoxGraph.Image))
            {
                Console.WriteLine("Starting drawing graph");
                PlottingData.Clear(Color.Black);
                progressBarAxisProgress.Maximum = InputXDoubleList.Count();
                PlottingData.DrawLine(AxisLines, new Point(0, (int)(YAxisOffset*YAxisPixelProportion)), 
                    new Point(pictureBoxGraph.Size.Width, (int)(YAxisOffset*YAxisPixelProportion)));
                PlottingData.DrawLine(AxisLines, new Point((int)(XAxisOffset*XAxisPixelProportion), 0), 
                    new Point((int)(XAxisOffset*XAxisPixelProportion), pictureBoxGraph.Size.Height));

                int i = 1; while (i + 1 <= InputXDoubleList.Count() || i + 1 <= InputYDoubleList.Count())
                {
                    PlottingData.DrawLine(DataPlot,
                        new Point(Convert.ToInt32((InputXDoubleList[i - 1]) * XAxisPixelProportion - InputXDoubleList.Min() * XAxisPixelProportion),
                            Convert.ToInt32(InputYDoubleList.Max() * YAxisPixelProportion - (InputYDoubleList[i - 1]) * YAxisPixelProportion)),
                        new Point(Convert.ToInt32((InputXDoubleList[i]) * XAxisPixelProportion - InputXDoubleList.Min() * XAxisPixelProportion),
                            Convert.ToInt32(InputYDoubleList.Max() * YAxisPixelProportion - (InputYDoubleList[i]) * YAxisPixelProportion)));
                    i++; progressBarAxisProgress.Value = i;
                }
            }
            progressBarAxisProgress.Value = progressBarAxisProgress.Minimum;
            pictureBoxGraph.Refresh();
            Console.WriteLine("Drawing graph complete");
        }

        /// <summary>
        /// Calculate frequency of maximum amplityde signal
        /// </summary>
        /// <param name="InputXDoubleList"></param>
        /// <param name="InputYDoubleList"></param>
        /// <param name="InYThreshold"></param>
        /// <param name="InXPart"></param>
        /*private double calculateFrequency(List<double> InputXDoubleList, List<double> InputYDoubleList, string InYThreshold, string InXPart)
        {
            List<double> TempXList = new List<double>();
            List<double> TempYList = new List<double>();
            int YThreshold; int Xpart; 
            try 
            {
                YThreshold = Convert.ToInt32(InYThreshold); 
                Console.WriteLine("Threshold " + YThreshold.ToString());

                Xpart = Convert.ToInt32((double)InputXDoubleList.Count * (Convert.ToDouble(InXPart)/(double)100));
                Console.WriteLine(Xpart.ToString() + " out of " + InputYDoubleList.Count.ToString());

                TempXList = InputXDoubleList.GetRange(0, Xpart); //Console.WriteLine("X Copied " + TempXList.Count.ToString());
                TempYList = InputYDoubleList.GetRange(0, Xpart); //Console.WriteLine("Y Copied " + TempYList.Count.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); return 0;
            }

            if (Convert.ToInt32(InXPart) > 100)
            {
                Console.WriteLine("Xpart cannot go over 100"); return 0;
            }

            if (InputXDoubleList.Count == 0 || InputYDoubleList.Count == 0 || InputXDoubleList.Count != InputYDoubleList.Count)
            {
                Console.WriteLine("Empty or Unequal item count in lists"); return 0;
            }

            //double XRange = TempXList.Max() - TempXList.Min();
            int FirstTopIndex = 0; int FirstBottomIndex = 0; 
            int SecondTopIndex = 0; //int i = 0;

            //Console.WriteLine("TempXMax " + TempXList.Max().ToString() + " Upper Threshold " + ((TempYList.Max() * (double)YThreshold) / (double)100).ToString());
            //Console.WriteLine("TempYMax " + TempYList.Max().ToString());
            //Console.WriteLine("TempXMin " + TempXList.Min().ToString() + " Lower Threshold " + ((TempYList.Min() * (double)YThreshold) / (double)100).ToString());
            //Console.WriteLine("TempYMin " + TempYList.Min().ToString());

            progressBarAxisProgress.Maximum = TempXList.Count(); progressBarAxisProgress.Value = progressBarAxisProgress.Minimum;
            double TempYListRange = TempYList.Max() - TempYList.Min();
            double TopThreshold = 
                ((TempYList.Max() - ((TempYListRange / (double)2) * ((double)YThreshold) / (double)100)));
            double BottomThreshold = 
                ((TempYList.Min() + ((TempYListRange / (double)2) * ((double)YThreshold) / (double)100)));
            Console.WriteLine("Max " + TempYList.Max().ToString() + " , TMax " + TopThreshold.ToString());
            Console.WriteLine("Min " + TempYList.Min().ToString() + " , TMin " + BottomThreshold.ToString());
            Console.WriteLine("Range " + TempYListRange.ToString());
            bool FirstPeakReached = false; bool FirstCrestReached = false; bool SecondPeakReached = false;
            for (int i = 0; i < (int)TempYList.Count(); i++)
            {
                Console.WriteLine("TempYList[" + i.ToString() + "] = " + TempYList[i].ToString());
                if ((double)TempYList[i] >= (double)TopThreshold)
                {
                    Console.WriteLine("Current => TMax");
                    if (!FirstPeakReached)
                    {
                        FirstPeakReached = true;
                        FirstTopIndex = i;
                    }
                    if (FirstPeakReached && FirstCrestReached && !SecondPeakReached)
                    {
                        SecondPeakReached = true;
                        SecondTopIndex = i;
                    }
                }
                if ((double)TempYList[i] <= (double)BottomThreshold)
                {
                    Console.WriteLine("Current <= TMin");
                    if (FirstPeakReached && !FirstCrestReached)
                    {
                        FirstCrestReached = true;
                        FirstBottomIndex = i;
                    }
                }
                //i++; 
                progressBarAxisProgress.Value = i;
            }
            progressBarAxisProgress.Value = progressBarAxisProgress.Minimum;
            Pen FirstTopPen = new Pen(Color.Yellow, 3); Pen FirstBottomPen = new Pen(Color.Green, 3); Pen SecondTopPen = new Pen(Color.Orange, 3);
            Pen ThresholdTopPen = new Pen(Color.OrangeRed);
            Pen ThresholdBottomPen = new Pen(Color.Blue);
            using (Graphics TopBottomGraphics = System.Drawing.Graphics.FromImage(pictureBoxGraph.Image))
            {
                if (FirstPeakReached)
                {
                    TopBottomGraphics.DrawLine(FirstTopPen,
                        new Point((pictureBoxGraph.Image.Width * FirstTopIndex) / InputXDoubleList.Count(), 0),
                        new Point((pictureBoxGraph.Image.Width * FirstTopIndex) / InputXDoubleList.Count(), pictureBoxGraph.Image.Height));
                }
                if (FirstCrestReached)
                {
                    TopBottomGraphics.DrawLine(FirstBottomPen,
                        new Point((pictureBoxGraph.Image.Width * FirstBottomIndex) / InputXDoubleList.Count(), 0),
                        new Point((pictureBoxGraph.Image.Width * FirstBottomIndex) / InputXDoubleList.Count(), pictureBoxGraph.Image.Height));
                }
                if (SecondPeakReached)
                {
                    TopBottomGraphics.DrawLine(SecondTopPen,
                        new Point((pictureBoxGraph.Image.Width * SecondTopIndex) / InputXDoubleList.Count(), 0),
                        new Point((pictureBoxGraph.Image.Width * SecondTopIndex) / InputXDoubleList.Count(), pictureBoxGraph.Image.Height));
                }
                double GTopThreshold = ((double)pictureBoxGraph.Image.Height/(double)2) - (double)pictureBoxGraph.Image.Height * (TopThreshold / (InputYDoubleList.Max() - InputYDoubleList.Min()));
                TopBottomGraphics.DrawLine(ThresholdTopPen,
                    new Point(0, Convert.ToInt32(GTopThreshold)),
                    new Point(pictureBoxGraph.Image.Width, Convert.ToInt32(GTopThreshold)));

                double GBottomThreshold = ((double)pictureBoxGraph.Image.Height / (double)2) + ((double)pictureBoxGraph.Image.Height) * (TopThreshold / (InputYDoubleList.Max() - InputYDoubleList.Min()));
                TopBottomGraphics.DrawLine(ThresholdBottomPen,
                    new Point(0, Convert.ToInt32(GBottomThreshold)),
                    new Point(pictureBoxGraph.Image.Width, Convert.ToInt32(GBottomThreshold)));
            }
            FirstTopPen.Dispose(); FirstBottomPen.Dispose(); SecondTopPen.Dispose();
            pictureBoxGraph.Refresh(); ThresholdTopPen.Dispose(); ThresholdBottomPen.Dispose();

            if (FirstTopIndex != 0 && SecondTopIndex != 0 && FirstBottomIndex != 0)
            {
                Console.WriteLine("works!"); return (1/(TempXList[SecondTopIndex] - TempXList[FirstTopIndex]));
            }
            else
            {
                Console.WriteLine("not working"); return 0;
            }
        }
        */
        /// <summary>
        /// Redraw graph if windows gets resized (performance is poor at the moment)
        /// NOTE: Also called on resizeEnd event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Size == OldSize) { return; }
            Console.WriteLine("PictureBox graph size changed");
            //if (waveForm.GetXAxis().Count == 0 || waveForm.GetYAxis().Count == 0) { return; }
            drawGraph(waveForm.GetXAxisDouble(), waveForm.GetYAxisDouble());
        }
        private void FormMain_ResizeBegin(object sender, EventArgs e)
        {
            OldFormWindowsState = WindowState;
            OldSize = new Size(this.Size.Width, this.Size.Height);
        }
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == OldFormWindowsState) { return; }
            OldFormWindowsState = WindowState; OldSize = this.Size;
            drawGraph(waveForm.GetXAxisDouble(), waveForm.GetYAxisDouble());
        }
        private void checkBoxDrawGraph_CheckedChanged(object sender, EventArgs e)
        {
            drawGraph(waveForm.GetXAxisDouble(), waveForm.GetYAxisDouble());
        }

        private void listBoxCollection_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxCollection.SelectedIndex == -1) { return; }
            else
            {
                Console.WriteLine("Selected index " + listBoxCollection.SelectedIndex.ToString());
                try
                {
                    WaveAnalalysis waveAnalysis = new WaveAnalalysis();
                    Console.WriteLine("sortTextToStringList");
                    sortTextToStringList(waveForm.GetRawTextFromIndex(listBoxCollection.SelectedIndex).ToString()); 
                    labelCurrentFile.Text = listBoxCollection.Items[listBoxCollection.SelectedIndex].ToString();

                    Console.WriteLine("sortStringListToDoubleList");
                    sortStringListToDoubleList(waveForm.GetXAxis(), waveForm.GetYAxis());

                    Console.WriteLine("drawGraph");
                    drawGraph(waveForm.GetXAxisDouble(), waveForm.GetYAxisDouble());

                    textBoxFrequency.Text = waveAnalysis.calculateFrequency(
                        waveForm.GetXAxisDouble(), waveForm.GetYAxisDouble(), Convert.ToInt32(textBoxThreshold.Text), Convert.ToInt32(textBoxReanalyse.Text)).ToString("F2");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                WaveAnalalysis waveAnalysis = new WaveAnalalysis();
                textBoxFrequency.Text = waveAnalysis.calculateFrequency(
                    waveForm.GetXAxisDouble(), waveForm.GetYAxisDouble(), Convert.ToInt32(textBoxThreshold.Text), Convert.ToInt32(textBoxReanalyse.Text)).ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Task buttonOutputCSVFile_ClickTask;
        private void buttonOutputCSVFile_ClickWorker()
        {
            WaveAnalalysis waveAnalysis = new WaveAnalalysis();

            List<string> TempList = new List<string>();

            FormLoading formLoading = new FormLoading();

            while (formLoading == null) ;

            formLoading.progressBarPrimary.Maximum = waveForm.GetFileName().Count();
            formLoading.progressBarPrimary.Value = formLoading.progressBarPrimary.Minimum;
            formLoading.Show();

            foreach (string FileName in waveForm.GetFileName())
            {
                string[] NewItem = new string[2];
                string[] NewColumnItems = waveForm.GetRawText()[waveForm.GetFileName().IndexOf(FileName)].Split((char)Keys.Return);

                List<double> TimeIntervalList = new List<double>();
                List<double> VoltageLevelList = new List<double>();

                NewItem[0] = FileName;
                int i = 1; while (NewColumnItems.Count() - 1 > i)
                {
                    if (NewColumnItems[i] != "")
                    {
                        double ParsedTime = double.Parse(NewColumnItems[i].Split(',')[NewColumnItems[i].Split(',').Count() - 2], NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture);
                        double ParsedVolt = double.Parse(NewColumnItems[i].Split(',')[NewColumnItems[i].Split(',').Count() - 1], NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture);

                        TimeIntervalList.Add(ParsedTime);
                        VoltageLevelList.Add(ParsedVolt);
                    } i++;
                }
                double Frequency = 0;
                int InYThreshold = 10; int InXPart = 25; while (Frequency == 0)
                {
                    Frequency = waveAnalysis.calculateFrequency(TimeIntervalList, VoltageLevelList, InYThreshold, InXPart);
                    InYThreshold += 10;
                    {
                        if (InYThreshold > 60)
                        {
                            InYThreshold = 10; 
                            InXPart += 25;
                        }
                        if (InXPart > 100) 
                        {
                            Console.WriteLine("Loop broken");
                            break;
                        }
                    }
                }
                NewItem[1] = Frequency.ToString();
                TempList.Add(NewItem[0] + "," + NewItem[1]);
                formLoading.progressBarPrimary.Value++;
            }
            formLoading.Close();
            FormList secondFormList = new FormList(waveAnalysis.SortByFrequency(TempList));
            secondFormList.ShowDialog(); 
        }
        private void buttonOutputCSVFile_Click(object sender, EventArgs e)
        {
            /*if (buttonOutputCSVFile_ClickTask != null)
            {
                if (!buttonOutputCSVFile_ClickTask.IsCompleted)
                {
                    return;
                }
            }
            buttonOutputCSVFile_ClickTask = Task.Run(action: buttonOutputCSVFile_ClickWorker);*/
            buttonOutputCSVFile_ClickWorker();
        }
    }

    /// <summary>
    /// Where waveform data is stored
    /// </summary>
    class WaveForm
    {
        /// <summary>
        /// RawText list, each item for each file read
        /// </summary>
        List<string> RawText = new List<string>(); //String RawText;
        /// <summary>
        /// Get RawText list
        /// </summary>
        /// <returns></returns>
        public List<string> GetRawText()
        {
            return RawText;
        }
        /// <summary>
        /// Get string from RawText index
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public string GetRawTextFromIndex(int Index)
        {
            return RawText[Index];
        }
        /// <summary>
        /// Set RawText list
        /// </summary>
        /// <param name="NewRawText"></param>
        public void SetRawText(List<string> NewRawText)
        {
            RawText = NewRawText;
        }
        /// <summary>
        /// Add NewRawTextItem string to RawText list
        /// </summary>
        /// <param name="NewRawTextItem"></param>
        public void AddRawTextItem(string NewRawTextItem)
        {
            RawText.Add(NewRawTextItem);
        }
        /// <summary>
        /// Clear RawText list
        /// </summary>
        public void ClearRawText()
        {
            RawText.Clear();
        }

        /// <summary>
        /// FileName list, name of file for each RawText
        /// </summary>
        List<string> FileName = new List<string>();
        public List<string> GetFileName()
        {
            return FileName;
        }
        public void SetFileName(List<string> NewFileName)
        {
            FileName = NewFileName;
        }
        public void AddFileNameItem(string NewFileNameItem)
        {
            FileName.Add(NewFileNameItem);
        }
        public void ClearFileNameList()
        {
            FileName.Clear();
        }

        /// <summary>
        /// Store frequency value
        /// </summary>
        List<double> Frequency = new List<double>();
        /// <summary>
        /// Get Frequency value
        /// </summary>
        /// <returns></returns>
        public List<double> GetFrequency()
        {
            return Frequency;
        }
        /// <summary>
        /// Set Frequency value
        /// </summary>
        /// <param name="NewFrequency"></param>
        public void SetFrequency(List<double> NewFrequency)
        {
            Frequency = NewFrequency;
        }
        public void AddFrequencyItem(double NewFrequencyItem)
        {
            Frequency.Add(NewFrequencyItem);
        }
        public void ClearFrequencyItems()
        {
            Frequency.Clear();
        }

        /// <summary>
        /// Store data arrays
        /// </summary>
        List<string> XAxis = new List<string>();
        List<double> XAxisDouble = new List<double>();
        /// <summary>
        /// Returns XAxis list in string format
        /// </summary>
        /// <returns></returns>
        public List<string> GetXAxis()
        {
            return XAxis;
        }
        /// <summary>
        /// Set XAxis list in string format
        /// </summary>
        /// <param name="NewXAxis"></param>
        public void SetXAxis(List<string> NewXAxis)
        {
            XAxis = NewXAxis;
        }
        /// <summary>
        /// Clear XAxis
        /// </summary>
        public void ClearXAxis()
        {
            XAxis.Clear();
        }
        /// <summary>
        /// Set XAxisDouble list
        /// </summary>
        /// <returns></returns>
        public List<double> GetXAxisDouble()
        {
            return XAxisDouble;
        }
        /// <summary>
        /// Get XAxisDouble list
        /// </summary>
        /// <param name="NewXAxisDouble"></param>
        public void SetXAxisDouble(List<double> NewXAxisDouble)
        {
            XAxisDouble = NewXAxisDouble;
        }

        List<string> YAxis = new List<string>();
        List<double> YAxisDouble = new List<double>();
        /// <summary>
        /// Set YAxisDouble list
        /// </summary>
        /// <returns></returns>
        public List<double> GetYAxisDouble()
        {
            return YAxisDouble;
        }
        /// <summary>
        /// Get YAxisDouble list
        /// </summary>
        /// <param name="NewYAxisDouble"></param>
        public void SetYAxisDouble(List<double> NewYAxisDouble)
        {
            YAxisDouble = NewYAxisDouble;
        }
        /// <summary>
        /// Returns YAxis list in string format
        /// </summary>
        /// <returns></returns>
        public List<string> GetYAxis()
        {
            return YAxis;
        }
        /// <summary>
        /// Set YAxis list in string format
        /// </summary>
        /// <param name="NewYAxis"></param>
        public void SetYAxis(List<string> NewYAxis)
        {
            YAxis = NewYAxis;
        }
        /// <summary>
        /// Clear YAxis
        /// </summary>
        public void ClearYAxis()
        {
            YAxis.Clear();
        }
    }

    /// <summary>
    /// Independent methods to analyse waveform
    /// </summary>
    class WaveAnalalysis
    {
        /// <summary>
        /// Calculate frequency for this wave form, returns frequency in Hz
        /// </summary>
        /// <param name="InputXDoubleList"></param>
        /// <param name="InputYDoubleList"></param>
        /// <param name="InYThreshold"></param>
        /// <param name="InXPart"></param>
        /// <returns></returns>
        public double calculateFrequency(List<double> InputXDoubleList, List<double> InputYDoubleList, int InYThreshold = 80, int InXPart = 20)
        {
            List<double> TempXList = new List<double>();
            List<double> TempYList = new List<double>();
            int YThreshold; int Xpart;
            try
            {
                YThreshold = Convert.ToInt32(InYThreshold);
                //Console.WriteLine("Threshold " + YThreshold.ToString());

                Xpart = Convert.ToInt32((double)InputXDoubleList.Count * (Convert.ToDouble(InXPart) / (double)100));
                //Console.WriteLine(Xpart.ToString() + " out of " + InputYDoubleList.Count.ToString());

                TempXList = InputXDoubleList.GetRange(0, Xpart); //Console.WriteLine("Copied " + TempXList.Count.ToString());
                TempYList = InputYDoubleList.GetRange(0, Xpart); //Console.WriteLine("Copied " + TempYList.Count.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); return 0;
            }

            if (Convert.ToInt32(InYThreshold) > 100 || Convert.ToInt32(InXPart) > 100)
            {
                Console.WriteLine("Ythreshold and/or Xpart over 100"); return 0;
            }

            if (InputXDoubleList.Count == 0 || InputYDoubleList.Count == 0 || InputXDoubleList.Count != InputYDoubleList.Count)
            {
                Console.WriteLine("Empty or Unequal item count in lists"); return 0;
            }

            //double XRange = TempXList.Max() - TempXList.Min();
            int FirstTopIndex = 0; int FirstBottomIndex = 0; int SecondTopIndex = 0;
            //double TempYListRange = TempXList.Max() - TempXList.Min();
            double TempYListRange = TempYList.Max() - TempYList.Min();
            double TopThreshold =
                ((TempYList.Max() - ((TempYListRange / (double)2) * ((double)YThreshold) / (double)100)));
            double BottomThreshold =
                ((TempYList.Min() + ((TempYListRange / (double)2) * ((double)YThreshold) / (double)100)));
            bool FirstPeakReached = false; bool FirstCrestReached = false; bool SecondPeakReached = false;
            for (int i = 0; i < (int)TempYList.Count(); i++)
            {
                //Console.WriteLine("TempYList[" + i.ToString() + "] = " + TempYList[i].ToString());
                if ((double)TempYList[i] >= (double)TopThreshold)
                {
                    //Console.WriteLine("Current => TMax");
                    if (!FirstPeakReached)
                    {
                        FirstPeakReached = true;
                        FirstTopIndex = i;
                    }
                    if (FirstPeakReached && FirstCrestReached && !SecondPeakReached)
                    {
                        SecondPeakReached = true;
                        SecondTopIndex = i;
                    }
                }
                if ((double)TempYList[i] <= (double)BottomThreshold)
                {
                    //Console.WriteLine("Current <= TMin");
                    if (FirstPeakReached && !FirstCrestReached)
                    {
                        FirstCrestReached = true;
                        FirstBottomIndex = i;
                    }
                }
            }
            if (FirstPeakReached && FirstCrestReached && SecondPeakReached)
            {
                //Console.WriteLine("works!"); 
                return (double)1 / ((double)TempXList[SecondTopIndex] - (double)TempXList[FirstTopIndex]);
            }
            else
            {
                //Console.WriteLine("not working"); 
                return 0;
            }
        }

        List<string[]> FileAndFrequency = new List<string[]>();
        public List<string[]> GetFileAndFrequencyList = new List<string[]>();
        public void SetFileAndFrequencyList(List<string[]> NewFileAndFrequencyList)
        {
            FileAndFrequency = NewFileAndFrequencyList;
        }
        public void AddFileAndFrequencyItem(string FileName, double Frequency)
        {
            string[] ItemArray = new string[2]; ItemArray[0] = FileName; ItemArray[1] = Frequency.ToString();
            FileAndFrequency.Add(ItemArray);
        }
        public void ClearFileAndFrequencyItems()
        {
            FileAndFrequency.Clear();
        }

        public List<string> SortByFrequency(List<string> InputFileAndFrequencyList)
        {
            if (InputFileAndFrequencyList == null) {return new List<string>{};} // return empty list if nothing is present
            List<string> TempFileAndFrequencyList = InputFileAndFrequencyList;
            List<string> SortedFileAndFrequencyList = new List<string>();
            List<double> TempFrequencies = new List<double>();
            foreach (string ListItem in InputFileAndFrequencyList)
            {
                TempFrequencies.Add(Convert.ToDouble(ListItem.Split(',')[1]));
            }
            while (TempFileAndFrequencyList.Count() > 0 && TempFrequencies.Count() > 0)
            {
                string[] NewSortedItem = new string[2]; int i = TempFrequencies.IndexOf(TempFrequencies.Max()); // index of maximum frequency
                NewSortedItem[0] = TempFileAndFrequencyList[i].Split(',')[0]; // add file name
                NewSortedItem[1] = TempFileAndFrequencyList[i].Split(',')[1]; // add frequency
                TempFileAndFrequencyList.RemoveAt(i); TempFrequencies.RemoveAt(i);
                SortedFileAndFrequencyList.Add(NewSortedItem[0] + "," + NewSortedItem[1]);
            }
            return SortedFileAndFrequencyList;
        }

        public List<string> GetSingleColumnList(List<string[]> MultiColumnList, int ColumnIndex = 0)
        {
            List<string> TempList = new List<string>();
            foreach (string[] ListItem in MultiColumnList)
            {
                TempList.Add(ListItem[ColumnIndex]);
            }
            return TempList;
        }
    }
}
