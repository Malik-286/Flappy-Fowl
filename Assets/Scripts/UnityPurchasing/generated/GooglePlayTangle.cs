// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("mhkXGCiaGRIamhkZGIwHNAlUDLqPRiXSQJAOyJl5mXGfHyfYEV8vEpD3Pd88xMQb5PArJU0aZKiq0CuvKJoZOigVHhEynlCe7xUZGRkdGBuxogX3OzB3TS9vKft8N1OKN3CIsvDbwCpCdHSgtcPE977Cb8udAZAAZ6DWO6x0DhifF2ewrka1uqn3STKgAVnEc7U+kYGwl0MEdewTAJrRvEScSzsKFkrSImnlagCWenZ0sewEY3Z287E+P+UL4NH+PSob7ejNa3rHSa88mWOKE/Y92lf1Yzejn59i3QYBKMv/xPoTzINhdSbnhDT42kQYpeDf52iYrh+raza/Nb1f91yuDVqSpzyPkELjJzVRFkypA7lXoeMeaiBN28BNaBL5mxobGRgZ");
        private static int[] order = new int[] { 1,3,10,3,9,8,10,12,10,13,13,11,13,13,14 };
        private static int key = 24;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
