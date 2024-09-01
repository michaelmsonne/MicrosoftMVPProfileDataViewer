# Microsoft MVP Profile Data Viewer

<p align="center">
  <a href="https://www.linkedin.com/in/michaelmsonne/"><img alt="Made by" src="https://img.shields.io/static/v1?label=made%20by&message=Michael%20Morten%20Sonne&color=04D361"></a>
  <a href="https://github.com/michaelmsonne/MicrosoftMVPProfileDataViewer"><img src="https://img.shields.io/github/languages/top/MicrosoftMVPProfileDataViewer/GitHubBackupTool.svg"></a>
  <a href="https://github.com/michaelmsonne/MicrosoftMVPProfileDataViewer"><img src="https://img.shields.io/github/languages/code-size/MicrosoftMVPProfileDataViewer/GitHubBackupTool.svg"></a>
  <a href="https://github.com/michaelmsonne/MicrosoftMVPProfileDataViewer"><img src="https://img.shields.io/github/downloads/michaelmsonne/MicrosoftMVPProfileDataViewer/total.svg"></a><br>
  <a href="https://www.buymeacoffee.com/sonnes" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" style="height: 30px !important;width: 117px !important;"></a>
</p>

<div align="center">
  <a href="https://github.com/michaelmsonne/MicrosoftMVPProfileDataViewer/issues/new?assignees=&labels=bug&MicrosoftMVPProfileDataViewer=01_BUG_REPORT.md&title=bug%3A+">Report a Bug</a>
  ·
  <a href="https://github.com/michaelmsonne/MicrosoftMVPProfileDataViewer/issues/new?assignees=&labels=enhancement&MicrosoftMVPProfileDataViewer=02_FEATURE_REQUEST.md&title=feat%3A+">Request a Feature</a>
  .
  <a href="https://github.com/michaelmsonne/MicrosoftMVPProfileDataViewer/discussions">Ask a Question</a>
</div>

<div align="center">
<br />

</div>

