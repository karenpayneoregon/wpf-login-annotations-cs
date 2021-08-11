using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Data;
using Microsoft.EntityFrameworkCore;

namespace WindowsFormsApp2.Classes
{
    public class Operations
    {
        public static async Task<(bool success, Exception exception)> SetOutage(int Id, DateTime startOutage, DateTime endOutageDate)
        {
            try
            {
                await using var context = new Context();

                var application = await context.Application.FirstOrDefaultAsync(app => app.Id == Id);
                application.StartNotice = startOutage;
                application.EndOutage = endOutageDate;
                var results = await context.SaveChangesAsync();

                return results == 1 ? ((bool success, Exception exception)) (true, null) : (false, null);
            }
            catch (Exception exception)
            {
                return (false, exception);
            }

        }
    }

    public class Dummy
    {
        public async  Task Dummy1()
        {
            var (success, exception) = await Operations.SetOutage(1, DateTime.Now, DateTime.Now);
        }
    }
}
