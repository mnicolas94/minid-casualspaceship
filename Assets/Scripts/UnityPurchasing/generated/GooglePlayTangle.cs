// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("JLqV8OquWHFtHXLoXFBd+OHeT7+BOHyEEt1ermLiWjxlQvektmf1MROQnpGhE5CbkxOQkJEGQTwSyCdk5qUP/h+uUjRyTJWclqMFTQirU3vdHL/Y8vTcAb7waKzpM3rVZI5nR4ABGU5NHXKSwpPlDPtL9/jm4xl/AcpglNclMNAFNatCh82PLXk+zNZg1iIp9lRtxk2zg+RZiTf8ttlN3he6f8zJJplJbF2nkPFgeMsC47M/UrVc/pY7bxBhGMQsmuJ+HhJ3b+VKJMiiLbrz1BAO0idxXIXCKVSGkL4+z0RAhyZfG++DyFbLv+A+HUYSoROQs6Gcl5i7F9kXZpyQkJCUkZIdoZMpnyvIszOJ4gPaxUrpfc5quKOdyJOc57kFEJOSkJGQ");
        private static int[] order = new int[] { 5,10,10,10,13,7,11,11,8,10,10,13,13,13,14 };
        private static int key = 145;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
