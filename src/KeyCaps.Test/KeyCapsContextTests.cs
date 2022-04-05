using Xunit;

namespace KeyCaps.Test;

[Collection("Sequential")] // A file database does not support parallel test execution.
public class KeyCapsContextTests : DatabaseTest
{
    [Fact]
    public void CreateDatabaseTest()
    {
        _db.Database.EnsureDeleted();
        _db.Database.EnsureCreated();
    }
}