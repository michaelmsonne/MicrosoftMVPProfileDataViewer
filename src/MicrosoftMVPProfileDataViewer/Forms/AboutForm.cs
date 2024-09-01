using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPProfileDataViewer
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;

            // Create an instance of the ToolTip class to provide tooltip information for the pictureBoxBuyMeACoffee control
            ToolTip toolTipForPictureBox = new ToolTip();
            toolTipForPictureBox.AutoPopDelay = 5000;  // Tooltip stays open for 5 seconds
            toolTipForPictureBox.InitialDelay = 1000;  // Tooltip appears after 1 second
            toolTipForPictureBox.ReshowDelay = 500;    // Tooltip reappears after half a second when the cursor moves from one control to another
            toolTipForPictureBox.ShowAlways = true;    // Tooltip will show even if the form is not active

            // Set the tooltip text for pictureBoxBuyMeACoffee
            toolTipForPictureBox.SetToolTip(pictureBoxBuyMeACoffee, "Support me on Buy Me a Coffee!");
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void pictureBoxBuyMeACoffee_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://buymeacoffee.com/sonnes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Microsoft MVP Profile Data Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://blog.sonnes.cloud");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Microsoft MVP Profile Data Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://github.com/michaelmsonne");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Microsoft MVP Profile Data Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelLinkedIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://www.linkedin.com/in/michaelmsonne/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Microsoft MVP Profile Data Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
