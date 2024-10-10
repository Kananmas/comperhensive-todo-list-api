namespace comperhensive_todo_list_api.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public string UserToken { get; set; }

    }
}
