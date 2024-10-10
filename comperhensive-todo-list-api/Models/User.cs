namespace comperhensive_todo_list_api.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }



        public virtual ICollection<Todo> Todos { get; set; }

    }
}
