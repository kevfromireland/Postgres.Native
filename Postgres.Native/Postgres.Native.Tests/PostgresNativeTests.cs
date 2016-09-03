using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Postgres.Native.Tests
{
    [TestFixture]
    public class PostgresBinariesExtractorTests
    {
        [Test]
        public async Task CanExtractPostgres()
        {
            var pgLocation = await new PostgresBinariesExtractor().ExtractToTemporaryPath();

            Assert.That(File.Exists(Path.Combine(pgLocation.FullName, "pgsql", "bin", "postgres.exe")),
                "Unable to find postgres executable after extracting");
        }
    }
}
