# ⚡ LocalWP Doctor Pro v2.0

**A Windows utility to diagnose, repair, and optimize Local WordPress development environments.**

LocalWP Doctor Pro is an interactive Windows desktop utility designed to help diagnose and troubleshoot startup issues in **Local (LocalWP) by Flywheel**, particularly those involving MySQL and MariaDB startup delays, database connection errors, stale PID files, and database configuration.

**Developed by:** Mohammaed El-gammal  
**Version:** 2.0  
**Year:** 2026  
**License:** MIT License  
**Platform:** Windows

---

## 📖 Overview

LocalWP Doctor Pro provides a graphical dashboard for monitoring selected LocalWP components and performing troubleshooting operations from one interface.

The project aims to simplify diagnosing local WordPress startup failures by providing database service checks, PID file detection, site scanning, configuration repair tools, and performance settings for mechanical hard drives (HDDs).

The project includes a Windows executable (`.exe`) and troubleshooting documentation.

## 🌟 Features

### 📊 Interactive Dashboard

- **Database Services:** Displays the status of MySQL and MariaDB services, including detected versions, retry information, and timeout status.
- **Stale PID Detector:** Detects and counts potentially orphaned `.pid` files that may interfere with startup.
- **Local Site Scanner:** Detects local WordPress sites and checks selected HDD-related database configuration settings.
- **Port 10004 Health Check:** Tests whether the configured MySQL port is accepting connections or appears available.

### 🚀 One-Click Repair

Provides a guided repair workflow intended to address selected LocalWP startup problems, including service configuration adjustments, stale PID file cleanup, and HDD-related database optimizations.

The actual repairs available depend on the installed application version, detected configuration, and the permissions granted to the program.

### 🔄 Automatic Backups and Restore

- Creates `.bak` backups before supported configuration changes.
- Helps users restore previous configuration files if a change causes problems.

**Important:** Verify that backups are successfully created and that restoration works before relying on this feature.

### ⚡ HDD Performance Optimization

Provides options for configuring the following MySQL InnoDB settings:

```ini
innodb_flush_log_at_trx_commit = 2
innodb_fast_shutdown = 1
```

These settings may improve performance in certain environments, especially on mechanical hard drives. However, changing database durability settings can affect data safety during an operating system crash or power failure. Review the trade-offs before applying them.

### 🌐 Quick Launch

Launch LocalWP directly from the application interface, when the installation is detected.

### 🎨 Modern Dark Interface

- Dark slate-inspired visual theme.
- Rounded buttons and a gradient progress indicator.
- Color-coded activity terminal.
- Responsive status cards and clear operational feedback.

### 📋 Activity Log Tools

- Copy activity logs to the clipboard.
- Clear the activity terminal.
- View the available C# source code.

---

## 🖥️ Requirements

- Windows operating system.
- Local (LocalWP) installed on the computer.
- Access to the relevant Local configuration files and logs.
- Appropriate file permissions for the operations you choose to perform.

Some operations may require elevated permissions, depending on the installation and the files being modified. Run with administrator privileges only when necessary.

## 📥 Download and Installation

1. Open the **Releases** section of this GitHub repository.
2. Download the latest published version of LocalWP Doctor Pro.
3. Review the release notes and any included instructions.
4. Back up your important configuration files and databases.
5. Run the executable and review its detected settings before applying repairs.
6. Check the activity log to understand which operations were performed.

If no release has been published yet, check the repository files for the available source code and documentation.

**Security recommendation:** Download executable files only from the official Releases page of this repository. Review the source code when available, and do not bypass Windows security warnings unless you have independently verified the executable.

## 🇸🇦 Arabic Troubleshooting Guide

An Arabic troubleshooting guide is included to help users investigate common LocalWP startup problems.

The guide covers:

- Increasing the MySQL startup retry limit.
- Identifying potentially stale PID files.
- Reviewing selected InnoDB configuration settings.
- Restarting Local and checking whether the site starts successfully.

Consult the guide before applying manual configuration changes.

## ⚠️ Safety and Data Protection

Before using repair functions:

- Stop running Local sites and close Local when instructed by the repair procedure.
- Back up important configuration files and databases.
- Review the proposed changes before applying them.
- Never delete active PID files; verify that they are stale and that the associated service is stopped.
- Do not modify database settings without understanding their consequences.
- Confirm that backups exist and are recoverable before changing configuration files.
- Avoid sharing database credentials, private configuration files, or logs containing personal information.

Database startup failures can have multiple causes. The tool may not resolve every problem, and some issues may require manual investigation.

## 🔧 Troubleshooting

If LocalWP still fails to start:

1. Check the Local application logs.
2. Confirm which database service and version your installation uses.
3. Verify that the configured database port matches the actual service configuration.
4. Check for stale PID files only after confirming that the relevant services are stopped.
5. Review the Arabic troubleshooting guide.
6. Report the issue through GitHub Issues, including relevant error messages and your Local version.

Remove usernames, passwords, private paths, database credentials, and other sensitive information before sharing logs publicly.

## 🛠️ Build from Source

The project includes C# source code that can be compiled using the .NET Framework C# compiler available on compatible Windows installations.

Example compilation command:

```cmd
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /optimize+ /r:System.dll,System.Drawing.dll,System.Windows.Forms.dll /out:LocalWPFixer.exe LocalWPFixer.cs
```

This command assumes that the source file is named `LocalWPFixer.cs` and that the compiler and referenced assemblies are available at the specified paths.

To build the project:

1. Obtain the source code from the repository.
2. Confirm that the compiler path exists on your system.
3. Review the source code before compiling.
4. Run the compilation command from the directory containing the source file.
5. Test the resulting executable in a non-critical LocalWP environment.

The command above is provided as an example and may need to be adjusted to match the actual source filenames and project structure.

## 🤝 Contributing

Contributions from the community are welcome.

You can help by:

- Reporting reproducible bugs.
- Improving the Arabic or English documentation.
- Testing supported Windows and Local versions.
- Suggesting safer repair procedures.
- Submitting tested code improvements.

When reporting an issue, include the Local version, Windows version, relevant error messages, and the steps required to reproduce the problem. Never include sensitive personal or database information.

## 📄 License

This project is released under the **MIT License**.

Copyright (c) 2026 Mohammaed El-gammal 

See the `LICENSE` file for the full license terms governing use, copying, modification, distribution, sublicensing, and sale of the software.

## ⚖️ Disclaimer

LocalWP Doctor Pro is an independent community project. It is not affiliated with, endorsed by, or officially supported by Local or its developers.

The software is provided **"AS IS"**, without warranties of any kind. No guarantee is made that it will resolve every LocalWP startup problem or that every repair will be suitable for every system.

Users are responsible for reviewing the program's actions, maintaining backups, and verifying the results before using the tool on important development environments.

---

**Built to help the LocalWP community diagnose and troubleshoot WordPress startup issues.**
