using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RobloxMultiLauncher
{
    public partial class MainForm : Form
    {
        private const string MutexName = "ROBLOX_singletonMutex";
        private Mutex? mutex;
        private bool isActivated = false;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "이 프로그램은 Roblox의 다중 실행을 도와주는 도구입니다.\n\n" +
                "이 프로그램의 사용으로 인해 발생하는 모든 문제(계정 정지 등)에 대한 책임은 사용자 본인에게 있습니다.\n\n" +
                "제작자: Dangel",
                "주의사항",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            bool createdNew;
            mutex = new Mutex(true, MutexName, out createdNew);

            if (!createdNew)
            {
                var result = MessageBox.Show(
                    "이미 다른 Roblox 또는 세션 언락커가 실행 중입니다.\n\n" +
                    "모든 Roblox 프로세스를 종료하시겠습니까?", 
                    "오류", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Error);
                
                if (result == DialogResult.Yes)
                {
                    RunKillRobloxBat();
                    
                    // Try to create mutex again after killing processes
                    Thread.Sleep(2000);
                    mutex = new Mutex(true, MutexName, out createdNew);
                    
                    if (!createdNew)
                    {
                        MessageBox.Show("프로세스 종료 후에도 뮤텍스를 생성할 수 없습니다.\n프로그램을 종료합니다.", 
                            "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("프로세스가 종료되었습니다.\n이제 정상적으로 사용할 수 있습니다.", 
                            "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnActivate_Click(object? sender, EventArgs e)
        {
            this.TopMost = false;
            this.btnActivate.Enabled = false;
            this.btnActivate.Text = "활성화 진행 중...";

            Thread unlockThread = new Thread(PerformUnlock);
            unlockThread.IsBackground = true;
            unlockThread.Start();
        }

        private void PerformUnlock()
        {
            for (int i = 0; i <= 100; i++)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    progressBar.Value = i;
                });
                Thread.Sleep(15);
            }

            this.Invoke((MethodInvoker)delegate
            {
                isActivated = true;
                lblStatus.Text = "활성화됨";
                lblStatus.ForeColor = Color.FromArgb(138, 221, 122);
                btnActivate.Visible = false;
                btnDeactivate.Visible = true;
                btnDeactivate.Enabled = true;
                MessageBox.Show("세션이 활성화되었습니다.\n이제 Roblox를 여러 번 실행할 수 있습니다.", 
                    "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void btnDeactivate_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "활성화를 종료하시겠습니까?\n\n종료하면 더 이상 Roblox를 다중 실행할 수 없습니다.\n실행 중인 모든 Roblox 프로세스도 함께 종료됩니다.",
                "확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Kill all Roblox processes using the bat file
                RunKillRobloxBat();

                isActivated = false;
                lblStatus.Text = "비활성화됨";
                lblStatus.ForeColor = Color.FromArgb(200, 200, 200);
                btnDeactivate.Visible = false;
                btnActivate.Visible = true;
                btnActivate.Enabled = true;
                btnActivate.Text = "활성화 시작";
                progressBar.Value = 0;

                MessageBox.Show("활성화가 종료되었습니다.\n모든 Roblox 프로세스가 종료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void KillRobloxProcesses()
        {
            try
            {
                var processNames = new[] { "RobloxPlayerBeta", "RobloxPlayerLauncher", "RobloxStudioBeta", "RobloxCrashHandler" };
                
                foreach (var processName in processNames)
                {
                    var processes = System.Diagnostics.Process.GetProcessesByName(processName);
                    foreach (var process in processes)
                    {
                        try
                        {
                            process.Kill();
                            process.WaitForExit(1000);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }

        private void RunKillRobloxBat()
        {
            try
            {
                string batPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kill_roblox.bat");
                
                // If kill_roblox.bat doesn't exist in the current directory, try parent directory
                if (!System.IO.File.Exists(batPath))
                {
                    string? parentDir = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.FullName;
                    if (parentDir != null)
                    {
                        batPath = System.IO.Path.Combine(parentDir, "kill_roblox.bat");
                    }
                }

                if (System.IO.File.Exists(batPath))
                {
                    var processInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = batPath,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                    };

                    var process = System.Diagnostics.Process.Start(processInfo);
                    if (process != null)
                    {
                        process.WaitForExit(10000); // Wait max 10 seconds
                    }
                }
                else
                {
                    // Fallback to manual process killing if bat file not found
                    KillRobloxProcesses();
                    
                    // Also kill RBXInstance processes
                    var rbxProcesses = System.Diagnostics.Process.GetProcessesByName("RBXInstance");
                    foreach (var process in rbxProcesses)
                    {
                        try
                        {
                            if (process.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                            {
                                process.Kill();
                                process.WaitForExit(1000);
                            }
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"프로세스 종료 중 오류가 발생했습니다: {ex.Message}", 
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mutex != null)
                {
                    mutex.Dispose();
                    mutex = null;
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
