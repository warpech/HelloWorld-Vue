using Starcounter;

namespace HelloWorld
{
    partial class ExpenseJson : Json, IBound<Expense>
    {
        public string ObjectId => this.Data.GetObjectID();
    }
}