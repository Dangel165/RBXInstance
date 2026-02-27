using System.Drawing;
using System.Windows.Forms;

namespace RobloxMultiLauncher
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer? components = null;
        private Panel? headerPanel;
        private Label? lblTitle;
        private Label? lblDescription;
        private Button? btnActivate;
        private Button? btnDeactivate;
        private ProgressBar? progressBar;
        private Label? lblStatus;
        private Label? lblCredit;

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblCredit = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            
            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(500, 70);
            this.headerPanel.TabIndex = 0;
            
            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "RBX Instance";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // lblDescription
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblDescription.Location = new System.Drawing.Point(30, 90);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(440, 80);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "아래 버튼을 눌러 Roblox 세션 잠금을 해제하세요.\n활성화가 완료된 후, 여러 개의 Roblox 클라이언트를\n동시에 실행할 수 있습니다.";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            
            // btnActivate
            this.btnActivate.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnActivate.FlatAppearance.BorderSize = 0;
            this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnActivate.ForeColor = System.Drawing.Color.White;
            this.btnActivate.Location = new System.Drawing.Point(100, 190);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(300, 50);
            this.btnActivate.TabIndex = 2;
            this.btnActivate.Text = "활성화 시작";
            this.btnActivate.UseVisualStyleBackColor = false;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            this.btnActivate.MouseEnter += new System.EventHandler((s, e) => { btnActivate.BackColor = System.Drawing.Color.FromArgb(102, 187, 106); });
            this.btnActivate.MouseLeave += new System.EventHandler((s, e) => { btnActivate.BackColor = System.Drawing.Color.FromArgb(76, 175, 80); });
            
            // btnDeactivate
            this.btnDeactivate.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDeactivate.FlatAppearance.BorderSize = 0;
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeactivate.ForeColor = System.Drawing.Color.White;
            this.btnDeactivate.Location = new System.Drawing.Point(100, 190);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(300, 50);
            this.btnDeactivate.TabIndex = 3;
            this.btnDeactivate.Text = "활성화 종료";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Visible = false;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            this.btnDeactivate.MouseEnter += new System.EventHandler((s, e) => { btnDeactivate.BackColor = System.Drawing.Color.FromArgb(229, 57, 53); });
            this.btnDeactivate.MouseLeave += new System.EventHandler((s, e) => { btnDeactivate.BackColor = System.Drawing.Color.FromArgb(244, 67, 54); });
            
            // lblStatus
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblStatus.Location = new System.Drawing.Point(30, 260);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(440, 25);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "현재 상태: 대기 중";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // progressBar
            this.progressBar.Location = new System.Drawing.Point(50, 300);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 25);
            this.progressBar.TabIndex = 5;
            
            // lblCredit
            this.lblCredit.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCredit.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lblCredit.Location = new System.Drawing.Point(30, 340);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(440, 20);
            this.lblCredit.TabIndex = 6;
            this.lblCredit.Text = "Developed by Dangel";
            this.lblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.ClientSize = new System.Drawing.Size(500, 380);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RBX Instance";
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
