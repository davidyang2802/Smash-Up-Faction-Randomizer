namespace Smash_Up_Faction_Randomizer
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checklistSets = new System.Windows.Forms.CheckedListBox();
            this.btnSmashUp = new System.Windows.Forms.Button();
            this.tabsLists = new System.Windows.Forms.TabControl();
            this.tabSets = new System.Windows.Forms.TabPage();
            this.tabFactions = new System.Windows.Forms.TabPage();
            this.checklistFactions = new System.Windows.Forms.CheckedListBox();
            this.tabLocks = new System.Windows.Forms.TabPage();
            this.checklistLocks = new System.Windows.Forms.CheckedListBox();
            this.cbFactionPool = new System.Windows.Forms.ComboBox();
            this.tbFactionPool = new System.Windows.Forms.TextBox();
            this.tvPlayers = new System.Windows.Forms.TreeView();
            this.tbSelectionNote = new System.Windows.Forms.TextBox();
            this.cbPlayerCount = new System.Windows.Forms.ComboBox();
            this.tbPlayerCount = new System.Windows.Forms.TextBox();
            this.tbGameMode = new System.Windows.Forms.TextBox();
            this.cbGameMode = new System.Windows.Forms.ComboBox();
            this.tbGameModeDescription = new System.Windows.Forms.TextBox();
            this.btnDraft = new System.Windows.Forms.Button();
            this.tbSwap = new System.Windows.Forms.TextBox();
            this.cbSwap = new System.Windows.Forms.ComboBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.cbDrop = new System.Windows.Forms.ComboBox();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnPass = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.tabsLists.SuspendLayout();
            this.tabSets.SuspendLayout();
            this.tabFactions.SuspendLayout();
            this.tabLocks.SuspendLayout();
            this.SuspendLayout();
            // 
            // checklistSets
            // 
            this.checklistSets.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checklistSets.FormattingEnabled = true;
            this.checklistSets.Location = new System.Drawing.Point(0, 0);
            this.checklistSets.Name = "checklistSets";
            this.checklistSets.Size = new System.Drawing.Size(584, 578);
            this.checklistSets.TabIndex = 1;
            // 
            // btnSmashUp
            // 
            this.btnSmashUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSmashUp.Location = new System.Drawing.Point(10, 800);
            this.btnSmashUp.Name = "btnSmashUp";
            this.btnSmashUp.Size = new System.Drawing.Size(600, 70);
            this.btnSmashUp.TabIndex = 5;
            this.btnSmashUp.Text = "SMASH UP!!!";
            this.btnSmashUp.UseVisualStyleBackColor = true;
            this.btnSmashUp.Visible = false;
            this.btnSmashUp.Click += new System.EventHandler(this.btnSmashUp_Click);
            // 
            // tabsLists
            // 
            this.tabsLists.Controls.Add(this.tabSets);
            this.tabsLists.Controls.Add(this.tabFactions);
            this.tabsLists.Controls.Add(this.tabLocks);
            this.tabsLists.Location = new System.Drawing.Point(10, 235);
            this.tabsLists.Name = "tabsLists";
            this.tabsLists.SelectedIndex = 0;
            this.tabsLists.Size = new System.Drawing.Size(600, 550);
            this.tabsLists.TabIndex = 6;
            this.tabsLists.Visible = false;
            this.tabsLists.SelectedIndexChanged += new System.EventHandler(this.tabsLists_SelectedIndexChanged);
            // 
            // tabSets
            // 
            this.tabSets.Controls.Add(this.checklistSets);
            this.tabSets.Location = new System.Drawing.Point(8, 39);
            this.tabSets.Name = "tabSets";
            this.tabSets.Padding = new System.Windows.Forms.Padding(3);
            this.tabSets.Size = new System.Drawing.Size(584, 503);
            this.tabSets.TabIndex = 0;
            this.tabSets.Text = "Sets";
            this.tabSets.UseVisualStyleBackColor = true;
            // 
            // tabFactions
            // 
            this.tabFactions.Controls.Add(this.checklistFactions);
            this.tabFactions.Location = new System.Drawing.Point(8, 39);
            this.tabFactions.Name = "tabFactions";
            this.tabFactions.Padding = new System.Windows.Forms.Padding(3);
            this.tabFactions.Size = new System.Drawing.Size(584, 503);
            this.tabFactions.TabIndex = 2;
            this.tabFactions.Text = "Factions";
            this.tabFactions.UseVisualStyleBackColor = true;
            // 
            // checklistFactions
            // 
            this.checklistFactions.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checklistFactions.FormattingEnabled = true;
            this.checklistFactions.Location = new System.Drawing.Point(0, 0);
            this.checklistFactions.Name = "checklistFactions";
            this.checklistFactions.Size = new System.Drawing.Size(584, 578);
            this.checklistFactions.TabIndex = 3;
            // 
            // tabLocks
            // 
            this.tabLocks.Controls.Add(this.checklistLocks);
            this.tabLocks.Location = new System.Drawing.Point(8, 39);
            this.tabLocks.Name = "tabLocks";
            this.tabLocks.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocks.Size = new System.Drawing.Size(584, 503);
            this.tabLocks.TabIndex = 1;
            this.tabLocks.Text = "Locks";
            this.tabLocks.UseVisualStyleBackColor = true;
            // 
            // checklistLocks
            // 
            this.checklistLocks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checklistLocks.FormattingEnabled = true;
            this.checklistLocks.Location = new System.Drawing.Point(0, 0);
            this.checklistLocks.Name = "checklistLocks";
            this.checklistLocks.Size = new System.Drawing.Size(584, 578);
            this.checklistLocks.TabIndex = 2;
            // 
            // cbFactionPool
            // 
            this.cbFactionPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFactionPool.FormattingEnabled = true;
            this.cbFactionPool.Location = new System.Drawing.Point(250, 675);
            this.cbFactionPool.Name = "cbFactionPool";
            this.cbFactionPool.Size = new System.Drawing.Size(360, 45);
            this.cbFactionPool.TabIndex = 13;
            this.cbFactionPool.Visible = false;
            // 
            // tbFactionPool
            // 
            this.tbFactionPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFactionPool.Location = new System.Drawing.Point(10, 675);
            this.tbFactionPool.Name = "tbFactionPool";
            this.tbFactionPool.ReadOnly = true;
            this.tbFactionPool.Size = new System.Drawing.Size(210, 44);
            this.tbFactionPool.TabIndex = 12;
            this.tbFactionPool.Text = "Add Faction :";
            this.tbFactionPool.Visible = false;
            // 
            // tvPlayers
            // 
            this.tvPlayers.Location = new System.Drawing.Point(10, 10);
            this.tvPlayers.Name = "tvPlayers";
            this.tvPlayers.Size = new System.Drawing.Size(600, 600);
            this.tvPlayers.TabIndex = 12;
            this.tvPlayers.Visible = false;
            // 
            // tbSelectionNote
            // 
            this.tbSelectionNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelectionNote.Location = new System.Drawing.Point(10, 620);
            this.tbSelectionNote.Name = "tbSelectionNote";
            this.tbSelectionNote.ReadOnly = true;
            this.tbSelectionNote.Size = new System.Drawing.Size(600, 44);
            this.tbSelectionNote.TabIndex = 4;
            this.tbSelectionNote.Visible = false;
            // 
            // cbPlayerCount
            // 
            this.cbPlayerCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlayerCount.FormattingEnabled = true;
            this.cbPlayerCount.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.cbPlayerCount.Location = new System.Drawing.Point(250, 10);
            this.cbPlayerCount.Name = "cbPlayerCount";
            this.cbPlayerCount.Size = new System.Drawing.Size(360, 45);
            this.cbPlayerCount.TabIndex = 7;
            this.cbPlayerCount.Visible = false;
            // 
            // tbPlayerCount
            // 
            this.tbPlayerCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPlayerCount.Location = new System.Drawing.Point(10, 10);
            this.tbPlayerCount.Name = "tbPlayerCount";
            this.tbPlayerCount.ReadOnly = true;
            this.tbPlayerCount.Size = new System.Drawing.Size(210, 44);
            this.tbPlayerCount.TabIndex = 8;
            this.tbPlayerCount.Text = "Player Count :";
            this.tbPlayerCount.Visible = false;
            // 
            // tbGameMode
            // 
            this.tbGameMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGameMode.Location = new System.Drawing.Point(10, 65);
            this.tbGameMode.Name = "tbGameMode";
            this.tbGameMode.ReadOnly = true;
            this.tbGameMode.Size = new System.Drawing.Size(210, 44);
            this.tbGameMode.TabIndex = 9;
            this.tbGameMode.Text = "Game Mode :";
            this.tbGameMode.Visible = false;
            // 
            // cbGameMode
            // 
            this.cbGameMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGameMode.FormattingEnabled = true;
            this.cbGameMode.Location = new System.Drawing.Point(250, 65);
            this.cbGameMode.Name = "cbGameMode";
            this.cbGameMode.Size = new System.Drawing.Size(360, 45);
            this.cbGameMode.TabIndex = 10;
            this.cbGameMode.Visible = false;
            this.cbGameMode.SelectedIndexChanged += new System.EventHandler(this.cbGameMode_SelectedIndexChanged);
            // 
            // tbGameModeDescription
            // 
            this.tbGameModeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGameModeDescription.Location = new System.Drawing.Point(10, 125);
            this.tbGameModeDescription.Multiline = true;
            this.tbGameModeDescription.Name = "tbGameModeDescription";
            this.tbGameModeDescription.ReadOnly = true;
            this.tbGameModeDescription.Size = new System.Drawing.Size(600, 100);
            this.tbGameModeDescription.TabIndex = 11;
            this.tbGameModeDescription.Visible = false;
            // 
            // btnDraft
            // 
            this.btnDraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraft.Location = new System.Drawing.Point(10, 750);
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(300, 70);
            this.btnDraft.TabIndex = 12;
            this.btnDraft.Text = "Draft!";
            this.btnDraft.UseVisualStyleBackColor = true;
            this.btnDraft.Visible = false;
            this.btnDraft.Click += new System.EventHandler(this.btnDraft_Click);
            // 
            // tbSwap
            // 
            this.tbSwap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSwap.Location = new System.Drawing.Point(10, 730);
            this.tbSwap.Name = "tbSwap";
            this.tbSwap.ReadOnly = true;
            this.tbSwap.Size = new System.Drawing.Size(210, 44);
            this.tbSwap.TabIndex = 14;
            this.tbSwap.Text = "Drop Faction :";
            this.tbSwap.Visible = false;
            // 
            // cbSwap
            // 
            this.cbSwap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSwap.FormattingEnabled = true;
            this.cbSwap.Location = new System.Drawing.Point(250, 730);
            this.cbSwap.Name = "cbSwap";
            this.cbSwap.Size = new System.Drawing.Size(360, 45);
            this.cbSwap.TabIndex = 15;
            this.cbSwap.Visible = false;
            // 
            // btnSwap
            // 
            this.btnSwap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwap.Location = new System.Drawing.Point(10, 800);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(300, 70);
            this.btnSwap.TabIndex = 16;
            this.btnSwap.Text = "Swap!";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Visible = false;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // cbDrop
            // 
            this.cbDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDrop.FormattingEnabled = true;
            this.cbDrop.Location = new System.Drawing.Point(10, 680);
            this.cbDrop.Name = "cbDrop";
            this.cbDrop.Size = new System.Drawing.Size(600, 45);
            this.cbDrop.TabIndex = 17;
            this.cbDrop.Visible = false;
            // 
            // btnDrop
            // 
            this.btnDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrop.Location = new System.Drawing.Point(10, 750);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(600, 70);
            this.btnDrop.TabIndex = 18;
            this.btnDrop.Text = "Drop";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Visible = false;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.Location = new System.Drawing.Point(310, 750);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(300, 70);
            this.btnRandom.TabIndex = 19;
            this.btnRandom.Text = "Random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Visible = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnPass
            // 
            this.btnPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPass.Location = new System.Drawing.Point(310, 800);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(300, 70);
            this.btnPass.TabIndex = 20;
            this.btnPass.Text = "Pass";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Visible = false;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(10, 630);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(600, 70);
            this.btnReturn.TabIndex = 21;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Visible = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 879);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnDrop);
            this.Controls.Add(this.cbDrop);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.cbSwap);
            this.Controls.Add(this.tbSwap);
            this.Controls.Add(this.btnDraft);
            this.Controls.Add(this.btnSmashUp);
            this.Controls.Add(this.tbGameModeDescription);
            this.Controls.Add(this.cbGameMode);
            this.Controls.Add(this.tbGameMode);
            this.Controls.Add(this.tbPlayerCount);
            this.Controls.Add(this.cbPlayerCount);
            this.Controls.Add(this.tabsLists);
            this.Controls.Add(this.tvPlayers);
            this.Controls.Add(this.tbSelectionNote);
            this.Controls.Add(this.tbFactionPool);
            this.Controls.Add(this.cbFactionPool);
            this.MaximumSize = new System.Drawing.Size(800, 2000);
            this.MinimumSize = new System.Drawing.Size(150, 500);
            this.Name = "MainForm";
            this.Text = "Smash Up Faction Randomizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabsLists.ResumeLayout(false);
            this.tabSets.ResumeLayout(false);
            this.tabFactions.ResumeLayout(false);
            this.tabLocks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checklistSets;
        private System.Windows.Forms.Button btnSmashUp;
        private System.Windows.Forms.TabControl tabsLists;
        private System.Windows.Forms.TabPage tabSets;
        private System.Windows.Forms.TabPage tabLocks;
        private System.Windows.Forms.CheckedListBox checklistLocks;
        private System.Windows.Forms.TabPage tabFactions;
        private System.Windows.Forms.CheckedListBox checklistFactions;
        private System.Windows.Forms.ComboBox cbPlayerCount;
        private System.Windows.Forms.TextBox tbPlayerCount;
        private System.Windows.Forms.TextBox tbGameMode;
        private System.Windows.Forms.ComboBox cbGameMode;
        private System.Windows.Forms.TextBox tbGameModeDescription;
        private System.Windows.Forms.TreeView tvPlayers;
        private System.Windows.Forms.ComboBox cbFactionPool;
        private System.Windows.Forms.TextBox tbFactionPool;
        private System.Windows.Forms.TextBox tbSelectionNote;
        private System.Windows.Forms.Button btnDraft;
        private System.Windows.Forms.TextBox tbSwap;
        private System.Windows.Forms.ComboBox cbSwap;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.ComboBox cbDrop;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Button btnReturn;
    }
}

