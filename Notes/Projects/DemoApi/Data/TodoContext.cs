using Microsoft.EntityFrameworkCore;

namespace DemoApi.Data
{
    public class TodoContext :DbContext
    {
        public TodoContext(DbContextOptions  options ):base(options) { }
        


    }
}
