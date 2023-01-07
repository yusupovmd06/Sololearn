namespace Sololearn.entity
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ISet<Permission> Permissions { get; set; } = new HashSet<Permission>();
        public Role(long id, string name, string description) 
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Role(string name, string description, ISet<Permission> permissions)
        {
            Name = name;
            Description = description;
            Permissions = permissions;
        }
    }
}