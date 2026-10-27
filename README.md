# Local-WP-Startup-Fix
# ⚡ LocalWP Doctor Pro v2.0

**LocalWP Doctor Pro** is a modern, interactive, open-source dashboard utility engineered to diagnose, repair, and optimize **Local (LocalWP) by Flywheel** on Windows systems.

**Developed & Engineered by:** Mohamed Elgamal
**License:** MIT Open Source License  
**Year:** 2026

---

## 🌟 Interactive Features (v2.0 Pro)

- **📊 Live Dashboard Metrics:** Real-time visual cards displaying:
  1. **Database Services:** Live status of MySQL & MariaDB services (Versions, Retries, and Timeout status).
  2. **Stale Lock Detector:** Real-time detection and count of orphaned `.pid` files blocking startups.
  3. **Site Scanner:** Automatically detects local WordPress sites and verifies HDD performance configurations.
  4. **Port 10004 Health:** Live asynchronous socket tester to check if MySQL port is active or free.
- **🚀 One-Click Autonomous Repair:** Fully asynchronous sequence that patches services, purges stale locks, and injects HDD optimizations without freezing the interface.
- **🔄 Safety Backups & 1-Click Restore:** Automatically creates `.bak` copies before modifying any configuration, allowing instant reversion at any time.
- **⚡ HDD Performance Boost:** Enforces `innodb_flush_log_at_trx_commit = 2` and `innodb_fast_shutdown = 1` for lightning-fast database read/write speeds on mechanical disks.
- **🌐 Quick-Launch LocalWP:** Launch LocalWP straight from the application header with a single click.
- **🎨 Modern Dark UI:** Clean Tailwind-inspired dark slate theme (#0f172a / #1e293b) with custom rounded buttons, gradient progress bar, and color-coded activity terminal.
- **📋 Live Feed Tools:** Easy buttons to Copy Log to clipboard, Clear terminal, or view raw C# source code.

---

## 🛠️ Build from Source

This project has **zero external dependencies** and can be compiled natively on any Windows computer:

```cmd
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /optimize+ /r:System.dll,System.Drawing.dll,System.Windows.Forms.dll /out:LocalWPFixer.exe LocalWPFixer.cs
```

---

## 📄 License

This software is released under the **MIT License**.  
Copyright (c) 2026 Mohamed Elgamal 
