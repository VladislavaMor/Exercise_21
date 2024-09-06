using Exercise_21.Data;
using Exercise_21.Models;

namespace Exercise_21
{
    public static class DbInitializer
    {
        public static void Initialize(PhoneBookContext context)
        {
            context.Database.EnsureCreated();

            if (context.Notes.Any()) return;

            var sections = new List<Note>()
            {
                new Note(){LastName="Иванов", FirstName="Иван", Patronymic="Иванович", Address="111", Phone="111", Description="111"}
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections)
                {
                    context.Notes.Add(section);
                }

                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Notes] ON");
                context.SaveChanges();
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Notes] OFF");
                trans.Commit();
            }


        }
    }
}