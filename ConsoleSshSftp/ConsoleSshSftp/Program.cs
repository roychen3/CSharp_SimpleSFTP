using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SshDotNet;

namespace ConsoleSshSftp
{
    class Program
    {
        static void Main(string[] args)
        {
            string sftpIp = "127.0.0.1";
            string sftpProt = "21";
            string sftpAccount = "account";
            string sftpPassword = "password";

            string localFile = @"D:\your file*.txt";
            string uploadSftpPath = "/SFTP/Folder/";
            string uploadSftpNewName = "upload.txt";

            string sftpMoveFile = "/SFTP/Folder/upload.txt";
            string sftpMoveNewPath = "/SFTP/Folder/New Folder/";
            string sftpMoveNewFileName = "move.txt";

            string localPath = @"D:\";
            string sftpDownloadFile = "/SFTP/Folder/New Folder/move.txt";
            string sftpDownloadNewFileNme = "download.txt";

            string deleteFile = "/SFTP/Folder/New Folder/move.txt";

            try
            {
                SshSftp sftp = new SshSftp(sftpIp, sftpProt, sftpAccount, sftpPassword);

                sftp.Upload(localFile, uploadSftpPath, uploadSftpNewName);
                var fileList = sftp.GetFileList(uploadSftpPath, "*a.*f*d.cs*");

                sftp.Move(sftpMoveFile, sftpMoveNewPath, sftpMoveNewFileName, true);
                fileList = sftp.GetFileList(sftpMoveNewPath);
                fileList = sftp.GetFileList(uploadSftpPath);

                sftp.Download(localPath, sftpDownloadFile, sftpDownloadNewFileNme);

                sftp.Delete(deleteFile);
                fileList = sftp.GetFileList(sftpMoveNewPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}