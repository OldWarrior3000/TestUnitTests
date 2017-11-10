using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitTests
{
    public class FileProcess
    {
        public bool FileExists(string fileName)
        {
            return GetFileInfo(fileName).Exists;
        }

        public FileInfo GetFileInfo(string fileName)
        {
            FileInfo fi;
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            try
            {
                fi = new FileInfo(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return fi;
        }
    }
}
