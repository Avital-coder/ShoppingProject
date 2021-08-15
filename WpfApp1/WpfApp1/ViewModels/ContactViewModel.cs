using System.Diagnostics;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels
{
    class ContactViewModel : BaseViewModel
    {
        public ICommand Calling
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    try
                    {
                        Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        cmd.StandardInput.WriteLine("cmd /C start tel:000-000-0000");
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();
                    }
                    catch
                    {

                    }
                });
            }
        }
        public ICommand Emailing
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    try
                    {
                        Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        cmd.StandardInput.WriteLine("cmd /C start mailto:tal.segal200@gmail.com");
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();
                    }
                    catch
                    {

                    }
                });
            }
        }
     
        
    }
}
