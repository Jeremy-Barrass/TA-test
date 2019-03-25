using NUnit.Framework;

namespace FileComparison.Test
{
    [TestFixture]
    public class FileReaderTests
    {
        private const string TEST_FILE = "../../Helpers/dummy.txt";

        [Test]
        public void LoadFile_WhenPassedAFilePath_ItReturnsTheContents()
        {
            // Arrange
            var reader = new FileReader();
            var expectedResult = "{ \"Foo\": \"Bar\" }";

            // Act
            var result = reader.LoadFile(TEST_FILE);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}