using System.Security.Cryptography;
using System.Text;

namespace SocialNetwork.Data.Helpers
{
    public class HelpFunctions
    {
        public static string HashPW(string PW)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(PW);
            SHA256 mySHA256 = SHA256.Create();

            byte[] hash = mySHA256.ComputeHash(bytes);
            string res = string.Empty;
            for (int i = 0; i < hash.Length; i++)
            {
                string add = Convert.ToString(hash[i], 16);
                if (add.Length < 2)
                {
                    add = "0" + add;
                }

                res += add;
            }

            return res.ToUpper();
        }

        public static bool VerifyPassword(string PW, string PWHash)
        {
            if (PWHash == HashPW(PW)) return true;
            else return false;
        }
    }
}
