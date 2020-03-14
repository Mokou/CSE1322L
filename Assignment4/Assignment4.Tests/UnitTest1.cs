using System;
using Xunit;


namespace Assignment4.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Base8Conversion()
        {
            int n1 = 753, numSystemToConvertTo = 8;
            String convertedNumber = Assignment4.BaseConversion.RecursiveBaseConversion(n1, numSystemToConvertTo);
            Assert.Equal("1361", convertedNumber);
        }
        [Fact]
        public void Test_Base16Conversion()
        {
            int n1 = 753, numSystemToConvertTo = 16;
            String convertedNumber = Assignment4.BaseConversion.RecursiveBaseConversion(n1, numSystemToConvertTo);
            Assert.Equal("2F1", convertedNumber);
        }
        [Fact]
        public void Test_Base20Conversion()
        {
            int n1 = 9098, numSystemToConvertTo = 20;
            String convertedNumber = Assignment4.BaseConversion.RecursiveBaseConversion(n1, numSystemToConvertTo);
            Assert.Equal("12EI", convertedNumber);
        }
        [Fact]
        public void Test_Base2Conversion()
        {
            int n1 = 692, numSystemToConvertTo = 2;
            String convertedNumber = Assignment4.BaseConversion.RecursiveBaseConversion(n1, numSystemToConvertTo);
            Assert.Equal("1010110100", convertedNumber);
        }
        [Fact]
        public void Test_Base8Conversion_2()
        {
            int n1 = 200, numSystemToConvertTo = 8;
            String convertedNumber = Assignment4.BaseConversion.RecursiveBaseConversion(n1, numSystemToConvertTo);
            Assert.Equal("310", convertedNumber);
        }
    }
}
