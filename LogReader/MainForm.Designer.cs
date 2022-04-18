﻿#region License statement
/* SnakeTail is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3 of the License.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion

namespace LogReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && (_mruMenu != null))
            {
                _mruMenu.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._statusTextBar = new System.Windows.Forms.ToolStripStatusLabel();
            this._statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this._mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openEventLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentFile1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.clearListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRecentFilesToRegistryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noActiveWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileWindowsHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileWindowsVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.minimizeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._MDITabControl = new System.Windows.Forms.TabControl();
            this._trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._trayIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._tabContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._openFolderTabContext = new System.Windows.Forms.ToolStripMenuItem();
            this._copyPathTabContext = new System.Windows.Forms.ToolStripMenuItem();
            this._separatorTabContext = new System.Windows.Forms.ToolStripSeparator();
            this._closeTabContext = new System.Windows.Forms.ToolStripMenuItem();
            this._statusStrip.SuspendLayout();
            this._mainMenu.SuspendLayout();
            this._trayIconContextMenuStrip.SuspendLayout();
            this._tabContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _statusStrip
            // 
            this._statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusTextBar,
            this._statusProgressBar});
            this._statusStrip.Location = new System.Drawing.Point(0, 741);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
            this._statusStrip.Size = new System.Drawing.Size(988, 32);
            this._statusStrip.TabIndex = 3;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _statusTextBar
            // 
            this._statusTextBar.Name = "_statusTextBar";
            this._statusTextBar.Size = new System.Drawing.Size(963, 25);
            this._statusTextBar.Spring = true;
            this._statusTextBar.Text = "Ready";
            this._statusTextBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._statusTextBar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // _statusProgressBar
            // 
            this._statusProgressBar.Name = "_statusProgressBar";
            this._statusProgressBar.Size = new System.Drawing.Size(167, 27);
            this._statusProgressBar.Visible = false;
            // 
            // _mainMenu
            // 
            this._mainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this._mainMenu.Location = new System.Drawing.Point(0, 0);
            this._mainMenu.MdiWindowListItem = this.windowToolStripMenuItem;
            this._mainMenu.Name = "_mainMenu";
            this._mainMenu.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this._mainMenu.Size = new System.Drawing.Size(988, 37);
            this._mainMenu.TabIndex = 4;
            this._mainMenu.Text = "MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openEventLogToolStripMenuItem,
            this.closeItemToolStripMenuItem,
            this.loadSessionToolStripMenuItem,
            this.saveSessionToolStripMenuItem,
            this.closeSessionToolStripMenuItem,
            this.toolStripSeparator5,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator4,
            this.minimizeToTrayToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.openToolStripMenuItem.Text = "Open &File...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openEventLogToolStripMenuItem
            // 
            this.openEventLogToolStripMenuItem.Name = "openEventLogToolStripMenuItem";
            this.openEventLogToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.openEventLogToolStripMenuItem.Text = "Open &EventLog...";
            this.openEventLogToolStripMenuItem.Click += new System.EventHandler(this.openEventLogToolStripMenuItem_Click);
            // 
            // closeItemToolStripMenuItem
            // 
            this.closeItemToolStripMenuItem.Enabled = false;
            this.closeItemToolStripMenuItem.Name = "closeItemToolStripMenuItem";
            this.closeItemToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.closeItemToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.closeItemToolStripMenuItem.Text = "&Close";
            this.closeItemToolStripMenuItem.Click += new System.EventHandler(this.closeItemToolStripMenuItem_Click);
            // 
            // loadSessionToolStripMenuItem
            // 
            this.loadSessionToolStripMenuItem.Name = "loadSessionToolStripMenuItem";
            this.loadSessionToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.loadSessionToolStripMenuItem.Text = "&Open Session...";
            this.loadSessionToolStripMenuItem.Click += new System.EventHandler(this.loadSessionToolStripMenuItem_Click);
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.saveSessionToolStripMenuItem.Text = "&Save Session...";
            this.saveSessionToolStripMenuItem.Click += new System.EventHandler(this.saveSessionToolStripMenuItem_Click);
            // 
            // closeSessionToolStripMenuItem
            // 
            this.closeSessionToolStripMenuItem.Name = "closeSessionToolStripMenuItem";
            this.closeSessionToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.closeSessionToolStripMenuItem.Text = "C&lose Session";
            this.closeSessionToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(263, 6);
            // 
            // recentFilesToolStripMenuItem
            // 
            this.recentFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recentFile1ToolStripMenuItem,
            this.toolStripSeparator6,
            this.clearListToolStripMenuItem,
            this.saveRecentFilesToRegistryToolStripMenuItem});
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.recentFilesToolStripMenuItem.Text = "&Recent Files";
            // 
            // recentFile1ToolStripMenuItem
            // 
            this.recentFile1ToolStripMenuItem.Name = "recentFile1ToolStripMenuItem";
            this.recentFile1ToolStripMenuItem.Size = new System.Drawing.Size(317, 34);
            this.recentFile1ToolStripMenuItem.Text = "None";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(314, 6);
            // 
            // clearListToolStripMenuItem
            // 
            this.clearListToolStripMenuItem.Name = "clearListToolStripMenuItem";
            this.clearListToolStripMenuItem.Size = new System.Drawing.Size(317, 34);
            this.clearListToolStripMenuItem.Text = "Clear Recent Files";
            this.clearListToolStripMenuItem.Click += new System.EventHandler(this.clearListToolStripMenuItem_Click);
            // 
            // saveRecentFilesToRegistryToolStripMenuItem
            // 
            this.saveRecentFilesToRegistryToolStripMenuItem.Name = "saveRecentFilesToRegistryToolStripMenuItem";
            this.saveRecentFilesToRegistryToolStripMenuItem.Size = new System.Drawing.Size(317, 34);
            this.saveRecentFilesToRegistryToolStripMenuItem.Text = "Save in Windows Registry";
            this.saveRecentFilesToRegistryToolStripMenuItem.Click += new System.EventHandler(this.saveRecentFilesToRegistryToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(263, 6);
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.minimizeToTrayToolStripMenuItem.Text = "&Minimize to tray";
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToTrayToolStripMenuItem_Click);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.alwaysOnTopToolStripMenuItem.Text = "Al&ways on top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noActiveWindowToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // noActiveWindowToolStripMenuItem
            // 
            this.noActiveWindowToolStripMenuItem.Enabled = false;
            this.noActiveWindowToolStripMenuItem.Name = "noActiveWindowToolStripMenuItem";
            this.noActiveWindowToolStripMenuItem.Size = new System.Drawing.Size(255, 34);
            this.noActiveWindowToolStripMenuItem.Text = "No active window";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableTabsToolStripMenuItem,
            this.cascadeWindowsToolStripMenuItem,
            this.tileWindowsHorizontallyToolStripMenuItem,
            this.tileWindowsVerticallyToolStripMenuItem,
            this.toolStripSeparator1,
            this.minimizeAllToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.toolStripSeparator2});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(94, 29);
            this.windowToolStripMenuItem.Text = "&Window";
            this.windowToolStripMenuItem.DropDownOpening += new System.EventHandler(this.windowToolStripMenuItem_DropDownOpening);
            this.windowToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.windowToolStripMenuItem_DropDownItemClicked);
            // 
            // enableTabsToolStripMenuItem
            // 
            this.enableTabsToolStripMenuItem.Name = "enableTabsToolStripMenuItem";
            this.enableTabsToolStripMenuItem.Size = new System.Drawing.Size(319, 34);
            this.enableTabsToolStripMenuItem.Text = "Show Tabs";
            this.enableTabsToolStripMenuItem.Click += new System.EventHandler(this.enableTabsToolStripMenuItem_Click);
            // 
            // cascadeWindowsToolStripMenuItem
            // 
            this.cascadeWindowsToolStripMenuItem.Name = "cascadeWindowsToolStripMenuItem";
            this.cascadeWindowsToolStripMenuItem.Size = new System.Drawing.Size(319, 34);
            this.cascadeWindowsToolStripMenuItem.Text = "Cascade Windows";
            this.cascadeWindowsToolStripMenuItem.Click += new System.EventHandler(this.cascadeWindowsToolStripMenuItem_Click);
            // 
            // tileWindowsHorizontallyToolStripMenuItem
            // 
            this.tileWindowsHorizontallyToolStripMenuItem.Name = "tileWindowsHorizontallyToolStripMenuItem";
            this.tileWindowsHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(319, 34);
            this.tileWindowsHorizontallyToolStripMenuItem.Text = "Tile Windows Horizontally";
            this.tileWindowsHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.tileWindowsHorizontallyToolStripMenuItem_Click);
            // 
            // tileWindowsVerticallyToolStripMenuItem
            // 
            this.tileWindowsVerticallyToolStripMenuItem.Name = "tileWindowsVerticallyToolStripMenuItem";
            this.tileWindowsVerticallyToolStripMenuItem.Size = new System.Drawing.Size(319, 34);
            this.tileWindowsVerticallyToolStripMenuItem.Text = "Tile Windows Vertically";
            this.tileWindowsVerticallyToolStripMenuItem.Click += new System.EventHandler(this.tileWindowsVerticallyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(316, 6);
            // 
            // minimizeAllToolStripMenuItem
            // 
            this.minimizeAllToolStripMenuItem.Name = "minimizeAllToolStripMenuItem";
            this.minimizeAllToolStripMenuItem.Size = new System.Drawing.Size(319, 34);
            this.minimizeAllToolStripMenuItem.Text = "Minimize All";
            this.minimizeAllToolStripMenuItem.Click += new System.EventHandler(this.minimizeAllToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(319, 34);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(316, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.checkForUpdateToolStripMenuItem.Text = "&Check for updates";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(258, 34);
            this.aboutToolStripMenuItem1.Text = "&About SnakeTail";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // _MDITabControl
            // 
            this._MDITabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._MDITabControl.Location = new System.Drawing.Point(0, 37);
            this._MDITabControl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._MDITabControl.Name = "_MDITabControl";
            this._MDITabControl.SelectedIndex = 0;
            this._MDITabControl.ShowToolTips = true;
            this._MDITabControl.Size = new System.Drawing.Size(988, 44);
            this._MDITabControl.TabIndex = 5;
            this._MDITabControl.Visible = false;
            this._MDITabControl.SelectedIndexChanged += new System.EventHandler(this._MDITabControl_SelectedIndexChanged);
            this._MDITabControl.DragDrop += new System.Windows.Forms.DragEventHandler(this._MDITabControl_DragDrop);
            this._MDITabControl.DragEnter += new System.Windows.Forms.DragEventHandler(this._MDITabControl_DragEnter);
            this._MDITabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this._MDITabControl_MouseClick);
            this._MDITabControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this._MDITabControl_MouseMove);
            // 
            // _trayIcon
            // 
            this._trayIcon.ContextMenuStrip = this._trayIconContextMenuStrip;
            this._trayIcon.DoubleClick += new System.EventHandler(this._trayIcon_DoubleClick);
            // 
            // _trayIconContextMenuStrip
            // 
            this._trayIconContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._trayIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3});
            this._trayIconContextMenuStrip.Name = "_trayIconContextMenuStrip";
            this._trayIconContextMenuStrip.Size = new System.Drawing.Size(61, 10);
            this._trayIconContextMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this._trayIconContextMenuStrip_Closed);
            this._trayIconContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this._trayIconContextMenuStrip_Opening);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(57, 6);
            // 
            // _tabContextMenuStrip
            // 
            this._tabContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._tabContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openFolderTabContext,
            this._copyPathTabContext,
            this._separatorTabContext,
            this._closeTabContext});
            this._tabContextMenuStrip.Name = "_closeTabContext";
            this._tabContextMenuStrip.Size = new System.Drawing.Size(184, 106);
            // 
            // _openFolderTabContext
            // 
            this._openFolderTabContext.Name = "_openFolderTabContext";
            this._openFolderTabContext.Size = new System.Drawing.Size(183, 32);
            this._openFolderTabContext.Text = "Open Folder";
            this._openFolderTabContext.Click += new System.EventHandler(this._openContainingFolderClick);
            // 
            // _copyPathTabContext
            // 
            this._copyPathTabContext.Name = "_copyPathTabContext";
            this._copyPathTabContext.Size = new System.Drawing.Size(183, 32);
            this._copyPathTabContext.Text = "Copy Path";
            this._copyPathTabContext.Click += new System.EventHandler(this._copyFolderPathClick);
            // 
            // _separatorTabContext
            // 
            this._separatorTabContext.Name = "_separatorTabContext";
            this._separatorTabContext.Size = new System.Drawing.Size(180, 6);
            // 
            // _closeTabContext
            // 
            this._closeTabContext.Name = "_closeTabContext";
            this._closeTabContext.Size = new System.Drawing.Size(183, 32);
            this._closeTabContext.Text = "&Close";
            this._closeTabContext.Click += new System.EventHandler(this._closeContextClick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 773);
            this.Controls.Add(this._MDITabControl);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this._mainMenu;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MainForm";
            this.Text = "Log Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._mainMenu.ResumeLayout(false);
            this._mainMenu.PerformLayout();
            this._trayIconContextMenuStrip.ResumeLayout(false);
            this._tabContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _mainMenu;
        private System.Windows.Forms.TabControl _MDITabControl;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableTabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileWindowsHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileWindowsVerticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel _statusTextBar;
        private System.Windows.Forms.ToolStripProgressBar _statusProgressBar;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripMenuItem closeSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.NotifyIcon _trayIcon;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip _trayIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openEventLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noActiveWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentFile1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem saveRecentFilesToRegistryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeItemToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip _tabContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _copyPathTabContext;
        private System.Windows.Forms.ToolStripMenuItem _closeTabContext;
        private System.Windows.Forms.ToolStripSeparator _separatorTabContext;
        private System.Windows.Forms.ToolStripMenuItem _openFolderTabContext;
    }
}