## Table of Contents
- [Introduction](#introduction)
- [Contents](#contents)
- [Features](#features)
- [Download](#download)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Examples](#examples)
- [Contributing](#contributing)
- [Status](#status)
- [Support](#support)
- [License](#license)

# Introduction
This tool is to view the Microsoft MVP Activity list exported from the Microsoft MVP portal. The tool allows users to load a JSON file containing MVP profile data and display the user's profile information and activities in a user-friendly interface. The tool provides options to select a JSON file, display profile details, and view activities in a DataGridView.

## Contents

Outline the file contents of the repository. It helps users navigate the codebase, build configuration and any related assets.

| File/folder       | Description                                 |
|-------------------|---------------------------------------------|
| `src`             | Source code.                                |
| `.gitignore`      | Define what to ignore at commit time.       |
| `CHANGELOG.md`    | List of changes to the sample.              |
| `CONTRIBUTING.md` | Guidelines for contributing to the MicrosoftMVPProfileDataViewer.|
| `README.md`       | This README file.                           |
| `SECURITY.md`     | This SECURITY file.                         |
| `LICENSE`         | The license for the MicrosoftMVPProfileDataViewer.               |

## Features

### Overall:
- Load JSON Data:
    - File Selection: Users can select a JSON file containing MVP profile data using an Open File Dialog.
    - Data Parsing: The tool reads and parses the JSON file to extract user profile and activity information.
    - Error Handling: Displays error messages if the JSON file is not found or if an error occurs during data loading.
- Display Profile Information:
    - Profile Details: Displays the user's name, email, date of birth, headline, and biography in a text box.
- Display Activities:
    - DataGridView: Activities are displayed in a DataGridView with columns for Date Created, Activity Type, Role, Technology Focus Area, Target Audience, Title, Description, URL, and High Impact.
    - Activity Count: The total number of activities is displayed in a status strip label.
    - Activity Type Counts: Counts of each activity type are calculated and displayed in a message box.
    - Technology Focus Area Counts: Counts of each technology focus area are calculated and displayed in a message box.
- Menu Options:
    - Select JSON File: Opens a file dialog to select and load a JSON file.
    - Changelog: Displays a Changelog dialog with information about the tool's version history.
    - Export to CSV: Exports the activities data to a CSV file.
    - Help: Displays a Help dialog with instructions on how to use the tool.
    - About: Displays an About dialog with information about the tool.

## Download

[Download the latest version](../../releases/latest)

[Version History](CHANGELOG.md)

## Getting Started
### Prerequisites
- [.NET](https://dotnet.microsoft.com/download) installed on your system.

### Installation
You can either clone this repository and build the project yourself or use the provided installer.

## Usage
Start the application and load a JSON file containing Microsoft MVP profile data. The tool will display the user's profile information and activities in the interface. You can view the profile details and activities in the DataGridView, export the activities to a CSV file, and view the changelog, help, and about dialogs.

Can´t share the .json file content and a screenshot of the tool, as it contains personal information and stuff under NDA i´m not allowed to share.

# Final thoughts
This is not an exhaustive method to retrieve every artifact...

## Building

## Used 3rd party libraries for the tool:
- [Newtonsoft.Json](https://www.newtonsoft.com/json) - JSON.NET is a popular high-performance JSON framework for .NET.


# Contributing
If you want to contribute to this project, please open an issue or submit a pull request. I welcome contributions :)

See [CONTRIBUTING](CONTRIBUTING) for more information.

First off, thanks for taking the time to contribute! Contributions are what makes the open-source community such an amazing place to learn, inspire, and create. Any contributions you make will benefit everybody else and are **greatly appreciated**.
Feel free to send pull requests or fill out issues when you encounter them. I'm also completely open to adding direct maintainers/contributors and working together! :)

Please try to create bug reports that are:

- _Reproducible._ Include steps to reproduce the problem.
- _Specific._ Include as much detail as possible: which version, what environment, etc.
- _Unique._ Do not duplicate existing opened issues.
- _Scoped to a Single Bug._ One bug per report.´´

# Status

The project is actively developed and updated.

# Support

Commercial support

This project is open-source and I invite everybody who can and will to contribute, but I cannot provide any support because I only created this as a "hobby project" ofc. with tbe best in mind. For commercial support, please contact me on LinkedIn so we can discuss the possibilities. It’s my choice to work on this project in my spare time, so if you have commercial gain from this project you should considering sponsoring me.

<a href="https://www.buymeacoffee.com/sonnes" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" style="height: 30px !important;width: 117px !important;"></a>

Thanks.

Reach out to the maintainer at one of the following places:

- [GitHub discussions](https://github.com/michaelmsonne/MicrosoftMVPProfileDataViewer/discussions)
- The email which is located [in GitHub profile](https://github.com/michaelmsonne)

# License
This project is licensed under the **MIT License** - see the LICENSE file for details.

See [LICENSE](LICENSE) for more information.

# Sponsors
## Advanced Installer
The installer is created from a Free Advanced Installer License for Open-Source from <a href="https://www.advancedinstaller.com/" target="_blank">https://www.advancedinstaller.com/</a> - this allowed me to create a feature complete installer in a user friendly environment with minimal effort - check it out!

[<img src="https://cdn.advancedinstaller.com/svg/pressinfo/AiLogoColor.svg" title="Advanced Installer" alt="Advanced Instzaller" height="120"/>](https://www.advancedinstaller.com/)
## JetBrains
JetBrains specialises in intelligent, productivity-enabling tools to help you write clean, quality code across . NET, Java, Ruby, Python, PHP, JavaScript, C# and C++ platforms throughout all stages of development. <a href="https://www.jetbrains.com/" target="_blank">https://www.jetbrains.com/</a> - check it out!

## SAST Tools
[PVS-Studio](https://pvs-studio.com/en/pvs-studio/?utm_source=github&utm_medium=organic&utm_campaign=open_source) - static analyzer for C, C++, C#, and Java code.
