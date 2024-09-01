using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MVPProfileDataViewer.Class;
using Newtonsoft.Json;

namespace MVPProfileDataViewer.Forms
{
    public partial class MainForm : Form
    {
        private List<dynamic> _activities; // Store activities in a list for virtual mode
        private Dictionary<string, int> _activityTypeCounts;
        private Dictionary<string, int> _technologyFocusAreaCounts;

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Enable virtual mode
            dataGridViewActivities.VirtualMode = true;
            dataGridViewActivities.CellValueNeeded += DataGridViewActivities_CellValueNeeded;

            // Enable double buffering
            EnableDoubleBuffering(dataGridViewActivities);
        }
        
        private void EnableDoubleBuffering(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }

        private void DataGridViewActivities_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            // Check if activities is null or the row index is out of range
            if (_activities == null || e.RowIndex >= _activities.Count)
                return;

            // Get the activity at the specified row index
            var activity = _activities[e.RowIndex];
            switch (dataGridViewActivities.Columns[e.ColumnIndex].Name)
            {
                case "DateCreated":
                    e.Value = activity.dateCreated;
                    break;
                case "ActivityType":
                    e.Value = activity.activityTypeName;
                    break;
                case "Role":
                    e.Value = activity.role;
                    break;
                case "TechnologyFocusArea":
                    e.Value = activity.technologyFocusArea;
                    break;
                case "TargetAudience":
                    e.Value = string.Join(", ", activity.targetAudience.ToObject<string[]>());
                    break;
                case "Title":
                    e.Value = activity.title;
                    break;
                case "Description":
                    e.Value = activity.description;
                    break;
                case "URL":
                    e.Value = activity.url;
                    break;
                case "IsHighImpact":
                    e.Value = activity.isHighImpact;
                    break;
            }
        }

        private void LoadJsonData(string jsonFilePath)
        {
            try
            {
                // Check if the JSON file exists
                if (File.Exists(jsonFilePath))
                {
                    // Read the JSON data from the file
                    var jsonData = File.ReadAllText(jsonFilePath);
                    dynamic parsedJson = JsonConvert.DeserializeObject(jsonData);

                    // Check if the parsed JSON data is not null
                    if (parsedJson != null)
                    {
                        // Display the user profile data
                        textBoxProfile.Text =
                            $@"Name: {parsedJson.userProfile.firstName} {parsedJson.userProfile.lastName}" +
                            Environment.NewLine +
                            $@"Email: {parsedJson.userProfile.primaryEmail}" + Environment.NewLine +
                            $@"Date of Birth: {parsedJson.userProfile.dateOfBirth}" + Environment.NewLine +
                            Environment.NewLine +
                            $@"Headline: {parsedJson.userProfile.headline}" + Environment.NewLine +
                            $@"Biography: {parsedJson.userProfile.biography}";

                        // Clear the data grid view columns and rows
                        dataGridViewActivities.Rows.Clear();
                        dataGridViewActivities.Columns.Clear();
                        dataGridViewActivities.Columns.Add("DateCreated", "Date Created");
                        dataGridViewActivities.Columns.Add("ActivityType", "Activity Type");
                        dataGridViewActivities.Columns.Add("Role", "Role");
                        dataGridViewActivities.Columns.Add("TechnologyFocusArea", "Technology Focus Area");
                        dataGridViewActivities.Columns.Add("TargetAudience", "Target Audience");
                        dataGridViewActivities.Columns.Add("Title", "Title");
                        dataGridViewActivities.Columns.Add("Description", "Description");
                        dataGridViewActivities.Columns.Add("URL", "URL");
                        dataGridViewActivities.Columns.Add("IsHighImpact", "High Impact");

                        // Set the column widths
                        // ReSharper disable once PossibleNullReferenceException
                        dataGridViewActivities.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                        // Set the activities list and row count
                        _activities = new List<dynamic>();
                        _activityTypeCounts = new Dictionary<string, int>();
                        _technologyFocusAreaCounts = new Dictionary<string, int>();

                        // Loop through the activities and add them to the list
                        foreach (var activity in parsedJson.mostValuableProfessionalProgram.activities)
                        {
                            // Add the activity to the list
                            _activities.Add(activity);

                            // Get the activity type and technology focus area
                            string activityType = activity.activityTypeName.ToString();
                            string technologyFocusArea = activity.technologyFocusArea.ToString();

                            // Update the activity type and technology focus area counts
                            if (_activityTypeCounts.ContainsKey(activityType))
                            {
                                _activityTypeCounts[activityType]++;
                            }
                            else
                            {
                                _activityTypeCounts[activityType] = 1;
                            }

                            // Update the technology focus area counts
                            if (_technologyFocusAreaCounts.ContainsKey(technologyFocusArea))
                            {
                                _technologyFocusAreaCounts[technologyFocusArea]++;
                            }
                            else
                            {
                                _technologyFocusAreaCounts[technologyFocusArea] = 1;
                            }
                        }

                        // Set the row count and resize the rows
                        dataGridViewActivities.RowCount = _activities.Count;
                        dataGridViewActivities.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                        // If activities were found, display the count and show a message box with the counts
                        if (_activities.Count > 0)
                        {
                            // Display the activity count
                            toolStripStatusLabelActivityCount.Text = $@"Activity Count: {_activities.Count}";

                            // Show a message box with the activity type and technology focus area counts
                            var activityTypeCountMessage = "Activity Type Counts:" + Environment.NewLine;
                            activityTypeCountMessage = _activityTypeCounts.Aggregate(activityTypeCountMessage,
                                (current, kvp) => current + ($"{kvp.Key}: {kvp.Value}" + Environment.NewLine));

                            var technologyFocusAreaCountMessage = "Technology Focus Area Counts:" + Environment.NewLine;
                            technologyFocusAreaCountMessage = _technologyFocusAreaCounts.Aggregate(
                                technologyFocusAreaCountMessage,
                                (current, kvp) => current + ($"{kvp.Key}: {kvp.Value}" + Environment.NewLine));

                            MessageBox.Show(
                                activityTypeCountMessage + Environment.NewLine + technologyFocusAreaCountMessage,
                                @"Activity and Technology Focus Area Counts", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Show a message box if no activities were found
                            MessageBox.Show(@"No activities found.", @"Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            // Update the activity count status label
                            toolStripStatusLabelActivityCount.Text = $@"Activity Count: {_activities.Count}";
                        }
                    }
                }
                else
                {
                    // Show an error message if the JSON file was not found
                    MessageBox.Show(@"JSON file not found.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurred
                MessageBox.Show($@"An error occurred while loading the JSON data: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnShowCounts_Click(object sender, EventArgs e)
        {
            if (_activities != null && _activities.Count > 0)
            {
                var activityTypeCountMessage = "Activity Type Counts:" + Environment.NewLine;
                activityTypeCountMessage = _activityTypeCounts.Aggregate(activityTypeCountMessage,
                    (current, kvp) => current + ($"{kvp.Key}: {kvp.Value}" + Environment.NewLine));

                var technologyFocusAreaCountMessage = "Technology Focus Area Counts:" + Environment.NewLine;
                technologyFocusAreaCountMessage = _technologyFocusAreaCounts.Aggregate(
                    technologyFocusAreaCountMessage,
                    (current, kvp) => current + ($"{kvp.Key}: {kvp.Value}" + Environment.NewLine));

                MessageBox.Show(
                    activityTypeCountMessage + Environment.NewLine + technologyFocusAreaCountMessage,
                    @"Activity and Technology Focus Area Counts", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"No activities found.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void selectJsonFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Open file dialog to select a JSON file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the file dialog properties
                openFileDialog.Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = @"Open JSON File";

                // Check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the JSON data
                    LoadJsonData(openFileDialog.FileName);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display the About dialog
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display the help dialog
            using (HelpForm helpForm = new HelpForm())
            {
                helpForm.ShowDialog();
            }
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display the changelog dialog
            using (Changelog changelogForm = new Changelog())
            {
                changelogForm.ShowDialog();
            }

        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if there is data available to export
            if (dataGridViewActivities.Rows.Count == 0)
            {
                MessageBox.Show(@"No data available to export.", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new ContextExporter instance
            var exporter = new ContextExporter();

            // Create a new save file dialog
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"CSV files (*.csv)|*.csv",
                Title = @"Save an Export File"
            };

            // Check if the user selected a file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the filename from the save file dialog
                var fileName = saveFileDialog.FileName;

                // Export the data to a CSV file
                exporter.ExportToCsv(dataGridViewActivities, saveFileDialog.FileName);

                // Show a message box with the export status
                MessageBox.Show(@"Export successful to: " + fileName + @"!", @"Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}