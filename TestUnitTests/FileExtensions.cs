using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System.IO
{
    public static class FileExtensions
    {
        public static bool TryDelete(this FileInfo fileInfo)
        {
            try
            {
                fileInfo.Delete();
            }catch(Exception)
            {
                return false;
            }
            return true;
        } 
    }
}
