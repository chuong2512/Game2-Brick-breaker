// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("n2z8FJqpwOwiQKzIDAbq8hqTNXiOpe56dE4YFyJNtn9YB4JB/n49nJclpoWXqqGujSHvIVCqpqamoqekJtQ3eMc9B/xpVmB76FtEZoxfp3jaEhOuPmSvi4VrZ6BxukQlwhgHNHzugoZO3kCoMmwUVSyQAlhYKAPXCtR86QvJvLTvH2lo2R8G//x2961PTwPTlLM23aWq5J38OxD4d/JnQQ6Mf3nbkVpwqbcRDtxJyKFeeKi3cGOb4C2iOQ1jQBUa0hf+xPtQPNpvOSLkt9N5SeP77I7jlmO3pLWdGiWmqKeXJaatpSWmpqdnUDX9WWTrDaMVSEfToIrC10/iAjae+XuSK4tNm4zzejhZUklfRg24Pszf0u/kfA3M1AZWvVvZfKWkpqem");
        private static int[] order = new int[] { 2,3,2,7,6,6,10,12,8,11,11,12,12,13,14 };
        private static int key = 167;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
