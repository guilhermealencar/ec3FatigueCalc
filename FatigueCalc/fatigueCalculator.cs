using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FatigueCalc
{
    public partial class fatigueCalculator : Form
    {
        public StringBuilder htmlFile = new StringBuilder();
        public StringBuilder htmlFileImage = new StringBuilder();
        public StringBuilder htmlFileClose = new StringBuilder();

        public string fileImagePath;
        public string mSlope = "3";
        List<string> FilterExtensions = new List<string>();
        public string positiveNbRegExpress = @"^[+]?(\d+(\.?\d+)?|\.\d+)$";

        public double maxStress;
        public double maxFinalAmplitude;

        public List<double> rationiNi_Global;
        public List<double> peaksAndValleysList = new List<double>();
        List<double> fixedSignalList = new List<double>();

        public bool shearStressCheckboxStatus;
        public bool charactersError;
        public DataTable rainflowResultDataTable = new DataTable();

        public fatigueCalculator()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            InitializeComponent();
            
            this.lbDecimalPlaces.SelectedIndex = 4;
            this.lbEcCategory.SelectedIndex = 0;

            string path = System.IO.Directory.GetCurrentDirectory() + "\\";
            this.fileImagePath = path + "StrDetails\\01\\1-160.png";
            this.lbPictureDetail.Text = fileImagePath;

            StringBuilder saveAsFilter = new StringBuilder();
            if (this.getOfficeVersion("Word") == 0)
            {
                saveAsFilter.Append("Word 97-2003 Document|*.doc|");
            }
            else if (this.getOfficeVersion("Word") == 1)
            {
                saveAsFilter.Append("Word Document (*.docx)|*.docx|Word 97-2003 Document (*.doc)|*.doc|Portable Document Format (*.pdf)|*.pdf|");
            }

            saveAsFilter.Append("Single File Web Page (*.html)|*.html");

            string saveAsFilterString = saveAsFilter.ToString();
            string[] saveAsFilterSplitted;
            saveAsFilterSplitted = saveAsFilterString.Split('|');
            int i = 1;
            while (i < saveAsFilterSplitted.Length)
            {
                FilterExtensions.Add(saveAsFilterSplitted[i]);
                i = i + 2;
            }

            sfFatigueResults.Filter = saveAsFilter.ToString();
            sfFatigueResults.Title = "Save Fatigue Calculation Results";

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void setPeaksAndValleys(string Signal) {
            List<double> signalValues = new List<double>();
            List<double> peaksAndValleys = new List<double>();
            using (StringReader reader = new StringReader(Signal))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        signalValues.Add(double.Parse(line, CultureInfo.InvariantCulture));
                    }
                } while (line != null);
            }
            peaksAndValleys.Add(signalValues[0]);
            int i = 1;
            for (i = 1; i < signalValues.Count-1; i++)
            {
                if(signalValues[i]>signalValues[i-1] && signalValues[i]>signalValues[i+1])
                {
                    peaksAndValleys.Add(signalValues[i]);
                }
                else if (signalValues[i] < signalValues[i-1] && signalValues[i] < signalValues[i+1])
                {
                    peaksAndValleys.Add(signalValues[i]);
                } 
            }

            peaksAndValleys.Add(signalValues[signalValues.Count - 1]);

            this.peaksAndValleysList = peaksAndValleys;

        }

        public double getFatigueLifeN(double deltaSigmaR)
        {
            double fatigueLifeN = 0;
            double KS = double.Parse(this.lbKS.Text);
            double gamaMf = double.Parse(this.lbGamaMf.Text);
            double deltaSigmaC = double.Parse(this.lbEcCategory.Text) * KS / gamaMf;
            double deltaTauL = .457 * deltaSigmaC;
            double deltaSigmaD = .737 * deltaSigmaC;
            double deltaSigmaL = .549 * deltaSigmaD;
            if (this.shearStressCheckboxStatus)
            {
                if (deltaSigmaC == 90)
                {
                    fatigueLifeN = Math.Pow(10, Math.Log10(Math.Pow(deltaSigmaC, 8) * 2e6) - 8 * Math.Log10(deltaSigmaR));
                }
                else if (deltaSigmaR > deltaTauL)
                {
                    fatigueLifeN = Math.Pow(10, Math.Log10(Math.Pow(deltaSigmaC, 5) * 2e6) - 5 * Math.Log10(deltaSigmaR));
                }
            }
            else
            {

                if (deltaSigmaR > deltaSigmaD)
                {
                    fatigueLifeN = Math.Pow(deltaSigmaC / deltaSigmaR, 3) * 2e6;
                }
                else if (deltaSigmaR > deltaSigmaL)
                {
                    fatigueLifeN = Math.Pow(deltaSigmaD / deltaSigmaR, 5) * 5e6;
                }
            }

            return fatigueLifeN;
        }

        public int getOfficeVersion(string WordOuExcel)
        {
            string strEVersionSubKey = "";
            if(WordOuExcel=="Word") {
                strEVersionSubKey = "\\Word.Application\\CurVer"; //HKEY_CLASSES_ROOT/Excel.Application/Curver
            }
            else if (WordOuExcel == "Excel")
            {
                strEVersionSubKey = "\\Excel.Application\\CurVer"; //HKEY_CLASSES_ROOT/Excel.Application/Curver
            }
            
            string strValue = null; //Value Present In Above Key
            int strVersion = -1; //Determines Excel Version

            RegistryKey rkVersion = null; //Registry Key To Determine Excel Version

            rkVersion = Registry.ClassesRoot.OpenSubKey(strEVersionSubKey, false); //Open Registry Key

            if ((rkVersion != null)) //If Key Exists
            {
                strValue = (string)rkVersion.GetValue(string.Empty); //Get Value

                strValue = strValue.Substring(strValue.LastIndexOf(".") + 1); //Store Value

                if(Int32.Parse(strValue) <= 11) {
                    strVersion = 0;
                } else if (Int32.Parse(strValue) <= 16)
                {
                    strVersion = 1;
                }
            }
            return strVersion;
        }

        private void btPasteIn_Click(object sender, EventArgs e)
        {
            this.PasteInData(dgStressHistory, true);
        }

        // PasteInData pastes clipboard data into the grid passed to it.
        public void PasteInData(DataGridView dgv, bool status)
        {
           

            char[] rowSplitter = { '\n', '\r' };  // Cr and Lf.
            char columnSplitter = '\t';         // Tab.

            IDataObject dataInClipboard = Clipboard.GetDataObject();

              string stringInClipboard;
            if (System.Windows.Forms.Clipboard.ContainsText())
            {
                stringInClipboard = dataInClipboard.GetData(DataFormats.Text).ToString();
            } else {
                stringInClipboard = "";
            }         
            
            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter,
                StringSplitOptions.RemoveEmptyEntries);

            int r = 0;
            int c = 0;
            if (!status)
            {
                r = dgv.SelectedCells[0].RowIndex;
                c = dgv.SelectedCells[0].ColumnIndex;
            }

            if (dgv.Rows.Count < (r + rowsInClipboard.Length))
                dgv.Rows.Add(r + rowsInClipboard.Length + 1 - dgv.Rows.Count);

            // Loop through lines:

            int iRow = 0;
            while (iRow < rowsInClipboard.Length)
            {
                // Split up rows to get individual cells:

                string[] valuesInRow =
                    rowsInClipboard[iRow].Split(columnSplitter);

                // Cycle through cells.
                // Assign cell value only if within columns of grid:

                int jCol = 0;
                while (jCol < valuesInRow.Length)
                {
                    if ((dgv.ColumnCount - 1) >= (c + jCol))
                        dgv.Rows[r + iRow].Cells[c + jCol].Value =
                        valuesInRow[jCol];

                    jCol += 1;
                } // end while

                iRow += 1;
            } // end while
        }

        private void dgStressHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                this.PasteInData(dgStressHistory, false);
            }
            base.OnKeyDown(e);
        }

        private void dgStressHistory_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                this.PasteInData(dgStressHistory, false);
            }
            base.OnKeyDown(e);
        }

        private void btErase_Click(object sender, EventArgs e)
        {
            this.dgStressHistory.DataSource = null;
            this.dgStressHistory.Rows.Clear();
            this.btCalculate.Enabled = false;
        }

        public DataTable ConvertListToDataTable(List<double> list)
        {
            // New table.
            DataTable table = new DataTable();

            
            table.Columns.Add();

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

        private void rbNormalStress_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.restoreEcCategories();
            this.lbKS.Enabled = true;
        }
        private void rbShearStress_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.restoreEcCategories();
            this.lbKS.Text = "1.0";
            this.lbEcCategory.SelectedIndex = 0;
            this.lbKS.Enabled = false;
        }
        private void restoreEcCategories()
        {
            if (this.rbNormalStress.Checked)
            {
                if(this.shearStressCheckboxStatus) {
                    this.lbEcCategory.Items.Clear();
                    this.lbEcCategory.Items.AddRange(new string[] { "160", "140", "125", "112", "100", "90",
                "80", "71", "63", "56", "50", "45", "40", "36" });
                    this.shearStressCheckboxStatus = false;
                    this.lbEcCategory.SelectedIndex = 0;
                }
            }
            else if (this.rbShearStress.Checked)
            {
                this.shearStressCheckboxStatus = true;
                this.lbEcCategory.Items.Clear();
                this.lbEcCategory.Items.AddRange(new string[] { "100", "90", "80" });
                this.lbKS.Enabled = false;
                this.lbKS.Text = "1.0";
            }
        }

        private void btCalculate_Click(object sender, EventArgs e)
        {
            this.charactersError = false;
            List<double> cyclesCondensed = new List<double>();
            List<double> stressCondensed = new List<double>();

            int i;
            
            if (this.dgRainflowSummary.ReadOnly)
            {
                StringBuilder Signal = new StringBuilder();
                List<double> maxMinSignalList = new List<double>();
                
                for (int linha = 0; linha < dgStressHistory.Rows.Count - 1; linha++)
                {
                    maxMinSignalList.Add(double.Parse(dgStressHistory.Rows[linha].Cells[0].Value.ToString()));
                    Signal.Append(dgStressHistory.Rows[linha].Cells[0].Value.ToString() + Environment.NewLine);
                }
                
                double max = maxMinSignalList.Max();
                double min = maxMinSignalList.Min();

                if(Math.Abs(max) > Math.Abs(min)) {
                    this.maxStress = Math.Round(Math.Abs(max));
                } else {
                    this.maxStress = Math.Round(Math.Abs(min));
                }

                this.lbTensaoMaxima.Text = "Max Stress = " + maxStress + " MPa";

                if (!charactersError)
                {
                    string fixedSignal = fixSignalRepeatedNumbers(Signal.ToString());
                    DataTable fixedSignalTable = this.ConvertListToDataTable(fixedSignalList);
                    this.setPeaksAndValleys(fixedSignal.ToString());
                    DataTable table = this.ConvertListToDataTable(peaksAndValleysList);
                    this.dgPeaksValleys.DataSource = table;

                    this.Rainflow(peaksAndValleysList);
                    this.dgRainflowResults.DataSource = this.rainflowResultDataTable; 

                    List<double> stressesList = new List<double>();
                    List<double> cyclesList = new List<double>();
                    double decimalPlaces = double.Parse(this.lbDecimalPlaces.Text, CultureInfo.InvariantCulture);
                    double nDecimalPlaces = Math.Pow(10, decimalPlaces);

                    for (i = 0; i < this.rainflowResultDataTable.Rows.Count; i++)
                    {
                        if (double.Parse(this.rainflowResultDataTable.Rows[i][0].ToString(), CultureInfo.InvariantCulture) < 1)
                        {
                            stressesList.Add(Math.Ceiling(double.Parse(this.rainflowResultDataTable.Rows[i][0].ToString(), CultureInfo.InvariantCulture) * nDecimalPlaces) / nDecimalPlaces);
                        } else
                        {
                            stressesList.Add(Math.Round(double.Parse(this.rainflowResultDataTable.Rows[i][0].ToString(), CultureInfo.InvariantCulture) * nDecimalPlaces) / nDecimalPlaces);
                        }
                        cyclesList.Add(double.Parse(this.rainflowResultDataTable.Rows[i][1].ToString(), CultureInfo.InvariantCulture));
                    }

                    i = 0;
                    int j = 0;
                    double sumCycles;
                    double[] alreadyCounted = new double[stressesList.Count];
                    int k = 0;

                    DataTable rainflowTableSummary = new DataTable();
                    rainflowTableSummary.Columns.Add();
                    rainflowTableSummary.Columns.Add();

                    for (i = 0; i < stressesList.Count; i++)
                    {
                        if (!alreadyCounted.Contains(stressesList[i]))
                        {
                            sumCycles = cyclesList[i];
                            for (j = 0; j < stressesList.Count; j++)
                            {
                                if (stressesList[j] == stressesList[i] && i != j)
                                {
                                    sumCycles = sumCycles + cyclesList[j];
                                }
                            }
                            cyclesCondensed.Add(sumCycles);
                            stressCondensed.Add(stressesList[i]);
                            DataRow row;
                            row = rainflowTableSummary.NewRow();
                            row[0] = stressesList[i];
                            row[1] = sumCycles;
                            rainflowTableSummary.Rows.Add(row);
                            alreadyCounted[k] = stressesList[i];
                            k++;
                        }
                    }

                    DataTable rainflowTableSummaryClone = rainflowTableSummary.Clone();
                    rainflowTableSummaryClone.Columns["Column1"].DataType = Type.GetType("System.Double");
                    
                    foreach (DataRow dr in rainflowTableSummary.Rows)
                    {
                        rainflowTableSummaryClone.ImportRow(dr);
                    }
                    rainflowTableSummaryClone.AcceptChanges();
                    DataView dv = rainflowTableSummaryClone.DefaultView;
                    dv.Sort = "Column1 DESC";

                    this.maxFinalAmplitude = stressCondensed.Max();

                    this.dgRainflowSummary.DataSource = dv.ToTable();
                }

                }
                else
                {
                    for (int line = 0; line < dgRainflowSummary.Rows.Count - 1; line++)
                    {
                        if (!Regex.IsMatch(dgRainflowSummary.Rows[line].Cells[0].Value.ToString(), positiveNbRegExpress))
                        {
                            this.charactersError = true;
                            break;
                        }
                        else if (!Regex.IsMatch(dgRainflowSummary.Rows[line].Cells[1].Value.ToString(), positiveNbRegExpress))
                        {
                            this.charactersError = true;
                            break;
                        }
                        else
                        {
                            stressCondensed.Add(double.Parse(dgRainflowSummary.Rows[line].Cells[0].Value.ToString(), CultureInfo.InvariantCulture));
                            cyclesCondensed.Add(double.Parse(dgRainflowSummary.Rows[line].Cells[1].Value.ToString(), CultureInfo.InvariantCulture));
                        }


                    }

                    i = 0;
                    int j = 0;
                    double sumCycles;
                    double[] alreadyCounted = new double[stressCondensed.Count];
                    int k = 0;

                    DataTable rainflowTableSummary = new DataTable();
                    rainflowTableSummary.Columns.Add();
                    rainflowTableSummary.Columns.Add();

                    for (i = 0; i < stressCondensed.Count; i++)
                    {
                        if (!alreadyCounted.Contains(stressCondensed[i]))
                        {
                            sumCycles = cyclesCondensed[i];
                            for (j = 0; j < stressCondensed.Count; j++)
                            {
                                if (stressCondensed[j] == stressCondensed[i] && i != j)
                                {
                                    sumCycles = sumCycles + cyclesCondensed[j];
                                }
                            }
                            DataRow row;
                            row = rainflowTableSummary.NewRow();
                            row[0] = stressCondensed[i];
                            row[1] = sumCycles;
                            rainflowTableSummary.Rows.Add(row);
                            alreadyCounted[k] = stressCondensed[i];
                            k++;
                        }
                    }
                    this.maxFinalAmplitude = stressCondensed.Max();
                    this.dgRainflowSummary.DataSource = rainflowTableSummary;

                }

            if (!this.charactersError)
            {
                i = 0;
                double tempRatio;
                i = 0;

                List<double> rationiNi = new List<double>();
                List<double> fatigueLifeN = new List<double>();
                for (i = 0; i < cyclesCondensed.Count; i++)
                {
                    fatigueLifeN.Add(this.getFatigueLifeN(stressCondensed[i]));
                    if (fatigueLifeN[i] == 0)
                    {
                        tempRatio = 0;
                    }
                    else
                    {
                        tempRatio = cyclesCondensed[i] / fatigueLifeN[i];
                    }
                    rationiNi.Add(tempRatio);
                }

                double[] cyclesCondensedArray = cyclesCondensed.ToArray();
                double[] stressCondensedArray = stressCondensed.ToArray();
                double[] rationiNiArray = rationiNi.ToArray();
                double[] fatigueLifeNArray = fatigueLifeN.ToArray();

                Array.Sort(stressCondensedArray.ToArray(), cyclesCondensedArray);
                Array.Sort(stressCondensedArray.ToArray(), rationiNiArray);
                Array.Sort(stressCondensedArray.ToArray(), fatigueLifeNArray);
                Array.Sort(stressCondensedArray);

                cyclesCondensed.Clear();
                stressCondensed.Clear();
                rationiNi.Clear();
                fatigueLifeN.Clear();

                stressCondensed = new List<double>(stressCondensedArray);
                cyclesCondensed = new List<double>(cyclesCondensedArray);
                rationiNi = new List<double>(rationiNiArray);
                fatigueLifeN = new List<double>(fatigueLifeNArray);

                double damage = Math.Round(rationiNi.Sum() * 1e15) / 1e15;

                this.htmlFile.Clear();
                this.htmlFileImage.Clear();
                this.htmlFileClose.Clear();
                this.htmlFile.Append(@"<!doctype html>
                                      <html lang=""en"">
                                      <head>
                                      <title>Fatigue Damage Calculation: " + this.lbDescription.Text + @"</title>
                                      <meta charset=""utf-8"">
                                      <style type=""text/css"">
                                      body {
                                          font-family:Arial;
                                          font-size:13px;
                                      }
                                      table, th, td {   
                                          text-align: center;
                                          padding:1; margin:1;  
                                          border: 1px solid black;
										  font-size:13px;
                                      }
                                      table {
                                          border-collapse:collapse;
                                      }
                                      th {
                                          background-color: #E0E0E0;
                                      }
                                      </style>
                                      </head>
                                      <body>
                                        <h3>Fatigue Damage Calculation</h3>
                                      <p>" + this.lbDescription.Text + @"</p><center>
                                        <table>
                                         <tr>
                                          <th rowspan=""2"">&#916;&#963; (MPa)</th>
                                          <th rowspan=""2"">Cycles Number</th>
                                          <th rowspan=""2"">m</th>
                                          <th colspan=""2"">EN 1993-1-9 - " + this.lbEcCategory.Text + @"</th>
                                        </tr>
                                        <tr>
                                           <th>N<sub>i</sub></th>
                                           <th>n<sub>i</sub>/N<sub>i</sub></th>
                                         </tr>");
                i = 0;
                double ni;
                double sumCycles = cyclesCondensed.Sum();
                tempRatio = 0;

                double KS = double.Parse(this.lbKS.Text);
                double gamaMf = double.Parse(this.lbGamaMf.Text);
                double deltaSigmaC = double.Parse(this.lbEcCategory.Text) * KS / gamaMf;
                double deltaTauL = .457 * deltaSigmaC;
                double deltaSigmaD = .737 * deltaSigmaC;
                double deltaSigmaL = .549 * deltaSigmaD;

                for (i = stressCondensed.Count - 1; i > -1; i--)
                {
                    ni = Math.Round(cyclesCondensed[i]);
                    this.htmlFile.Append(@"<tr>");
                    
                    if (stressCondensed[i] > deltaSigmaD) {
                        this.mSlope = "3";
                    }
                    else if (stressCondensed[i] > deltaSigmaL)
                    {
                        this.mSlope = "5";
                    }
                    else
                    {
                        this.mSlope = "-";
                    }

                    this.htmlFile.Append(@"<td>" + stressCondensed[i] + @"</td> 
                                          <td>" + cyclesCondensed[i] + @"</td>
                                          <td>" + this.mSlope + @"</td>");

                    tempRatio = Math.Round(rationiNi[i] * 1e15) / 1e15;

                    if (fatigueLifeN[i] == 0)
                    {
                        this.htmlFile.Append(@"<td>-</td>");
                        this.htmlFile.Append(@"<td>-</td>");
                    }
                    else
                    {
                        this.htmlFile.Append(@"<td>" + Math.Round(fatigueLifeN[i]) + "</td>");
                        this.htmlFile.Append(@"<td>" + tempRatio.ToString("F15") + "</td>");
                    }
                    this.htmlFile.Append(@"</tr>");

                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                }
                this.htmlFile.Append(@"<tr>
                                           <td>&#916;&#963;m&aacute;x = " + Math.Round(stressCondensed.Max() * 100) / 100 + @" MPa</td>
                                           <td><b>&#931; " + sumCycles + @"</b></td>
                                               <td></td> 
                                            <td><b>D=</b></td>
                                           <td>" + damage.ToString("F15") + @"</td>
                                          </tr>
                                        </table>");
                if (File.Exists(this.lbPictureDetail.Text))
                {
                    this.htmlFileImage.Append(@"<p><img src=""" + this.lbPictureDetail.Text + @"""></p>");
                }
                this.htmlFileClose.Append(@"</center>
                                      </body>
                                      </html>");

                this.resultsWindow.DocumentText = htmlFile.ToString()+htmlFileImage.ToString()+htmlFileClose.ToString();

                this.btSaveAs.Enabled = true;
                this.containerWeb.Enabled = true;
                this.resultsWindow.Visible = true;

                this.rationiNi_Global = rationiNi;
                
            }

            if (this.charactersError)
            {
                MessageBox.Show("Caracteres inválidos na introdução dos dados. São aceitos somente números (positivos ou negativos para o histórico de tensões, e somente positivo para introdução direta de amplitudes e cilcos). Deve-se utilizar também a vírgula como separador decimal.");
            }


        }

        private void cbEnterStressRanges_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dgRainflowSummary.ReadOnly)
            {
                this.dgRainflowSummary.ReadOnly = false;
                this.dgRainflowSummary.AllowUserToAddRows = true;
                this.dgRainflowSummary.AllowUserToDeleteRows = true;
                this.dgStressHistory.Enabled = false;
                this.dgPeaksValleys.Enabled = false;
                this.dgRainflowResults.Enabled = false;
                this.btPasteIn.Enabled = false;
                this.btErase.Enabled = false;
                this.lbDecimalPlaces.Enabled = false;
            }
            else
            {
                if (this.dgStressHistory.Rows.Count == 1)
                {
                    this.btCalculate.Enabled = false;
                }
                else
                {
                    this.btCalculate.Enabled = true;
                }
                this.dgRainflowSummary.ReadOnly = true;
                this.dgRainflowSummary.AllowUserToAddRows = false;
                this.dgRainflowSummary.AllowUserToDeleteRows = false;
                this.dgStressHistory.Enabled = true;
                this.dgPeaksValleys.Enabled = true;
                this.dgRainflowResults.Enabled = true;
                this.btPasteIn.Enabled = true;
                this.btErase.Enabled = true;
                this.lbDecimalPlaces.Enabled = true;
            }
            
        }

        private void btChoosePicture_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\";
            openPictureDialog.Title = "Load picture detail";
            openPictureDialog.InitialDirectory = path + "StrDetails";
            openPictureDialog.Filter = "All images file type|*.png;*.jpg;*.jpeg;*.gif|PNG Image|*.png|JPeg Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|Gif Image|*.gif|All files|*.*";
            this.openPictureDialog.ShowDialog();
            fileImagePath = openPictureDialog.FileName;
            if (fileImagePath != "")
            {
                this.lbPictureDetail.Text = fileImagePath;
            }
        }

        
        private void dgStressHistory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this.dgStressHistory.Rows.Count != 1)
            {
                this.btCalculate.Enabled = true;
            }
        }

        private void dgStressHistory_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (this.dgStressHistory.Rows.Count == 1)
            {
                this.btCalculate.Enabled = false;
            }
        }

        private void dgRainflowSummary_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (cbEnterStressRanges.Checked && this.dgRainflowSummary.Rows.Count != 1)
            {
                this.btCalculate.Enabled = true;
            }
        }

        private void dgRainflowSummary_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (cbEnterStressRanges.Checked && this.dgRainflowSummary.Rows.Count == 1)
            {
                this.btCalculate.Enabled = false;
            }
        }


        private string fixSignalRepeatedNumbers(string Signal)
        {
            fixedSignalList.Clear();
            
            List<double> signalValues = new List<double>();

            using (StringReader reader = new StringReader(Signal))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        signalValues.Add(double.Parse(line, CultureInfo.InvariantCulture));
                    }
                } while (line != null);
            }

            List<int> repeatedNumbersIndex = new List<int>();

            int i = 1;
            for (i = 1; i < signalValues.Count; i++)
            {
                if (signalValues[i] == signalValues[i - 1])
                {
                    repeatedNumbersIndex.Add(i);
                }
            }

            bool isEqual;
            int j;
            i = 0;
            for (i = 0; i < signalValues.Count; i++)
            {
                isEqual = false;
                j = 0;
                for (j = 0; j < repeatedNumbersIndex.Count; j++)
                {
                    if (i == repeatedNumbersIndex[j])
                    {
                        isEqual = true;
                    }
                }
                if (!isEqual)
                {
                    fixedSignalList.Add(signalValues[i]);
                }
            }


            StringBuilder fixedSignal = new StringBuilder(); ;
            i = 0;
            for (i = 0; i < fixedSignalList.Count; i++)
            {
                fixedSignal.Append(fixedSignalList[i].ToString("r", CultureInfo.InvariantCulture) + Environment.NewLine);
            }

            return fixedSignal.ToString();
        }

        private void dgRainflowSummary_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbEnterStressRanges.Checked)
            {
                if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
                {
                    this.PasteInData(dgRainflowSummary, false);
                }
                base.OnKeyDown(e);
            }
        }

        private void dgRainflowSummary_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbEnterStressRanges.Checked)
            {
                if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
                {
                    this.PasteInData(dgRainflowSummary, false);
                }
                base.OnKeyDown(e);
            }
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            aboutWindow aboutWindowInstance = new aboutWindow();
            aboutWindowInstance.ShowDialog();
        }
        
        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public void Rainflow(List<double> y)
        {
            /*
            Translated and Adapted from C++ to C# from Vibration Data Blog (Tom Irwine)
            rainflow.cpp ver 2.8  June 24, 2014
            ASTM E 1049-85 (2005) Rainflow Counting Method
            */

            double ylast;
            double sum;
            double ymax;
            double mina, maxa;
            double X, Y;
            double slope1;
            double slope2;
            long kv;
            long NP;
            long last_a;
            int i, j, k;

            List<double> a = new List<double>();

            this.rainflowResultDataTable.Clear();

            if(this.rainflowResultDataTable.Columns.Count < 2)
            {
                this.rainflowResultDataTable.Columns.Add();
                this.rainflowResultDataTable.Columns.Add();
            }            

            ylast = y[y.Count - 1];
            NP = y.Count+1;
            ymax = 0;
            a.Add(y[0]);
            k = 1;

            for (i = 1; i < (NP - 1); i++)
            {
                slope1 = y[i] - y[i - 1];
                try {
                    slope2 = y[i + 1] - y[i];
                } catch
                {
                    slope2 = -y[i];
                }
                
                if (slope1 * slope2 <= 0 && Math.Abs(slope1) > 0)
                {
                    a.Add(y[i]);
                    k++;
                }
            }

            a.Add(ylast);
            k++;

            last_a = k - 1;

            mina = 100000;
            maxa = -mina;

            for (i = 0; i <= last_a; i++)
            {
                if (a[i] < mina)
                {
                    mina = a[i];
                }
                if (a[i] > maxa)
                {
                    maxa = a[i];
                }
            }

            i = 0;
            j = 1;

            sum = 0;
            kv = 0;

            while (true)
            {
                Y = (Math.Abs(a[i] - a[i + 1]));
                X = (Math.Abs(a[j] - a[j + 1]));

                if (X >= Y && Y > 0 && Y < 1.0e+20)
                {
                    if (Y > ymax)
                    {
                        ymax = Y;
                    }

                    if (i == 0)
                    {
                        sum += 0.5;

                        DataRow currentRow;
                        currentRow = this.rainflowResultDataTable.NewRow();
                        currentRow[0] = Y; // amplitude
                        currentRow[1] = 0.5; // cycler number
                        this.rainflowResultDataTable.Rows.Add(currentRow);

                        kv++;

                        a.RemoveAt(0);

                        last_a--;

                        i = 0;
                        j = 1;
                    }
                    else
                    {
                        sum += 1;

                        DataRow currentRow;
                        currentRow = this.rainflowResultDataTable.NewRow();
                        currentRow[0] = Y; // amplitude
                        currentRow[1] = 1; // cycler number
                        this.rainflowResultDataTable.Rows.Add(currentRow);

                        kv++;

                        a.RemoveAt(i + 1);
                        a.RemoveAt(i);

                        last_a -= 2;

                        i = 0;
                        j = 1;
                    }
                }
                else
                {
                    i++;
                    j++;
                }

                if ((j + 1) > last_a)
                {
                    break;
                }
            }

            for (i = 0; i < (last_a); i++)
            {
                Y = (Math.Abs(a[i] - a[i + 1]));
                if (Y > 0 && Y < 1.0e+20)
                {
                    sum += 0.5;

                    DataRow currentRow;
                    currentRow = this.rainflowResultDataTable.NewRow();
                    currentRow[0] = Y; // amplitude
                    currentRow[1] = 0.5; // cycler number
                    this.rainflowResultDataTable.Rows.Add(currentRow);

                    kv++;

                    if (Y > ymax)
                    {
                        ymax = Y;
                    }

                }
            }

        }

        private void btSaveAs_Click(object sender, EventArgs e)
        {
            sfFatigueResults.FileName = this.lbDescription.Text;
            if (sfFatigueResults.ShowDialog() == DialogResult.OK)
            {
                string path = System.IO.Directory.GetCurrentDirectory() + "\\";
                string selectedExtension = FilterExtensions[sfFatigueResults.FilterIndex - 1];
                switch (selectedExtension)
                {
                    case "*.docx":
                        File.WriteAllText("./fatigueResults.html", htmlFile.ToString() + htmlFileClose.ToString());
                        var wordx = new Microsoft.Office.Interop.Word.Application();
                        wordx.Visible = false;
                        var wordDocx = wordx.Documents.Open(FileName: path + "fatigueResults.html", ReadOnly: false);
                        Microsoft.Office.Interop.Word.Range rng = wordDocx.Range();
                        object lastPosition = rng.StoryLength - 1;
                        rng = wordDocx.Range(ref lastPosition, ref lastPosition);
                        rng.Select();
                        wordDocx.Paragraphs.Add();
                        lastPosition = rng.StoryLength - 1;
                        rng = wordDocx.Range(ref lastPosition, ref lastPosition);
                        rng.Select();
                        rng.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        if (File.Exists(this.lbPictureDetail.Text))
                        {
                            var image = wordDocx.InlineShapes.AddPicture(this.lbPictureDetail.Text, false, true, rng);
                            Image figuraDetalhe = Image.FromFile(this.lbPictureDetail.Text);
                            image.Width = figuraDetalhe.Width * 72 / 96;
                            image.Height = figuraDetalhe.Height * 72 / 96;
                        }
                        wordDocx.SaveAs2(FileName: sfFatigueResults.FileName, FileFormat: Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXMLDocument);
                        wordDocx.Close(false);
                        wordx.Quit(false);
                        File.Delete("./fatigueResults.html");
                        break;
                    case "*.doc":
                        File.WriteAllText("./fatigueResults.html", htmlFile.ToString() + htmlFileClose.ToString());
                        var word = new Microsoft.Office.Interop.Word.Application();
                        word.Visible = false;
                        var wordDoc = word.Documents.Open(FileName: path + "fatigueResults.html", ReadOnly: false);
                        Microsoft.Office.Interop.Word.Range range = wordDoc.Range();
                        object endPosistion = range.StoryLength - 1;
                        rng = wordDoc.Range(ref endPosistion, ref endPosistion);
                        rng.Select();
                        wordDoc.Paragraphs.Add();
                        endPosistion = rng.StoryLength - 1;
                        rng = wordDoc.Range(ref endPosistion, ref endPosistion);
                        rng.Select();
                        rng.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        if (File.Exists(this.lbPictureDetail.Text))
                        {
                            var image = wordDoc.InlineShapes.AddPicture(this.lbPictureDetail.Text, false, true, rng);
                            Image figuraDetalhe = Image.FromFile(this.lbPictureDetail.Text);
                            image.Width = figuraDetalhe.Width * 72 / 96;
                            image.Height = figuraDetalhe.Height * 72 / 96;
                        }
                        wordDoc.SaveAs2(FileName: sfFatigueResults.FileName, FileFormat: Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument);
                        wordDoc.Close(false);
                        word.Quit(false);
                        File.Delete("./fatigueResults.html");
                        break;
                    case "*.html": // OK
                        //converte imagem arquivo PNG para base64 para HTML arquivo unico
                        try { 
                            Image pictureDetail = Image.FromFile(this.lbPictureDetail.Text);

                            string figuraDetalheBase64 = "";

                            if (System.Drawing.Imaging.ImageFormat.Jpeg.Equals(pictureDetail.RawFormat))
                            {
                                figuraDetalheBase64 = @"data:image/jpg;base64," + ImageToBase64(pictureDetail, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                            else if (System.Drawing.Imaging.ImageFormat.Png.Equals(pictureDetail.RawFormat))
                            {
                                figuraDetalheBase64 = @"data:image/png;base64," + ImageToBase64(pictureDetail, System.Drawing.Imaging.ImageFormat.Png);
                            }
                            else if (System.Drawing.Imaging.ImageFormat.Gif.Equals(pictureDetail.RawFormat))
                            {
                                figuraDetalheBase64 = @"data:image/gif;base64," + ImageToBase64(pictureDetail, System.Drawing.Imaging.ImageFormat.Gif);
                            }
                            else if (System.Drawing.Imaging.ImageFormat.Bmp.Equals(pictureDetail.RawFormat))
                            {
                                figuraDetalheBase64 = @"data:image/bmp;base64," + ImageToBase64(pictureDetail, System.Drawing.Imaging.ImageFormat.Bmp);
                            }

                            this.htmlFileImage.Replace(this.lbPictureDetail.Text, figuraDetalheBase64);
                        } catch {
                            // do nothing
                        }
                        File.WriteAllText("./fatigueResults.html", htmlFile.ToString()+htmlFileImage.ToString()+htmlFileClose.ToString());
                        File.Copy("./fatigueResults.html", sfFatigueResults.FileName, true);
                        File.Delete("./fatigueResults.html");
                        break;
                    case "*.pdf":
                        File.WriteAllText("./fatigueResults.html", htmlFile.ToString() + htmlFileImage.ToString() + htmlFileClose.ToString());
                        var wordPdf = new Microsoft.Office.Interop.Word.Application();
                        wordPdf.Visible = false;
                        var wordDocPdf = wordPdf.Documents.Open(FileName: path + "fatigueResults.html", ReadOnly: false);
                        wordDocPdf.SaveAs2(FileName: sfFatigueResults.FileName, FileFormat: Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                        wordDocPdf.Close(false);
                        wordPdf.Quit(false);
                        File.Delete("./fatigueResults.html");
                        break;
                }
                File.Delete("./fatigueResults.html");

            }
        }
    }
}
