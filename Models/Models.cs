using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int parent { get; set; }
        public string title { get; set; }
        public string icono { get; set; }
        public int orden { get; set; }
    }

    public class Permission
    {
        public int PermissionId { get; set; }
        public int rol_id { get; set; }
        public int crud { get; set; }
        public bool visible { get; set; }
        public int ItemID { get; set; }
    }

    public class Rol
    {
        public int RolId { get; set; }
        public string name { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string name { get; set; }
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }

    /// <summary>
    /// MenuDataContext debe ir comentado en caso de que no se utilice Entity Framework code first, en ese caso 
    /// deberan existir tablas con los nombres y parametros indicados en las classes de arriba, en caso de ocupar modificaciones
    /// tambien se debera modificar este archivo.
    /// </summary>
    public class MenuContext : DbContext
    {
        public MenuContext()
            : base()
        {
            Database.SetInitializer<MenuContext>(new CreateDatabaseIfNotExists<MenuContext>());
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
    }

}