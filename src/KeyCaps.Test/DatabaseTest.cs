using KeyCaps.Application.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyCaps.Test
{
    public class DatabaseTest : IDisposable
    {
        protected readonly KeyCapsContext _db;

        public DatabaseTest()
        {
            var opt = new DbContextOptionsBuilder()
                .UseSqlite("Data Source=KeyCaps.db")
                .Options;

            _db = new KeyCapsContext(opt);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
