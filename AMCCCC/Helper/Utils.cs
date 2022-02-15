﻿using BusinessLogicLayer;
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
        #region Variable


        private static Dictionary<object, object> _Dict;
        private static IDictionary<object, object> lst;
        private static string _message;
        public static string Message;
        public static DataTable _DT;

        #endregion

        public static void ShowMessage(string TYPE, string MESSAGE)
        {
            
        }

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

        public static bool verifyCheckDigit(string TenementNo)
        {
            int i = 0;
            string strChar, checkDigit = string.Empty;
            string TeneCheckDigit = TenementNo.Substring(14, 1);
            int multi, total = default;
            double remaidner;
            while (i < 14)
            {
                strChar = TenementNo.Substring(i, 1);
                multi = (int)Math.Round(Convert.ToDouble(strChar) * (16 - (i + 1)));
                total = total + multi;
                i = i + 1;
            }

            remaidner = total % 23;
            remaidner = 23d - remaidner;
            if (remaidner >= 1d & remaidner <= 22d)
            {
              //  checkDigit = Convert.ToString(Strings.Chr((int)Math.Round(64d + remaidner)));
            }
            else
            {
                checkDigit = "9";
            }

            if ((TeneCheckDigit ?? "") == (checkDigit ?? ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}