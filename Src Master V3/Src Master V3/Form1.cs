using System;
using System.Windows.Forms;

namespace Src_Master_V3
{
    /*
     * UI Controls:
     * title: Displays the app title.
     * pkgDir: Package directory input.
     * fileName: Input for file/directory name.
     * log: Displays package contents.
     * errors: Error log.
     */

    public partial class Form1 : Form
    {
        private string currentPackageDir;

        //Class Imports:
        FileManager fm = new FileManager();

        public Form1()
        {
            InitializeComponent();
        }

        //Update Package Contents:
        private void updatePackageContents()
        {
            //Clears the log before anything is updated:
            log.Text = "";

            string[] files = fm.getFiles(this.currentPackageDir);
            string[] dirs = fm.getDirs(this.currentPackageDir);

            if (files == null || dirs == null)
            {
                return;
            }

            int f;
            int d;

            //For loop (files):
            for (f = 0; f < files.Length; f++)
            {
                log.AppendText(files[f] + "\n");
            }

            //For loop (dirs):
            for (d = 0; d < dirs.Length; d++)
            {
                log.AppendText(dirs[d] + "\n");
            }
        }

        //When the text is changed on pkgDir:
        private void pkgDir_TextChanged(object sender, EventArgs e)
        {
            this.currentPackageDir = pkgDir.Text;
            this.updatePackageContents();
        }

        //Create File Button:
        private void button1_Click(object sender, EventArgs e)
        {
            string enteredFileName = fileName.Text;
            bool fileCreated = fm.createFile(this.currentPackageDir + "\\" + enteredFileName);
            this.updatePackageContents();

            if (!fileCreated)
            {
                errors.AppendText("Could not create file: " + this.currentPackageDir + "\\" + enteredFileName + "\n");
                return;
            }
        }

        //Create directory:
        private void button2_Click(object sender, EventArgs e)
        {
            string enteredDirName = fileName.Text;
            bool dirCreated = fm.createDirectory(this.currentPackageDir + "\\" + enteredDirName);
            this.updatePackageContents();

            if (!dirCreated)
            {
                errors.AppendText("Could not create directory: " + this.currentPackageDir + "\\" + enteredDirName + "\n");
            }
        }
    }
}