using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading.Tasks;

namespace Postgres.Native
{
    public class PostgresBinariesExtractor
    {
        public Task<DirectoryInfo> ExtractToTemporaryPath()
        {
            var pgAssembly = Assembly.GetExecutingAssembly();

            var pgStream = pgAssembly.GetManifestResourceStream("Postgres.Native.postgresql-9.5.4-1-windows-x64-binaries.zip");

            if (pgStream == null)
            {
                throw new InvalidOperationException("Unable to find expected binary embedded resource");
            }

            var temp = Path.GetTempPath();
            var pgDestination = Path.Combine(temp, Path.GetRandomFileName());

            var zipArchive = new ZipArchive(pgStream);
            zipArchive.ExtractToDirectory(pgDestination);

            var pgBinaryLocation = Path.Combine(pgDestination, "pgsql");

            return Task.FromResult(new DirectoryInfo(pgBinaryLocation));
        }
    }
}
