using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string SongFilePath = null;
        bool musicPlaying = false;
        string[] files = null;
        string[] WavFiles = null;
        string[] fileExtension = null;
        SoundPlayer musicPlayer = null;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            foreach (Form c in this.MdiChildren) {c.Close();}

            Form ChildForm = new Form2();
            ChildForm.MdiParent = this;
            ChildForm.Height = this.Height-30;
            ChildForm.Width = this.Width-185;
            ChildForm.Location = new Point(180, 0);
            ChildForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))));
            ChildForm.Show();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e) {


        }

        private void toolStripButton2_Click(object sender, EventArgs e) {

            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                SongFilePath = openFileDialog1.FileName;
            }

            musicPlayer = new SoundPlayer(SongFilePath);
            musicPlayer.Play();

        }

        private void Form1_Load(object sender, EventArgs e){
            
        }
        
        private void toolStripComboBox1_DropDown(object sender, EventArgs e){
            toolStripComboBox1.Items.Clear();
            int c = 0;
            foreach (string s in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))){
                string[] checkfiletype = s.Split('.');
                if(checkfiletype[1] == "wav"){
                    WavFiles[c] = s;
                    string[] filemame = checkfiletype[0].Split('\\');
                    toolStripComboBox1.Items.Add(filemame[filemame.Length - 1]);
                }
                c++;
            }            
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            int index = toolStripComboBox1.SelectedIndex;
            musicPlayer = new SoundPlayer(files[index]);
            musicPlayer.Play();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            foreach (Form c in this.MdiChildren) { c.Close(); }
        }
    }
}
