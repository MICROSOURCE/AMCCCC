using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMCCCC.Helper
{
    public class Utils
    {
        #region variable

        private static Dictionary<object, object> _Dict;
        private static IDictionary<object, object> lst;
        private static string _message;

        #endregion

        public static void ShowMessage(string type, string MESSAGE)
        {
            MESSAGE = MESSAGE;//.Replace(Constants.vbCr, "").Replace(Constants.vbLf, "").Replace("'", "").Replace("\"", "");
                              // var page = new Page();
                              //page = HttpContext.Current.CurrentHandler;
            //Page.ClientScript.RegisterStartupScript(GetType(), "message", "Message()", true);
           // Page.ClientScript.RegisterStartupScript(GetType(), "key", "ShowMessage('" + type + "','" + MESSAGE + "');", true);
        }
        #region "!-- FillCombo--!"
        public static void FillCombo(DropDownList pCmb, string flag, string incExp)
        {
            lst = GetComboSql(flag, incExp);
            pCmb.DataSource = lst;
            pCmb.DataValueField = "Key";
            pCmb.DataTextField = "Value";
            pCmb.DataBind();
            pCmb.Items.Insert(0, "--SELECT--");
            pCmb.Items.FindByText("--SELECT--").Selected = true;
        }
        #endregion
        #region getComboSql
        public static IDictionary<object, object> GetComboSql(string Flag, string IncExp = null)
        {
            using (var ObjBll = new CommonDBAccess())
            {
                // ' Bind Table as per Query
                _Dict = new Dictionary<object, object>();
                _Dict.Clear();
                var records = ObjBll.GetDataTableForComboStr(Flag, IncExp, "").AsEnumerable();
                foreach (DataRow row in records)
                {
                    _Dict.Add(row[0].ToString(), row[1].ToString());
                }
            }
            // Return Filled Dictionary
            return _Dict;
        }
        #endregion
        #region "!-- Encryption() --!"
        public static string Encryption(string clearText)
        {
            string EncryptionKey = "MICITS";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        #endregion
        #region "!-- Decryption() --!"
        public static string Decryption(string cipherText)
        {
            string EncryptionKey = "MICITS";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion
        #region "!---GetStringValue()---!"
        public static string[] GetStringValue(string Str)
        {
            int b = Str.Length;
            int cnt = 0;
            string ch = "=";
            foreach (char c in Str)
            {
                if (c == Convert.ToChar(ch))
                {
                    cnt += 1;
                }
            }
            cnt = cnt - 1;
            var result = new string[cnt + 1];
            for (var i = 0; i < cnt; i++)
            {
                int z = Str.IndexOf("=") + 1;
                int x = Str.IndexOf("&");
                if (x == -1)
                {
                    x = b;
                }
                int y = x - z;
                result[i] = Str.Substring(z, y);
                if (x == b)
                {
                    b = 0;
                }
                else
                {
                    Str = Str.Remove(0, x + 1);
                    b = Str.Length;
                }
            }
            return result;
        }
        #endregion
    }
}