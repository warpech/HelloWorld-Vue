using Starcounter;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    [Database]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Expense> Expenses => 
            Db.SQL<Expense>("SELECT e FROM Expense e WHERE e.Spender = ?", this);
        public decimal CurrentBalance =>
            Db.SQL<Expense>("SELECT e FROM Expense e WHERE e.Spender = ?", this).Sum(e => e.Amount);
    }

    [Database]
    public class Expense
    {
        public Person Spender { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Db.Transact(() =>
            {
                var person = Db.SQL<Person>("SELECT p FROM Person p").FirstOrDefault();
                if (person == null)
                {
                    new Person
                    {
                        FirstName = "John",
                        LastName = "Doe"
                    };
                }
            });
            
            Handle.GET("/HelloWorld", () =>
            {
                var resource = Db.Scope(() =>
                {
                    Session.Ensure();

                    var person = Db.SQL<Person>("SELECT p FROM Person p").FirstOrDefault();
                    var json = new PersonJson()
                    {
                        Data = person
                    };
                    Session.Ensure().Store[nameof(PersonJson)] = json;
                    return json;
                });
                var response = new Response()
                {
                    Resource = resource,
                };
                response.Headers["Location"] = Session.Current.SessionUri;
                return response;
            });
        }
    }
}