 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace THO7AlgorithmTimerApplication
{
    public partial class MainForm : Form
    {
        List<VisionAlgorithm> NoiseList = new List<VisionAlgorithm>();
        List<VisionAlgorithm> MedianList = new List<VisionAlgorithm>();
        Stopwatch stopWatch;


        Bitmap InputImage;
        Bitmap NoisedImage;
        public MainForm()
        {
            InitializeComponent();

            NoiseList.Add(new SaltPepper("Add 5% salt&pepper noise", 5));
            NoiseList.Add(new SaltPepper("Add 40% salt&pepper noise", 40));

            MedianList.Add(new EmptyAlgorithm("None"));
            MedianList.Add(new MedianFilterAlgorithmV2("Median Filter 3x3", 3));
            MedianList.Add(new MedianFilterAlgorithmV2("Median Filter 11x11", 11));
            
            //Insert new Algorithms here
            /*          ^
            *          /|\
            *           |
            */

            foreach (VisionAlgorithm vA in NoiseList)
            {
                AlgoListBox.Items.Add(vA.Name);
            }

            foreach (VisionAlgorithm vA in MedianList)
            {
                listBox1.Items.Add(vA.Name);
            }
        }

        private void openPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage();
        }
        private void openImage()
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            oFD.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG;)|*.BMP;*.JPG;*.JPEG;*.PNG;";
            oFD.FilterIndex = 1;
            oFD.RestoreDirectory = true;
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                String CurrentFileName = Path.GetFullPath(oFD.FileName);
                InputImage = new Bitmap(CurrentFileName);
                InputPictureBox.Image = InputImage;
            }
        }

        private void AlgoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AlgoButton_Click(object sender, EventArgs e)
        {
            if (InputImage != null && AlgoListBox.SelectedIndex != -1 && listBox1.SelectedIndex != -1)
            {
                InfoLabel.Text += "Start running " + NoiseList.ElementAt(AlgoListBox.SelectedIndex).Name + "...\n";
                InfoLabel.Text += "and " + MedianList.ElementAt(listBox1.SelectedIndex).Name + "...\n";
                startAlgThread();
            }

        }

        private void OutputPictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (OutputPictureBox.Image != null)
            {
                Form ipForm = new ImagePreviewForm(new Bitmap(OutputPictureBox.Image));
                ipForm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            InfoLabel.Text = "";
        }

        private void backgroundAlgorithmWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Algorithm canceled.");
            }
            else
            {
                stopWatch.Stop();
                long elapsedms = stopWatch.ElapsedMilliseconds;
                int value = AlgoListBox.SelectedIndex;
                InfoLabel.Text += NoiseList.ElementAt(value).Name + " took: " + elapsedms + " ms\n";

                PixelDifferenceChecker pdc = new PixelDifferenceChecker();
                InfoLabel.Text += pdc.CheckDifferences(new Bitmap(InputPictureBox.Image), NoisedImage, new Bitmap(OutputPictureBox.Image)) + "\n";
                EnableAllInputs(true);
            }
        }

        private void backgroundAlgorithmWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.ComponentModel.BackgroundWorker worker;
            worker = (System.ComponentModel.BackgroundWorker)sender;
            List<object> argList = (List<object>)e.Argument;
            VisionAlgorithm visAlg = (VisionAlgorithm) argList.ElementAt(0);
            Bitmap InputImage = (Bitmap)argList.ElementAt(1);
            PictureBox OutputPictureBox = (PictureBox)argList.ElementAt(2);
            
            VisionAlgorithm medianAlg = (VisionAlgorithm)argList.ElementAt(3);

            NoisedImage = visAlg.DoAlgorithm(InputImage);
            OutputPictureBox.Image = medianAlg.DoAlgorithm(NoisedImage);

        }

        private void EnableAllInputs(bool state)
        {
            openPictureToolStripMenuItem.Enabled = state;
            AlgoButton.Enabled = state;
            AlgoListBox.Enabled = state;
            InputPictureBox.Enabled = state;
        }

        private void startAlgThread()
        {
            List<object> argList = new List<object>();
            argList.Add(NoiseList.ElementAt(AlgoListBox.SelectedIndex));
            argList.Add(InputImage);
            argList.Add(OutputPictureBox);
            argList.Add(MedianList.ElementAt(listBox1.SelectedIndex));
            stopWatch = new Stopwatch();
            EnableAllInputs(false);
            stopWatch.Start();
            backgroundAlgorithmWorker.RunWorkerAsync(argList); 
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Input_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (InputPictureBox.Image != null)
            {
                OutputPictureBox.Image = InputImage;
            }
        }


    }
}
