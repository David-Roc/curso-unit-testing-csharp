using Microsoft.Extensions.Logging;

namespace StringManipulation.Test;

public class StringOperationsTest
{
    //[Fact(Skip ="Ya no es funcuinal, ticket-01")]
    [Fact]
    public void ConcatenateStrings()
    {
        string str1 = "Hello";
        string str2 = "World";
        StringOperations stringOperationsTest = new StringOperations();

        string result = stringOperationsTest.ConcatenateStrings(str1, str2);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal($"{str1} {str2}", result);
    }

    [Fact]
    public void RemoveWhitespace()
    {
        string str = "Hello World";
        StringOperations stringOperationsTest = new StringOperations();

        string result = stringOperationsTest.RemoveWhitespace(str);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(str.Replace(" ", ""), result);
    }

    [Fact]
    public void ReverseString()
    {
        string str = "Hello World";
        StringOperations stringOperationsTest = new StringOperations();

        string result = stringOperationsTest.ReverseString(str);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.NotEqual(str, result);
        Assert.Equal(new string(str.Reverse().ToArray()), result);
    }

    [Fact]
    public void IsPalindromeWhen_True()
    {
        string str = "ana";
        StringOperations stringOperationsTest = new StringOperations();

        bool? result = stringOperationsTest.IsPalindrome(str);

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_False()
    {
        string str = "Hello";
        StringOperations stringOperationsTest = new StringOperations();

        bool? result = stringOperationsTest.IsPalindrome(str);

        Assert.NotNull(result);
        Assert.False(result);
    }

    [Fact]
    public void QuantintyInWords()
    {
        string str = "Hello world";
        int quantity = 5;
        StringOperations stringOperationsTest = new StringOperations();

        string result = stringOperationsTest.QuantintyInWords(str, quantity);

        Assert.NotNull(result);
        Assert.StartsWith("cinco", result);
        Assert.Contains(str, result);
    }

    [Fact]
    public void GetStringLength()
    {
        string str = "Hello world";
        StringOperations stringOperationsTest = new StringOperations();

        int? result = stringOperationsTest.GetStringLength(str);

        Assert.NotNull(result);
        Assert.Equal(str.Length, result);
    }

    [Fact]
    public void GetStringLength_RaisesException()
    {
        string str = null;
        StringOperations stringOperationsTest = new StringOperations();


        Assert.Throws<ArgumentNullException>(() => stringOperationsTest.GetStringLength(str));
    }

    [Theory]
    [InlineData("VI", 6)]
    [InlineData("I", 1)]
    [InlineData("X", 10)]
    public void FromRomanToNumber(string romanNumber, int expected)
    {
        StringOperations stringOperationsTest = new StringOperations();

        var result = stringOperationsTest.FromRomanToNumber(romanNumber);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountOccurrences()
    {
        string str = "Hello platzi";
        char character = 'l';
        var mockLogger = new Moq.Mock<ILogger<StringOperations>>();
        StringOperations stringOperationsTest = new StringOperations(mockLogger.Object);

        var result = stringOperationsTest.CountOccurrences(str, character);

        Assert.Equal(3, result);
    }

    [Fact]
    public void ReadFile()
    {
        string fileName = "Hello_platzi.txt";
        var fileMock = new Moq.Mock<IFileReaderConector>();
        fileMock.Setup(m => m.ReadString(fileName)).Returns("Reading File");
        StringOperations stringOperationsTest = new StringOperations();

        var result = stringOperationsTest.ReadFile(fileMock.Object, fileName);

        Assert.Equal("Reading File", result);
    }

    [Fact]
    public void TruncateString()
    {
        string str = "Hello_platzi.txt";
        int maxLength = 5;
        StringOperations stringOperationsTest = new StringOperations();

        var result = stringOperationsTest.TruncateString(str, maxLength);

        Assert.Equal("Hello", result);
    }

    [Fact]
    public void TruncateString_RaisesException()
    {
        string str = "Hello_platzi.txt";
        int maxLength = 0;
        StringOperations stringOperationsTest = new StringOperations();

        Assert.Throws<ArgumentOutOfRangeException>(() => stringOperationsTest.TruncateString(str, maxLength));
    }

    [Fact]
    public void TruncateString_InputIsNull()
    {
        string str = null;
        int maxLength = 5;
        StringOperations stringOperationsTest = new StringOperations();

        var result = stringOperationsTest.TruncateString(str, maxLength);

        Assert.Null(result);
    }

    [Fact]
    public void Pluralize()
    {
        string str = "Apple";
        StringOperations stringOperationsTest = new StringOperations();

        var result = stringOperationsTest.Pluralize(str);

        Assert.Equal("Apples", result);
    }
}
