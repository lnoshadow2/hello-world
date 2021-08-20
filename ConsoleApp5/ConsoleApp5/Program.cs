using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ConsoleApp5
{
    class Program : Exception
    {
        static string labelFile_path = @"C:\Users\Administrator\Desktop\test";
        static string storage2 = @"C:\Users\Administrator\Desktop\test\pic";
        static string output2 = @"C:\Users\Administrator\Desktop\test\output";
       
        
        
        
        static void Main(string[] args)
        {
            //string testinpu = @"ffmpeg -i 1.jpg -y video.mpg";
            //string testin2 = @"explorer .";
            //string intip1 = "cd / \n";
            //string output1 = "";
            //string intip = "cd " + labelFile_path;
            string regrex = @"(.*jpg$)|(.*JPG$)|(.*BMP$)|(.*bmp$)|(.*png$)|(.*PNG$)|(.*jpeg$)";
            //string regrex2 = @".*png$";
            //string regrex3 = @".*jpgx$";
            //string testin3 = @"ffmpeg -i " + @"2.jpg" + @" -y output/video" + @"2.jpg" + @".mpg";
            //string testin4 = @"ffmpeg -i  output/video" + @"2.jpg" + ".mpg mpg/" + @"2.jpg";

            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            p.StartInfo = startInfo;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            System.IO.Directory.SetCurrentDirectory(labelFile_path);
           
            //p.StartInfo.Arguments = "/c" + testinpu;
            //p.Start();
            //testCmd(testin3, p);
            //p.Close();
            //p.Start();
            //testCmd(testin4, p);
            //p.Close();
            //Console.WriteLine(labelFile_path);
            //try
            //{

            //p.StandardInput.WriteLine(testinpu);
            //p.StandardInput.WriteLine("exit");
            //Console.WriteLine(labelFile_path);
            //output1 = p.StandardOutput.ReadToEnd();


            //}
            //catch 
            //{


            //}
            //s.WriteLine(intip);

            //p.StartInfo.UseShellExecute = false;
            listFiles(new DirectoryInfo(storage2),p,regrex);
            //listFiles2(new DirectoryInfo(output2), p);
            //Console.WriteLine(output1);
            Console.WriteLine("world");
            Console.ReadKey();
        }
        static void testCmd(Process p1,string temp1,string a) {

            p1.Start();
            //p.StartInfo.Arguments = "/c" + @"ffmpeg -i pic/" + temp + @" -y -vb 1000k -r 30  output/" + temp + @".mpg"+ @"&& ffmpeg -i  output/" + temp + @".mpg -y mpg/" + temp+"&& echo hello";;
            //p.Start();
            p1.StandardInput.WriteLine(@"ffmpeg -i pic/""" + temp1 + @""" -y -vb 8000k -r 30  output/""" + temp1 + @".mpg""" + @" && echo hello");
            string linetem = null;
            while (p1.StandardOutput.ReadLine() != "hello")
            {
                linetem += "a";
            }
            Console.WriteLine("执行完成操作 " + temp1 + linetem);
            p1.Close();
            p1.Start();
            p1.StandardInput.WriteLine(@"ffmpeg -i  output/""" + temp1 + @""".mpg -y -f image2 mpg/""" + a + @".jpg""" + @"&& echo hello2");
            string linetem2 = null;
            while (p1.StandardOutput.ReadLine() != "hello2")
            {
                linetem2 += "b";
            }
            Console.WriteLine("执行完成操作2 " + temp1 + linetem2);
            p1.Close();
        }

        static void listFiles(FileSystemInfo info,Process p,string reg) {
            bool b;
            string temp;
            FileInfo file;
            string[] a1;
            string a2;
            if (!info.Exists) return;
            DirectoryInfo dir = info as DirectoryInfo;
            if (dir == null) return;
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i< files.Length; i++) {
                 file = files[i] as FileInfo;
                if (file != null) {
                    //Console.WriteLine(file.Name);
                    temp = file.Name;
                    //a1 = temp.Split('.');
                    //a2 = a1[0];
                    a1 = temp.Split('.');
                    a2 = a1[0];
                    try
                    {
                        b = Regex.IsMatch(temp, reg);
                        if (b)
                        {
                            //Console.WriteLine(temp);
                            Console.WriteLine("开始操作 "+temp);
                            testCmd(p, temp,a2);


                        }
                    }
                    catch
                    {
                        Console.WriteLine("正则匹配出错");
                    }
                    finally {
                        //p.Kill();
                        
                    }


                }
            }
        }

        static void listFiles2(FileSystemInfo info, Process p)
        {
            //bool b;
            string temp;
            FileInfo file;
            string[] a1;
            string a2;
            if (!info.Exists) return;
            DirectoryInfo dir = info as DirectoryInfo;
            if (dir == null) return;
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                file = files[i] as FileInfo;
                if (file != null)
                {
                    
                    temp = file.Name;
                    a1 = temp.Split('.');
                    a2 = a1[0];
                    Console.WriteLine(a2);

                    try
                    {

                            //Console.WriteLine(temp);

                            //p.StartInfo.Arguments = "/c" + @"ffmpeg -i " + temp + @" -y -vb 1000k -r 30  output/video" + temp + @".mpg";
                            //p.Start();
                            //testCmd(@"ffmpeg -i " + temp + @" -y -vb 1000k -r 30  output/video" + temp + @".mpg",p);
                            //p.WaitForExit(1000);
                            //p.WaitForExit();
                            //p.Close();
                            p.StartInfo.Arguments = "/c" + @"ffmpeg -i  output/" + temp + @" -y mpg/" + a2 + ".jpg";
                            p.Start();
                            //testCmd(@"ffmpeg -i  output/video" + temp + @".mpg -y mpg/" + a2+".jpg", p);
                            //testCmd(@"ffmpeg -i  output/video" + temp + @".mpg -y mpg/" + temp, p);
                            //p.WaitForExit();
                            //Console.WriteLine(a2);
                            p.WaitForExit(100);
                            p.Close();
                            //testCmd(@"ffmpeg -i video.mpg output/" + "image%d.jpg");

                    }
                    catch
                    {
                        Console.WriteLine("出错");
                    }


                }
            }
        }
    }
}
