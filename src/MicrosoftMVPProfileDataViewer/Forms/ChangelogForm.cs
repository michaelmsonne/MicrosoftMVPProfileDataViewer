using System;
using System.Windows.Forms;

namespace MVPProfileDataViewer.Forms
{
    public partial class Changelog : Form
    {
        public Changelog()
        {
            InitializeComponent();
        }

        private void Changelog_Load(object sender, EventArgs e)
        {
            PopulateChangelog();
        }

        // Populate the changelog in the RichTextBox
        private void PopulateChangelog()
        {
            // Changelog content
            var changelogContent = "Version 1.0.0.0 (01-09-2024):\n" +
                                   "- First release";

            // Set the content in the RichTextBox control
            richTextBoxChangelog.Text = changelogContent;
        }
    }
}